using System;

namespace Shared.Records;

public sealed record AccessToken(string Token, DateTime CreatedAt, DateTime ExpiresAt);