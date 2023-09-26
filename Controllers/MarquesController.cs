using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;

namespace API_TD1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarquesController : ControllerBase
    {
        private readonly IDataRepository<Marque> dataRepository;

        public MarquesController(IDataRepository<Marque> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Marque
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Marque>>> GetMarques()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Marque/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Marque>> GetMarqueById(int id)
        {
            var marque = await dataRepository.GetByIdAsync(id);

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
        public async Task<ActionResult<Marque>> GetMarqueByString(string str)
        {
            var marque = await dataRepository.GetByStringAsync(str);

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
        public async Task<IActionResult> PutMarque(int id, Marque marque)
        {
            if (id != marque.IdMarque)
            {
                return BadRequest();
            }

            var accToUpdate = await dataRepository.GetByIdAsync(id);

            if (accToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(accToUpdate.Value, marque);
                return NoContent();
            }
        }

        // POST: api/Marque
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Marque>> PostMarque(Marque marque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(marque);
            return CreatedAtAction("GetMarqueById", new { id = marque.IdMarque }, marque);
        }

        // DELETE: api/Marque/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMarque(int id)
        {
            var marque = await dataRepository.GetByIdAsync(id);

            if (marque.Value == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(marque.Value);
            return NoContent();
        }
    }
}
