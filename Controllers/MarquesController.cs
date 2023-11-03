using Microsoft.AspNetCore.Mvc;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using API_TD1_1.Models.Repository.MarqueRepository;
using API_TD1_1.Models.DTO;

namespace API_TD1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarquesController : ControllerBase
    {
        private readonly IDataRepository<Marque> dataRepository;
        private readonly IDataRepositoryMarqueDTO dataRepositoryMarqueDTO;

        public MarquesController(IDataRepository<Marque> dataRepo, IDataRepositoryMarqueDTO dataRepoMarqueDTO)
        {
            dataRepository = dataRepo;
            dataRepositoryMarqueDTO = dataRepoMarqueDTO;
        }

        // GET: api/Marque
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MarqueDTO>>> GetMarques()
        {
            return await dataRepositoryMarqueDTO.GetAllAsync();
        }

        // GET: api/Marque/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MarqueDTO>> GetMarqueById(int id)
        {
            var marque = await dataRepositoryMarqueDTO.GetByIdAsync(id);

            if (marque.Value == null)
            {
                return NotFound();
            }

            return marque;
        }

        // GET: api/Marque/ByNom/example
        [HttpGet]
        [Route("ByNom/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MarqueDTO>> GetMarqueByString(string str)
        {
            var marque = await dataRepositoryMarqueDTO.GetByStringAsync(str);

            if (marque.Value == null)
            {
                return NotFound();
            }

            return marque;
        }

        // PUT: api/Marque/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMarque(int id, MarqueDTO marque)
        {
            if (id != marque.Id)
            {
                return BadRequest();
            }
            var mappedMarque = await dataRepositoryMarqueDTO.MapMarqueDtoToMarque(marque);

            var marqueToUpdate = await dataRepositoryMarqueDTO.GetByIdAsync(id);

            if (marqueToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                var mappedMarqueToUpdate = await dataRepositoryMarqueDTO.MapMarqueDtoToMarque(marqueToUpdate.Value);
                await dataRepository.UpdateAsync(mappedMarqueToUpdate, mappedMarque);
                return NoContent();
            }
        }

        // POST: api/Marque
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Marque>> PostMarque(MarqueDTO marque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mappedMarque = await dataRepositoryMarqueDTO.MapMarqueDtoToMarque(marque);
            await dataRepository.AddAsync(mappedMarque);
            return CreatedAtAction("GetMarqueById", new { id = mappedMarque.IdMarque }, mappedMarque);
        }

        // DELETE: api/Marque/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMarque(int id)
        {
            var marque = await dataRepositoryMarqueDTO.GetByIdAsync(id);

            if (marque.Value == null)
            {
                return NotFound();
            }

            var mappedMarque = await dataRepositoryMarqueDTO.MapMarqueDtoToMarque(marque.Value);
            await dataRepository.DeleteAsync(mappedMarque);
            return NoContent();
        }
    }
}