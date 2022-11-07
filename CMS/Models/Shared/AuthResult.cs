namespace CMS.Models.Shared
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public AuthToken Token { get; set; }
    }
}
