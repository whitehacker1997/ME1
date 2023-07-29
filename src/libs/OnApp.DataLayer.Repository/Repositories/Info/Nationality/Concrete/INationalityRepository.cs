using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface INationalityRepository :
        IBaseEntityRepository<int, Nationality, CreateNationalityDlDto, UpdateNationalityDlDto>
    {
        Nationality ByWbCode(string wbCode);
    }
}
