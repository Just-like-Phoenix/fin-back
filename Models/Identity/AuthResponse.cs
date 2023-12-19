namespace fin_back.Models.Identity
{
    public class AuthResponse
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
