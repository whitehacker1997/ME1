using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.PersonServices
{
    public interface IPersonService :
        IStatusGeneric
    {
        PagedResult<PersonListDto> GetPersonList(SortFilterPageOptions filter);
        PersonDto GetPerson();
        PersonDto GetPersonById(int id);
        PersonDto GetPersonByDoc(string docSeria, string docNumber);
        SelectList<int> GetPersonAsSelectList();
        HaveId<int> CreatePerson(CreatePersonDlDto dto);
        void UpdatePerson(UpdatePersonDlDto dto);
        void DeletePerson(int id);
    }
}
