using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository
{

    public interface IDataRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        Task DeleteAsync(TEntity entity);
    }

}
