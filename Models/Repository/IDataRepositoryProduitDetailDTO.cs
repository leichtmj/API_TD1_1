using API_TD1_1.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository
{
    public interface IDataRepositoryProduitDetailDTO
    {
        Task<ActionResult<ProduitDetailDTO>> GetByIdAsync(int id);
        Task<ActionResult<ProduitDetailDTO>> GetByStringAsync(string str);
    }
}
