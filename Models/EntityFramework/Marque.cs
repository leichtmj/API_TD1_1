using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API_TD1_1.Models.EntityFramework
{
    [Table("t_e_marque_mar")]
    public class Marque
    {
        [Key]
        [Column("mar_id")]
        public int IdMarque { get; set; }

        [Column("mar_nom")]
        [MaxLength(85)]
        public string NomMarque { get; set; }


        [InverseProperty("MarqueNavigation")]
        public virtual ICollection<Produit> ProduitsNavigation { get; set; } = new List<Produit>();
    }
}
