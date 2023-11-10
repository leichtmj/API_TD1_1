using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using API_TD1_1.Models.Repository.MarqueRepository;
using API_TD1_1.Models.Repository.TypeProduitRepository;
using API_TD1_1.Models.DTO;

namespace API_TD1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProduitsController : ControllerBase
    {
        private readonly IDataRepository<TypeProduit> dataRepository;
        private readonly IDataRepositoryTypeProduitDTO dataRepositoryTypeDTO;


        public TypeProduitsController(IDataRepository<TypeProduit> dataRepo, IDataRepositoryTypeProduitDTO typeProduitDTO)
        {
            dataRepository = dataRepo;
            dataRepositoryTypeDTO = typeProduitDTO;
        }

        // GET: api/Produit
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TypeProduitDTO>>> GetTypes()
        {
            return await dataRepositoryTypeDTO.GetAllAsync();
        }

        // GET: api/Produit/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProduitDTO>> GetTypeById(int id)
        {
            var type = await dataRepositoryTypeDTO.GetByIdAsync(id);

            if (type.Value == null)
            {
                return NotFound();
            }

            return type;
        }

        // GET: api/Produit/ByNom/example
        [HttpGet]
        [Route("ByNom/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProduitDTO>> GetTypeByString(string str)
        {
            var type = await dataRepositoryTypeDTO.GetByStringAsync(str);

            if (type.Value == null)
            {
                return NotFound();
            }

            return type;
        }

        // PUT: api/Produit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutType(int id, TypeProduit type)
        {
            if (id != type.IdTypeProduit)
            {
                return BadRequest();
            }

            var typeToUpdate = await dataRepositoryTypeDTO.GetByIdAsync(id);

            if (typeToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                var mappedTypeToUpdate = await dataRepositoryTypeDTO.MapMarqueDtoToMarque(typeToUpdate.Value);
                await dataRepository.UpdateAsync(mappedTypeToUpdate, type);
                return NoContent();
            }
        }

        // POST: api/Produit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProduit>> PostType(TypeProduit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(produit);
            return CreatedAtAction("GetTypeById", new { id = produit.IdTypeProduit }, produit);
        }

        // DELETE: api/Produit/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteType(int id)
        {
            var type = await dataRepositoryTypeDTO.GetByIdAsync(id);

            if (type.Value == null)
            {
                return NotFound();
            }

            var mappedType = await dataRepositoryTypeDTO.MapMarqueDtoToMarque(type.Value);
            await dataRepository.DeleteAsync(mappedType);
            return NoContent();
        }
    }
}
