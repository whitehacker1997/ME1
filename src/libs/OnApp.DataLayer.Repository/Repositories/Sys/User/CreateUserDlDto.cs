using Global.Attributes;

namespace OnApp.DataLayer.Repository
{
    public class CreateUserDlDto : 
        UserDlDto<CreateUserDlDto>
    {
        public int PersonId { get; set; }

        [LocalizedRequired]
        [LocalizedMinLength(8)]
        public override string Password { get => base.Password; set => base.Password = value; }
    }
}
