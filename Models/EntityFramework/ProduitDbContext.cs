using Microsoft.EntityFrameworkCore;

namespace API_TD1_1.Models.EntityFramework
{
    public partial class ProduitDbContext : DbContext
    {
        public ProduitDbContext()
        {
        }

        public ProduitDbContext(DbContextOptions<ProduitDbContext> options) : base(options) { }

        public virtual DbSet<Marque> Marques { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<TypeProduit> TypeProduits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(p => p.IdProduit).HasName("pk_pro");

                entity.HasOne(d => d.MarqueNavigation).WithMany(p => p.ProduitsNavigation)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_mar");

                entity.HasOne(d => d.TypeProduitNavigation).WithMany(p => p.ProduitsNavigation)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_typ");
            });


            modelBuilder.Entity<TypeProduit>(entity =>
            {
                entity.HasKey(t => t.IdTypeProduit).HasName("pk_typ");
            });


            modelBuilder.Entity<Marque>(entity =>
            {
                entity.HasKey(t => t.IdMarque).HasName("pk_mar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}