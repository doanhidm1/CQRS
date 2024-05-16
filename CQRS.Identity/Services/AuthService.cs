using CQRS.Application.Exceptions;
using CQRS.Application.Identity;
using CQRS.Application.Models.Identity;
using CQRS.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CQRS.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new NotFoundException($"User with email {request.Email} does not exist", request.Email);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!result.Succeeded)
            {
                throw new BadRequestException($"Crenctials for user with email {request.Email} are invalid");
            }

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = await GenerateJwtToken(user),
                Email = user.Email,
                UserName = user.UserName,
            };
            return response;
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var claims = userClaims.ToList();
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var descriptor = new SecurityTokenDescriptor
            {
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                SigningCredentials = signingCredentials,
                NotBefore = DateTime.UtcNow,
                IssuedAt = DateTime.UtcNow,
                Claims = new Dictionary<string, object> { { "UserId", user.Id } }
            };
            var token = new JsonWebTokenHandler().CreateToken(descriptor);
            return token;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new BadRequestException(GetErrors(result.Errors));
            }

            await _userManager.AddToRoleAsync(user, "Employee");
            return new RegistrationResponse { UserId = user.Id };
        }

        private static string GetErrors(IEnumerable<IdentityError> errors)
        {
            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.AppendLine(error.Description);
            }
            return stringBuilder.ToString();
        }
    }
}
