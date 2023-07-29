namespace OnApp.BizLayer.AccountServices
{
    public class LoginResultDto
    {
        public string Token { get; set; } = null!;
        public AccountUserDto User { get; set; }
    }
}
