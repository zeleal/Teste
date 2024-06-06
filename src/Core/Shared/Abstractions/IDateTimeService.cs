using System;

namespace Shared.Abstractions;

public interface IDateTimeService
{
    DateTime Now { get; }
}