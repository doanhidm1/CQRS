﻿using MediatR;

namespace CQRS.Application.Features.LeaveType.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
