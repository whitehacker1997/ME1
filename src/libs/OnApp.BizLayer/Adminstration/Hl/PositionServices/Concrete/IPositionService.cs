using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.PositionServices
{
    public interface IPositionService : 
        IStatusGeneric
    {
        PagedResult<PositionListDto> GetPositionList(SortFilterPageOptions options);
        SelectList<int> GetPositionAsSelectList();
        PositionDto GetPosition();
        PositionDto GetPositionById(int positionId);
        HaveId<int> CreatePosition(CreatePositionDlDto dto);
        void UpdatePosition(UpdatePositionDlDto dto);
        void DeletePosition(int positionId);
    }
}
