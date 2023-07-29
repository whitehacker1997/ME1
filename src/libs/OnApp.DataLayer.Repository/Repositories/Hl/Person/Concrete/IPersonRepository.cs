using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IPersonRepository :
        IBaseEntityRepository<int, Person, CreatePersonDlDto, UpdatePersonDlDto>
    {
        Person ByPinfl(string pinfl);
        Person ByDocInfo(int docTypeId, string docSeria, string docNumber);
    }
}
