using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.PositionServices
{
    public class PositionDto :
        UpdatePositionDlDto,
        ILinkToEntity<Position>
    {
        public string StateName { get; set; } = null!;
        //new public List<PositionTranslateDto> Translates { get; set; } = new();
    }
}
