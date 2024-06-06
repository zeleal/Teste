using System.ComponentModel.DataAnnotations;
using Shared.Abstractions;
using Shared.ValidationAttributes;

namespace Shared.AppSettings;

public sealed class JwtOptions : BaseOptions
{
    /// <summary>
    /// aud: Define quem pode usar o token.
    /// </summary>
    [Required]
    public string Audience { get; private init; }

    /// <summary>
    /// iss: O domínio da aplicação geradora do token.
    /// </summary>
    [Required]
    public string Issuer { get; private init; }

    /// <summary>
    /// Tempo de vida do token em segundos.
    /// </summary>
    [RequiredGreaterThanZero]
    public int Seconds { get; private init; }

    [Required]
    public string Secret { get; private init; }

    public static JwtOptions Create(string audience, string issuer, int seconds, string secret) => new()
    {
        Audience = audience,
        Issuer = issuer,
        Seconds = seconds,
        Secret = secret
    };
}