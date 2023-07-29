using OnApp.DataLayer.Repository;
using GenericServices;
using Global.Models;

namespace OnApp.BizLayer.AccountServices
{
    public class AccountUserDto :
        ILinkToEntity<User>,
        IHaveStateId
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Inn { get; set; } = null!;
        public string Pinfl { get; set; } = null!;
        public int? LanguageId { get; set; }
        public int StateId { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
        public string LanguageName { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public List<string> Modules { get; set; } = new();
        public List<string> Roles { get; set; } = new();

        //public string? Position { get; set; }
    }
}
