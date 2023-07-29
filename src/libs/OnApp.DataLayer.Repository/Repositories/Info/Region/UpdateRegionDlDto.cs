using Global.Attributes;
using Global.Models;

namespace OnApp.DataLayer.Repository
{
    public class UpdateRegionDlDto : 
        RegionDlDto<UpdateRegionDlDto>,
        IHaveIdProp<int>
    {
        [LocalizedRequired]
        [LocalizedRange(1, int.MaxValue)]
        public int Id { get; set; }
        [LocalizedRequired]
        [LocalizedRange(1, int.MaxValue)]
        public int StateId { get; set; }
    }
}
