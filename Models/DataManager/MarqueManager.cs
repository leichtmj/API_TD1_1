using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;

namespace API_TD1_1.Models.DataManager
{
    public class MarqueManager : IDataRepository<Marque>
    {
        readonly ProduitDbContext produitdbcontext;


        public MarqueManager()
        {
        }

        public MarqueManager(ProduitDbContext context)
        {
            produitdbcontext = context;
        }

        public async Task<ActionResult<IEnumerable<Marque>>> GetAllAsync()
        {
            return await produitdbcontext.Marques.ToListAsync();
        }
        public async Task<ActionResult<Marque>> GetByIdAsync(int id)
        {
            return await produitdbcontext.Marques.FirstOrDefaultAsync(ta => ta.IdMarque == id);
        }
        public async Task<ActionResult<Marque>> GetByStringAsync(string str)
        {
            return await produitdbcontext.Marques.FirstOrDefaultAsync(ta => ta.NomMarque.ToUpper() == str.ToUpper());
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
    }
}
