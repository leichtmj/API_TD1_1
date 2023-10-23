using API_TD1_1.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository
{
    public interface IDataRepositoryDetailDTO<TEntity>
    {
        Task<ActionResult<TEntity>> GetByIdAsync(int id);
        Task<ActionResult<TEntity>> GetByStringAsync(string str);
    }
}
