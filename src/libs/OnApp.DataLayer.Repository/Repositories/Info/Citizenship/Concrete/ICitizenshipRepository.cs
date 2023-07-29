using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface ICitizenshipRepository :
        IBaseEntityRepository<int, Citizenship, CreateCitizenshipDlDto, UpdateCitizenshipDlDto>
    {
        Citizenship ByWbCode(string wbCode);
    }
}
