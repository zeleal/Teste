using Shared.Abstractions;
using Shared.ValidationAttributes;

namespace Shared.AppSettings;

public sealed class AuthOptions : BaseOptions
{
    [RequiredGreaterThanZero]
    public int MaximumAttempts { get; private init; }

    [RequiredGreaterThanZero]
    public int SecondsBlocked { get; private init; }

    public static AuthOptions Create(int maximumAttempts, int secondsBlocked)
        => new() { MaximumAttempts = maximumAttempts, SecondsBlocked = secondsBlocked };
}