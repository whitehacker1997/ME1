using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.RegionServices
{
    public interface IRegionService : 
        IStatusGeneric
    {
        PagedResult<RegionListDto> GetRegionList(SortFilterPageOptions options);
        SelectList<int> GetRegionAsSelectList();
        RegionDto GetRegion();
        RegionDto GetRegionById(int regionId);
        HaveId<int> CreateRegion(CreateRegionDlDto dto);
        void UpdateRegion(UpdateRegionDlDto dto);
        void DeleteRegion(int regionId);
    }
}
