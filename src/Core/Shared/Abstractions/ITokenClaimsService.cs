using System.Security.Claims;
using Shared.Records;

namespace Shared.Abstractions;

public interface ITokenClaimsService
{
    AccessToken GenerateAccessToken(Claim[] claims);
    string GenerateRefreshToken();
}