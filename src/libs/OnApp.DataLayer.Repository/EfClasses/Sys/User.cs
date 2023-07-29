using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global;
using Global.Models;
using Global.Security;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_user")]

    [Index(
        "OrganizationId",
        "StateId",
        Name = "sys_user_index_organization_id__state_id",
        IsUnique = false)]

    [Index(
        "UserName",
        Name = "sys_user_index_user_name",
        IsUnique = true)]

    public class User :
        IHaveIdProp<int>,
        IHaveStateId
    {
        public User()
        {
            RoleModules = new HashSet<RoleModule>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_name")]
        [StringLength(250)]
        public string UserName { get; set; } = null!;
        [Column("password_hash")]
        [StringLength(250)]
        public string PasswordHash { get; set; } = null!;
        [Column("password_salt")]
        [StringLength(259)]
        public string PasswordSalt { get; set; } = null!;
        [Column("email")]
        [StringLength(259)]
        public string? Email { get; set; }
        [Column("phone_number")]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        [Column("organization_id")]
        public int OrganizationId { get; set; }
        [Column("person_id")]
        public int PersonId { get; set; }
        [Column("language_id")]
        public int? LanguageId { get; set; }
        [Column("last_access_time", TypeName = "timestamp without time zone")]
        public DateTime? LastAccessTime { get; set; }
        [Column("state_id")]
        public int StateId { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }
        [Column("created_by")]
        public int? CreatedBy { get; set; }
        [Column("modified_at", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedAt { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }


        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; }
        [InverseProperty(nameof(RoleModule.CreatedUser))]
        public virtual ICollection<RoleModule> RoleModules { get; set; }
        [InverseProperty(nameof(UserRole.User))]
        public virtual ICollection<UserRole> UserRoles { get; set; }


        public bool IsValidPassword(string password)
            => !(password.NullOrEmpty() ||
                 new CustomePasswordHasher()
                    .HashPassword(
                         password: password,
                         salt: PasswordSalt) != PasswordHash);

        public void SetPassword(
            string password,
            bool isNewEntity = false)
        {
            if (isNewEntity && password.NullOrEmpty())
                throw new ArgumentException(
                    "password is required for new user entity",
                    nameof(password));

            if (isNewEntity || !password.NullOrEmpty())
            {
                PasswordSalt = HashHelper.CreateRandomSalt();

                PasswordHash = new CustomePasswordHasher().HashPassword(password: password,
                                                                        salt: PasswordSalt);
            }

        }
    }
}
