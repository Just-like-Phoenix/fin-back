namespace fin_back.Models.Identity
{
    public class TokenClaims
    {
        public string? jti {  get; set; }
        public string? iat { get; set; }
        public string? id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
        public int? exp { get; set; }
        public string? iss { get; set; }
        public string? aud { get; set; }
    }
}
