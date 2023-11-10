using API_TD1_1.Models.DTO;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using API_TD1_1.Models.Repository.TypeProduitRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TD1_1.Models.DataManager
{
    public class TypeProduitManager : IDataRepository<TypeProduit>, IDataRepositoryTypeProduitDTO
    {
        readonly ProduitDbContext produitdbcontext;

        public TypeProduitManager()
        {
        }

        public TypeProduitManager(ProduitDbContext context)
        {
            produitdbcontext = context;
        }

        public async Task<ActionResult<IEnumerable<TypeProduitDTO>>> GetAllAsync()
        {
            var typeProduitsDTO = await produitdbcontext.TypeProduits.Select(typeProduit => new TypeProduitDTO
            {

                Id = typeProduit.IdTypeProduit,
                Nom = typeProduit.NomTypeProduit,
                NbProduits = typeProduit.ProduitsNavigation.Count

            }).ToListAsync();

            return typeProduitsDTO;
        }
        public async Task<ActionResult<TypeProduitDTO>> GetByIdAsync(int id)
        {
            var typeProduitDTO = await produitdbcontext.TypeProduits.Select(typeProduit => new TypeProduitDTO
            {

                Id = typeProduit.IdTypeProduit,
                Nom = typeProduit.NomTypeProduit,
                NbProduits = typeProduit.ProduitsNavigation.Count

            }).FirstOrDefaultAsync(p=>p.Id==id);

            return typeProduitDTO;
        }
        public async Task<ActionResult<TypeProduitDTO>> GetByStringAsync(string str)
        {
            var typeProduitDTO = await produitdbcontext.TypeProduits.Select(typeProduit => new TypeProduitDTO
            {

                Id = typeProduit.IdTypeProduit,
                Nom = typeProduit.NomTypeProduit,
                NbProduits = typeProduit.ProduitsNavigation.Count

            }).FirstOrDefaultAsync(p => p.Nom == str);

            return typeProduitDTO;
        }
        public async Task AddAsync(TypeProduit entity)
        {
            await produitdbcontext.TypeProduits.AddAsync(entity);
            await produitdbcontext.SaveChangesAsync();
        }
        public async Task UpdateAsync(TypeProduit taille, TypeProduit entity)
        {
            produitdbcontext.Entry(taille).State = EntityState.Modified;
            taille.IdTypeProduit = entity.IdTypeProduit;
            taille.NomTypeProduit = entity.NomTypeProduit;
            await produitdbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TypeProduit entity)
        {
            produitdbcontext.TypeProduits.Remove(entity);
            await produitdbcontext.SaveChangesAsync();
        }


        public async Task<TypeProduit> MapMarqueDtoToMarque(TypeProduitDTO typeProduitDTO)
        {

            TypeProduit t = new TypeProduit
            {
                IdTypeProduit = typeProduitDTO.Id,
                NomTypeProduit = typeProduitDTO.Nom
            };

            return t;
        }
    }
}
