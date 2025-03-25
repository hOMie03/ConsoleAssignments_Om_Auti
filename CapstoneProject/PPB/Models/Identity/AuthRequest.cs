namespace PPB.Models.Identity
{
    public class AuthRequest // Login
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
