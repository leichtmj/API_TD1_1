using API_TD1_1.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository.ProduitRepository
{
    public interface IDataRepositoryProduitDTO
    {
        Task<ActionResult<IEnumerable<ProduitDTO>>> GetAllAsync();
    }
}
