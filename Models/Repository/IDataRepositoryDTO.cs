using API_TD1_1.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository
{
    public interface IDataRepositoryDTO<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
    }
}
