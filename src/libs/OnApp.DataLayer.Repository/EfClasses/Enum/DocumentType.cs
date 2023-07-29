using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global.Models;

namespace OnApp.DataLayer.Repository
{
    [Table("enum_document_type")]
    public class DocumentType : 
        IHaveStateId
    {
        public DocumentType()
        {
            Translates = new HashSet<DocumentTypeTranslate>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(50)]
        public string? OrderCode { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(250)]
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

        [InverseProperty(nameof(DocumentTypeTranslate.Owner))]
        public virtual ICollection<DocumentTypeTranslate> Translates { get; set; }
    }
}
