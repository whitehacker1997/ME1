using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Global.Security
{
    public abstract class JwtAuthService :
        IAuthService
    {
        public JwtAuthService(
            JwtConfig config,
            IHttpContextAccessor httpContextAccessor)
        {
            Config = config;
            HttpContextAccessor = httpContextAccessor;
        }

        private bool? _isAuthenticated;

        private string _userName = null!;

        private string _userIp = null!;

        private string _userAgent = null!;

        protected IHttpContextAccessor HttpContextAccessor { get; private set; } = null!;

        protected JwtConfig Config { get; private set; } = null!;

        protected virtual string AuthKey { get; set; } = "Authorization";

        protected virtual string ReadTokenFromRequest()
        {
            string[] array = HttpContextAccessor
                                .HttpContext
                                    .Request!
                                        .Headers[AuthKey]
                                            .FirstOrDefault()
                                                .AsString()
                                                    .Split(' ');
            if (array.Length != 2 || array[0].AsString() != "Bearer")
                return null;

            return array[1].AsString();
        }

        protected bool ValidateToken(string token)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidateAudience = true;
            validationParameters.ValidateIssuer = true;
            validationParameters.ValidIssuer = Config.Issuer;
            validationParameters.ValidAudience = Config.Issuer;
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.SecretKey));

            try
            {
                SecurityToken validateToken;
                return ((IPrincipal)jwtSecurityTokenHandler.ValidateToken(token: token,
                                                                          validationParameters: validationParameters,
                                                                          out validateToken))
                                                                            .Identity
                                                                                .IsAuthenticated && validateToken.ValidTo > DateTime.UtcNow;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsAuthenticated
        {
            get
            {
                if (!_isAuthenticated.HasValue)
                {
                    string text = ReadTokenFromRequest();

                    if (text.NullOrWhiteSpace())
                        _isAuthenticated = false;
                    else
                        _isAuthenticated = ValidateToken(text);
                }

                return _isAuthenticated.Value;
            }
        }

        public string UserIp
        {
            get
            {
                if (_userIp == null)
                {
                    _userIp = HttpContextAccessor
                                .HttpContext
                                    .Connection
                                        .RemoteIpAddress
                                            .MapToIPv4()
                                                .ToString();

                    if (HttpContextAccessor.HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                        _userIp = _userIp
                            + ";"
                            + (string)HttpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"];
                }

                return _userIp;
            }
        }

        public string UserAgent
        {
            get
            {
                if (_userAgent == null
                    && HttpContextAccessor.HttpContext!.Request.Headers.ContainsKey("User-Agent"))
                    _userAgent = HttpContextAccessor.HttpContext!.Request.Headers["User-Agent"];

                return _userAgent;
            }
        }

        public abstract object UserId { get; }

        public virtual string UserName
        {
            get
            {
                if (!IsAuthenticated)
                    return null;

                if (_userName == null)
                    _userName =
                        new JwtSecurityTokenHandler().ReadJwtToken(ReadTokenFromRequest())
                        .Claims
                            .FirstOrDefault((Claim claim) => claim.Type == "sub")?.Value;

                return _userName;
            }
        }

        public abstract HashSet<string> Modules { get; }

        public virtual string GenerateToken(string userName)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("sub", userName));

            SigningCredentials signingCredentials 
                = new SigningCredentials(key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.SecretKey)),
                                         algorithm: "HS256");

            string issuer = Config.Issuer;
            string issuer2 = Config.Issuer;

            DateTime? expires = DateTime.Now.AddMinutes(Config.Expires);

            SigningCredentials signingCredentials2 = signingCredentials;

            JwtSecurityToken token = new JwtSecurityToken(issuer: issuer,
                                                          audience: issuer2,
                                                          claims: claims,
                                                          notBefore: null,
                                                          expires: expires,
                                                          signingCredentials: signingCredentials2);

            return new JwtSecurityTokenHandler()
                                .WriteToken(token);
        }

        public virtual bool HasPermission(string moduleCode)
        {
            if (!IsAuthenticated)
                return false;

            return Modules.Contains(moduleCode);
        }

        protected virtual void Clear()
        {
            _isAuthenticated = null;
            _userName = null;
            _userIp = null;
            _userAgent = null;
        }

        public virtual void ResetUserName(string userName)
        {
            Clear();
            _isAuthenticated = true;
            _userName = userName;
        }
    }
}
