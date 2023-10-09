using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TD1_1.Models.EntityFramework;
using API_TD1_1.Models.Repository;
using API_TD1_1.Models.DTO;

namespace API_TD1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IDataRepository<Produit> dataRepositoryProduit;
        private readonly IDataRepositoryProduitDetailDTO dataRepositoryProduitDetailDTO;
        private readonly IDataRepositoryProduitDTO dataRepositoryProduitDTO;

        public ProduitsController(IDataRepository<Produit> dataRepo, IDataRepositoryProduitDetailDTO dataRepoDetailDTO, IDataRepositoryProduitDTO dataRepoProduitDTO)
        {
            dataRepositoryProduit = dataRepo;
            dataRepositoryProduitDetailDTO = dataRepoDetailDTO;
            dataRepositoryProduitDTO = dataRepoProduitDTO;

        }

        // GET: api/Produit
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProduitDTO>>> GetProduits()
        {
            return await dataRepositoryProduitDTO.GetAllAsync();
        }

        // GET: api/Produit/ById/5
        [HttpGet]
        [Route("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProduitDetailDTO>> GetProduitById(int id)
        {
            var produit = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (produit.Value == null)
            {
                return NotFound();
            }

            return produit;
        }

        // GET: api/Produit/ByNom/example
        [HttpGet]
        [Route("ByNom/{str}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProduitDetailDTO>> GetProduitByString(string str)
        {
            var produit = await dataRepositoryProduitDetailDTO.GetByStringAsync(str);

            if (produit.Value == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutProduit(int id, ProduitDetailDTO produit)
        {
            if (id != produit.Id)
            {
                return BadRequest();
            }

//faire un getbyid interne
            var accToUpdate = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (accToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepositoryProduit.UpdateAsync(accToUpdate.Value, produit);
                return NoContent();
            }
        }

        // POST: api/Produit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await dataRepository.AddAsync(produit);
            return CreatedAtAction("GetProduitById", new { id = produit.IdProduit }, produit);
        }

        // DELETE: api/Produit/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await dataRepository.GetByIdAsync(id);

            if (produit.Value == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(produit.Value);
            return NoContent();
        }
    }
}
