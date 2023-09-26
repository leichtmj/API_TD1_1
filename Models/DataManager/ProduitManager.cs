using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TD1_1.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>
    {
        readonly ProduitDbContext produitdbcontext;

        public ProduitManager()
        {
        }

        public ProduitManager(ProduitDbContext context)
        {
            produitdbcontext = context;
        }

        public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
        {
            return await produitdbcontext.Produits.ToListAsync();
        }
        public async Task<ActionResult<Produit>> GetByIdAsync(int id)
        {
            return await produitdbcontext.Produits.FirstOrDefaultAsync(ta => ta.IdProduit == id);
        }
        public async Task<ActionResult<Produit>> GetByStringAsync(string str)
        {
            return await produitdbcontext.Produits.FirstOrDefaultAsync(ta => ta.NomProduit.ToUpper() == str.ToUpper());
        }
        public async Task AddAsync(Produit entity)
        {
            await produitdbcontext.Produits.AddAsync(entity);
            await produitdbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Produit taille, Produit entity)
        {
            produitdbcontext.Entry(taille).State = EntityState.Modified;
            taille.IdProduit = entity.IdProduit;
            taille.NomProduit = entity.NomProduit;
            taille.Description = entity.Description;
            taille.NomPhoto = entity.NomPhoto;
            taille.UriPhoto = entity.UriPhoto;
            taille.IdTypeProduit = entity.IdTypeProduit;
            taille.IdMarque = entity.IdMarque;
            taille.StockMin = entity.StockMin;
            taille.StockReel = entity.StockReel;
            taille.StockMax = entity.StockMax;
            await produitdbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produit entity)
        {
            produitdbcontext.Produits.Remove(entity);
            await produitdbcontext.SaveChangesAsync();
        }
    }
}
