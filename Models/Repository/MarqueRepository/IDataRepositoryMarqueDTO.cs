using API_TD1_1.Models.DTO;
using API_TD1_1.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace API_TD1_1.Models.Repository.MarqueRepository
{
    public interface IDataRepositoryMarqueDTO
    {
        Task<ActionResult<IEnumerable<MarqueDTO>>> GetAllAsync();
        Task<ActionResult<MarqueDTO>> GetByIdAsync(int id);
        Task<ActionResult<MarqueDTO>> GetByStringAsync(string str);
        Task<Marque> MapMarqueDtoToMarque(MarqueDTO marqueDTO);
    }
}
