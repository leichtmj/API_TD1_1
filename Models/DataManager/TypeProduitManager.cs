using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_TD1_1.Models.DataManager
{
    public class TypeProduitManager : IDataRepository<TypeProduit>
    {
        readonly ProduitDbContext produitdbcontext;

        public TypeProduitManager()
        {
        }

        public TypeProduitManager(ProduitDbContext context)
        {
            produitdbcontext = context;
        }

        public async Task<ActionResult<IEnumerable<TypeProduit>>> GetAllAsync()
        {
            return await produitdbcontext.TypeProduits.ToListAsync();
        }
        public async Task<ActionResult<TypeProduit>> GetByIdAsync(int id)
        {
            return await produitdbcontext.TypeProduits.FirstOrDefaultAsync(ta => ta.IdTypeProduit == id);
        }
        public async Task<ActionResult<TypeProduit>> GetByStringAsync(string str)
        {
            return await produitdbcontext.TypeProduits.FirstOrDefaultAsync(ta => ta.NomTypeProduit.ToUpper() == str.ToUpper());
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
    }
}
