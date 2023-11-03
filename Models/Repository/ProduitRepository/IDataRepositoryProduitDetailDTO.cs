using API_TD1_1.Models.DTO;
using API_TD1_1.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository.ProduitRepository
{
    public interface IDataRepositoryProduitDetailDTO
    {
        Task<ActionResult<ProduitDetailDTO>> GetByIdAsync(int id);
        Task<ActionResult<ProduitDetailDTO>> GetByStringAsync(string str);
        Task<Produit> MapDetailDtoToProduit(ProduitDetailDTO produitDetailDTO);
    }
}
