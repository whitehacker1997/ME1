using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.CountryServices
{
    public class CountryListDto : 
        ILinkToEntity<Country>
    {
        public int Id { get; set; }
        public string? OrderCode { get; set; }
        public string Code { get; set; } = null!;
        public string TextCode { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int StateId { get; set; }

        public string StateName { get; set; } = null!;
    }
}
