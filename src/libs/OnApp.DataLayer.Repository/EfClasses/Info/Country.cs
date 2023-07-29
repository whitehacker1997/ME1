using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global.Models;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository;

[Table("info_country")]
[Index("Code", Name = "info_country_unique_code", IsUnique = true)]
[Index("TextCode", Name = "info_country_unique_text_code", IsUnique = true)]
public class Country : 
    IHaveStateId,
    IHaveIdProp<int>
{
    public Country()
    {
        Translates 
            = new HashSet<CountryTranslate>();
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(10)]
    public string? OrderCode { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("text_code")]
    [StringLength(50)]
    public string TextCode { get; set; } = null!;

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(500)]
    public string FullName { get; set; } = null!;

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

    [ForeignKey(nameof(StateId))]
    public virtual State State { get; set; } = null!;

    [InverseProperty(nameof(CountryTranslate.Owner))]
    public virtual ICollection<CountryTranslate> Translates { get; set; } = null!;
}
