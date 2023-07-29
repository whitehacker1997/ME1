using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository;

[Table("enum_state")]
public class State
{
    public State()
    {
        Translates = new HashSet<StateTranslate>();
    }
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("order_code")]
    [StringLength(5)]
    public string? OrderCode { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string? ShortName { get; set; }

    [Column("full_name")]
    [StringLength(500)]
    public string? FullName { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty(nameof(StateTranslate.Owner))]
    public ICollection<StateTranslate> Translates { get; set; } = null!;
}
