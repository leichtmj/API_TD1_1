using API_TD1_1.Models.DTO;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TD1_1.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>, IDataRepositoryProduitDTO, IDataRepositoryProduitDetailDTO
    {
        readonly ProduitDbContext produitdbcontext;

        public ProduitManager()
        {

        }

        public ProduitManager(ProduitDbContext context)
        {
            produitdbcontext = context;
        }

        public async Task<ActionResult<IEnumerable<ProduitDTO>>> GetAllAsync()
        {
            var produitsDTO = await produitdbcontext.Produits.Select(productToDTO => new ProduitDTO{

                Id = productToDTO.IdProduit,
                Nom = productToDTO.NomProduit,
                Marque = productToDTO.MarqueNavigation.NomMarque,
                Type = productToDTO.TypeProduitNavigation.NomTypeProduit

            }).ToListAsync();

            return produitsDTO;
        }

        public async Task<ActionResult<ProduitDetailDTO>> GetByIdAsync(int id)
        {
            var produitDTO = await produitdbcontext.Produits.Select(productToDTO => new ProduitDetailDTO
            {

                Id = productToDTO.IdProduit,
                Nom = productToDTO.NomProduit,
                Marque = productToDTO.MarqueNavigation.NomMarque,
                Type = productToDTO.TypeProduitNavigation.NomTypeProduit,
                Description = productToDTO.Description,
                Nomphoto = productToDTO.NomPhoto,
                Uriphoto = productToDTO.UriPhoto,
                Stock = productToDTO.StockReel,
                EnReappro = productToDTO.StockReel < productToDTO.StockMin ? true : false

            }).FirstOrDefaultAsync(p => p.Id == id);

            return produitDTO;

        }

        public async Task<ActionResult<ProduitDetailDTO>> GetByStringAsync(string str)
        {
            var produitDTO = await produitdbcontext.Produits.Select(productToDTO => new ProduitDetailDTO
            {

                Id = productToDTO.IdProduit,
                Nom = productToDTO.NomProduit,
                Marque = productToDTO.MarqueNavigation.NomMarque,
                Type = productToDTO.TypeProduitNavigation.NomTypeProduit,
                Description = productToDTO.Description,
                Nomphoto = productToDTO.NomPhoto,
                Uriphoto = productToDTO.UriPhoto,
                Stock = productToDTO.StockReel,
                EnReappro = productToDTO.StockReel < productToDTO.StockMin ? true : false

            }).FirstOrDefaultAsync(p => p.Nom == str);

            return produitDTO;
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
