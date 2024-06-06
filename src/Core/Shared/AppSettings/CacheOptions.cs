using Shared.Abstractions;
using Shared.ValidationAttributes;

namespace Shared.AppSettings;

public sealed class CacheOptions : BaseOptions
{
    [RequiredGreaterThanZero]
    public int AbsoluteExpirationInHours { get; private init; }

    [RequiredGreaterThanZero]
    public int SlidingExpirationInSeconds { get; private init; }
}