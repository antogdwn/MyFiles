namespace AuthAPI.Models
{

    public sealed class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /*
         * Store a hash of the refresh token, not the raw token.
         */
        public string TokenHash { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAtUtc { get; set; }

        public DateTime ExpiresAtUtc { get; set; }

        public DateTime? RevokedAtUtc { get; set; }

        /*
         * Stores the hash of the token that replaced this token
         * during refresh-token rotation.
         */
        public string? ReplacedByTokenHash { get; set; }

        /*
         * Optional session/device information.
         * Do not rely on these values as security credentials.
         */
        public string? DeviceName { get; set; }

        public string? CreatedByIp { get; set; }

        public string? RevokedByIp { get; set; }

        /*
         * Navigation property.
         */
        public ApplicationUser User { get; set; } = null!;

        public bool IsExpired =>
            DateTime.Now >= ExpiresAtUtc;

        public bool IsRevoked =>
            RevokedAtUtc.HasValue;

        public bool IsActive =>
            !IsExpired && !IsRevoked;
    }
}
