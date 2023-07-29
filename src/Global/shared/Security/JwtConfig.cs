namespace Global.Security
{
    public class JwtConfig
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int Expires { get; set; }
    }
}
