using API_TD1_1.Models.DTO;
using API_TD1_1.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository.TypeProduitRepository
{
    public interface IDataRepositoryTypeProduitDTO
    {
        Task<ActionResult<IEnumerable<TypeProduitDTO>>> GetAllAsync();
        Task<ActionResult<TypeProduitDTO>> GetByIdAsync(int id);
        Task<ActionResult<TypeProduitDTO>> GetByStringAsync(string str);
        Task<TypeProduit> MapMarqueDtoToMarque(TypeProduitDTO marqueDTO);
    }
}
