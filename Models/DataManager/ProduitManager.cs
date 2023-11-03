using API_TD1_1.Models.DTO;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using API_TD1_1.Models.Repository.ProduitRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TD1_1.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>, IDataRepositoryProduitDTO, IDataRepositoryProduitDetailDTO
    {
        readonly ProduitDbContext produitdbcontext;

        public ProduitManager()
        { }

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

        public async Task UpdateAsync(Produit prodToUpdate, Produit newProd)
        {
            produitdbcontext.Entry(prodToUpdate).State = EntityState.Modified;
            prodToUpdate.IdProduit = newProd.IdProduit;
            prodToUpdate.NomProduit = newProd.NomProduit;
            prodToUpdate.Description = newProd.Description;
            prodToUpdate.NomPhoto = newProd.NomPhoto;
            prodToUpdate.UriPhoto = newProd.UriPhoto;
            prodToUpdate.IdTypeProduit = newProd.IdTypeProduit;
            prodToUpdate.IdMarque = newProd.IdMarque;
            prodToUpdate.StockMin = newProd.StockMin;
            prodToUpdate.StockReel = newProd.StockReel;
            prodToUpdate.StockMax = newProd.StockMax;
            await produitdbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produit entity)
        {
            produitdbcontext.Produits.Remove(entity);
            await produitdbcontext.SaveChangesAsync();
        }


        public async Task<Produit> MapDetailDtoToProduit(ProduitDetailDTO produitDetailDTO)
        {
            var marque = await produitdbcontext.Marques.Select(m => new Marque
            {
                IdMarque = m.IdMarque,
                NomMarque = m.NomMarque
            }).FirstOrDefaultAsync(m => m.NomMarque == produitDetailDTO.Marque);

            var typeProd = await produitdbcontext.TypeProduits.Select(m => new TypeProduit
            {
                IdTypeProduit = m.IdTypeProduit,
                NomTypeProduit = m.NomTypeProduit
            }).FirstOrDefaultAsync(m => m.NomTypeProduit == produitDetailDTO.Type);

            Produit p = new Produit
            {
                IdProduit = produitDetailDTO.Id,
                NomProduit = produitDetailDTO.Nom,
                Description = produitDetailDTO.Description,
                NomPhoto = produitDetailDTO.Nomphoto,
                UriPhoto = produitDetailDTO.Uriphoto,
                IdTypeProduit = typeProd.IdTypeProduit,
                IdMarque = marque.IdMarque,
                StockReel = produitDetailDTO.Stock
            };

            return p;
        }
    }
}
