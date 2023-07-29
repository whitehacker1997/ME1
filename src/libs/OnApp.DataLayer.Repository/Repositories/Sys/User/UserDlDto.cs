using Global;
using Global.Attributes;
using Global.EF;
using Global.Security;

namespace OnApp.DataLayer.Repository;

public class UserDlDto<TDto> :
    EntityDto<TDto, User>
        where TDto : UserDlDto<TDto>
{
    public string UserName { get; set; } = null!;
    public virtual string Password { get; set; } = null!;
    public int OrganizationId { get; set; }
    public int? LanguageId { get; set; }
    public string? Email { get; set; }
    [LocalizedRequired]
    [LocalizedStringLength(50)]
    public string? PhoneNumber { get; set; }
    public List<int> Roles { get; set; } = new();
    public override User CreateEntity()
    {
        var entity = base.CreateEntity();

        SetPassword(entity, true);

        entity.StateId = StateIdConst.ACTIVE;

        entity.UserRoles.AddFromForeignKeys(Roles);

        return entity;
    }

    public override void UpdateEntity(User entity)
    {
        entity.UserRoles
                .UpdateByStateIdFromForeignKeys(Roles);

        base.UpdateEntity(entity);

        SetPassword(entity: entity);
    }

    private void SetPassword(User entity,
                             bool isNewEntity = false)
    {
        if (isNewEntity || !Password.NullOrEmpty())
        {
            entity.PasswordSalt = HashHelper.CreateRandomSalt();

            entity.PasswordHash 
                = new CustomePasswordHasher().HashPassword(password: Password,
                                                           salt: entity.PasswordSalt);
        }
    }
}
