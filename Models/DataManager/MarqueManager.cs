using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using API_TD1_1.Models.Repository.MarqueRepository;
using API_TD1_1.Models.DTO;

namespace API_TD1_1.Models.DataManager
{
    public class MarqueManager : IDataRepository<Marque>, IDataRepositoryMarqueDTO
    {
        readonly ProduitDbContext produitdbcontext;


        public MarqueManager()
        {
        }

        public MarqueManager(ProduitDbContext context)
        {
            produitdbcontext = context;
        }

        public async Task<ActionResult<IEnumerable<MarqueDTO>>> GetAllAsync()
        {

            var produitsDTO = await produitdbcontext.Marques.Select(marqueToDTO => new MarqueDTO
            {

                Id = marqueToDTO.IdMarque,
                Nom = marqueToDTO.NomMarque,
                NbProduits = marqueToDTO.ProduitsNavigation.Count

            }).ToListAsync();

            return produitsDTO;
        }

        public async Task<ActionResult<MarqueDTO>> GetByIdAsync(int id)
        {
            var marqueDTO = await produitdbcontext.Marques.Select(marqueToDTO => new MarqueDTO
            {

                Id = marqueToDTO.IdMarque,
                Nom = marqueToDTO.NomMarque,
                NbProduits = marqueToDTO.ProduitsNavigation.Count

            }).FirstOrDefaultAsync(m => m.Id == id);

            return marqueDTO;
        }
        public async Task<ActionResult<MarqueDTO>> GetByStringAsync(string str)
        {
            var marqueDTO = await produitdbcontext.Marques.Select(marqueToDTO => new MarqueDTO
            {

                Id = marqueToDTO.IdMarque,
                Nom = marqueToDTO.NomMarque,
                NbProduits = marqueToDTO.ProduitsNavigation.Count

            }).FirstOrDefaultAsync(m => m.Nom == str);

            return marqueDTO;
        }
        public async Task AddAsync(Marque entity)
        {
            await produitdbcontext.Marques.AddAsync(entity);
            await produitdbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Marque taille, Marque entity)
        {
            produitdbcontext.Entry(taille).State = EntityState.Modified;
            taille.IdMarque = entity.IdMarque;
            taille.NomMarque = entity.NomMarque;
            await produitdbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Marque entity)
        {
            produitdbcontext.Marques.Remove(entity);
            await produitdbcontext.SaveChangesAsync();
        }

        public async Task<Marque> MapMarqueDtoToMarque(MarqueDTO produitDetailDTO)
        {

            Marque m = new Marque
            {
                IdMarque = produitDetailDTO.Id,
                NomMarque = produitDetailDTO.Nom
            };

            return m;
        }
    }
}
