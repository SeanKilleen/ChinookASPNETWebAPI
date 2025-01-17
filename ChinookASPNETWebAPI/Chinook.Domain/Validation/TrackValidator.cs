﻿using Chinook.Domain.Entities;
using FluentValidation;

namespace Chinook.Domain.Validation
{
    public class TrackValidator : AbstractValidator<Track>
    {
        public TrackValidator()
        {
            RuleFor(t => t.Name).NotNull();
            RuleFor(t => t.Bytes).GreaterThan(0);
            RuleFor(t => t.Milliseconds).GreaterThan(0);
            RuleFor(t => t.Composer).NotNull();
            RuleFor(t => t.UnitPrice).GreaterThan(0);
        }
    }
}