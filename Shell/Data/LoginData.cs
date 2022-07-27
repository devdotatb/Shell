namespace Shell.Data
{
    public class LoginModel
    {
        public LoginModel()
        {
            type = 0;
        }
        public LoginType type { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public string? Password1 { get; set; }
        public string? Password2 { get; set; }
    }
    public enum LoginType
    {
        login = 0,
        doublepassword = 1,
    }
}
