using CQRS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CQRS.Domain
{
    public class LeaveType : BaseEntity
    {
        [MaxLength(70)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100)]
        public int DefaultDays { get; set; }
    }
}
