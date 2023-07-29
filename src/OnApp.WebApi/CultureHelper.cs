using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global.Configs;
using Global.Helpers;
using Global.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace OnApp.WebApi
{
    public class CultureHelper :
        BaseCultureHelper
    {
        private readonly DbContext context;
        //private readonly IAuthService authService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CultureHelper(
                CultureConfig config,
                DbContext context,
                //IAuthService authService,
                IHttpContextAccessor httpContextAccessor)
                    :base(config)
        {
            this.context = context;
            //this.authService = authService;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override IEnumerable<CultureModel> GetCulture()
            => this.context.Set<Language>()
                    .AsEnumerable()
                    .Select(language
                            => new CultureModel(
                                    id: language.Id,
                                    code: language.Code,
                                    name: language.FullName));
        protected override CultureModel GetDefaultCulture()
            => Cultures.FirstOrDefault(cultureModel => cultureModel.Code == "ru");

        protected override CultureModel GetCurrentCulture()
        {
            if (httpContextAccessor.HttpContext.Request.Query.TryGetValue("__lang",
                out StringValues lang) && !StringValues.IsNullOrEmpty(lang) &&
                Cultures.Any(cultureModel => cultureModel.Code == lang
                ))
                return Cultures.FirstOrDefault(culture => culture.Code == lang);
            /*if (authService.IsAuthenticated)
                return Cultures.FirstOrDefault(a => a.Code == authService.User.LanguageCode) ?? DefaultCulture;*/
            return DefaultCulture;

        }

    }
}
