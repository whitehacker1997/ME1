using Global.Models;

namespace Global.Helpers
{
    public interface ICultureHelper
    {
        CultureModel DefaultCulture { get; }
        CultureModel CurrentCulture { get; }
        IReadOnlyCollection<CultureModel> Cultures { get;}
    }
}
