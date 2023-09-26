using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TD1_1.Models.EntityFramework
{
    [Table("t_e_produit_pro")]
    public class Produit
    {
        [Key]
        [Column("pro_id")]
        public int IdProduit { get; set; }

        [Column("pro_nom")]
        [MaxLength(80)]
        public string NomProduit { get; set; }

        [Column("pro_desc")]
        [MaxLength(905)]
        public string Description { get; set; }

        [MaxLength(25)]
        [Column("pro_nomphoto")]
        public string NomPhoto { get; set; }

        [MaxLength(250)]
        [Column("pro_uriphoto")]
        public string UriPhoto { get; set; }

        [Column("pro_idtype")]
        public int IdTypeProduit { get; set; }

        [Column("pro_idmarque")]
        public int IdMarque { get; set; }

        [Column("pro_stockreel")]
        public int StockReel { get; set; }

        [Column("pro_stockmin")]
        public int StockMin { get; set; }

        [Column("pro_stockmax")]
        public int StockMax { get; set; }




        [ForeignKey("IdTypeProduit")]
        [InverseProperty("ProduitsNavigation")]
        public virtual TypeProduit TypeProduitNavigation { get; set; } = null;


        [ForeignKey("IdMarque")]
        [InverseProperty("ProduitsNavigation")]
        public virtual Marque MarqueNavigation { get; set; } = null;




    }
}
