using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.CitizenshipServices
{
    public interface ICitizenshipService : 
        IStatusGeneric
    {
        PagedResult<CitizenshipListDto> GetCitizenshipList(SortFilterPageOptions options);
        SelectList<int> GetCitizenshipAsSelectList();
        CitizenshipDto GetCitizenship();
        CitizenshipDto GetCitizenshipById(int citizenshipId);
        HaveId<int> CreateCitizenship(CreateCitizenshipDlDto dto);
        void UpdateCitizenship(UpdateCitizenshipDlDto dto);
        void DeleteCitizenship(int citizenshipId);
    }
}
