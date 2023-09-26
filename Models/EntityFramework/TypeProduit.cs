using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API_TD1_1.Models.EntityFramework
{
    [Table("t_e_typeproduit_typ")]
    public class TypeProduit
    {
        [Key]
        [Column("typ_id")]
        public int IdTypeProduit { get; set; }

        [Required]
        [Column("typ_nom")]
        [MaxLength(85)]
        public string NomTypeProduit { get; set; }

        [InverseProperty("TypeProduitNavigation")]
        public virtual ICollection<Produit> ProduitsNavigation { get; set; } = new List<Produit>();
    }
}
