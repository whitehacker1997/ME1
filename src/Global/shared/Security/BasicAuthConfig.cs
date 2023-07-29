namespace Global.Security
{
    public class BasicAuthConfig
    {
        public BasicAuthRealmConfig[] Realms { get; set; } = new BasicAuthRealmConfig[] { };
    }

    public class BasicAuthRealmConfig
    {
        public string Realm { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string[] IpList { get; set; } = new string[] { };
    }
}
