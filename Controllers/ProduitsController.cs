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
using AutoMapper;


namespace API_TD1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        private readonly IDataRepository<Produit> dataRepositoryProduit;
        private readonly IDataRepositoryDetailDTO<ProduitDetailDTO> dataRepositoryProduitDetailDTO;
        private readonly IDataRepositoryDTO<ProduitDTO> dataRepositoryProduitDTO;
        private readonly IMapper _mapper;


        public ProduitsController(IDataRepository<Produit> dataRepo, IDataRepositoryDetailDTO<ProduitDetailDTO> dataRepoDetailDTO, IDataRepositoryDTO<ProduitDTO> dataRepoProduitDTO, IMapper mapper)
        {
            dataRepositoryProduit = dataRepo;
            dataRepositoryProduitDetailDTO = dataRepoDetailDTO;
            dataRepositoryProduitDTO = dataRepoProduitDTO;
            _mapper = mapper;

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
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.IdProduit)
            {
                return BadRequest();
            }

            var prodToUpdate = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (prodToUpdate.Value == null)
            {
                return NotFound();
            }
            else
            {
                var produitToUpdate = _mapper.Map<ProduitDetailDTO, Produit>(prodToUpdate.Value);
                await dataRepositoryProduit.UpdateAsync(produitToUpdate, produit);
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
            await dataRepositoryProduit.AddAsync(produit);

            return CreatedAtAction("GetProduitById", new { id = produit.IdProduit }, produit);
        }

        // DELETE: api/Produit/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await dataRepositoryProduitDetailDTO.GetByIdAsync(id);

            if (produit.Value == null)
            {
                return NotFound();
            }

            //var produitToDelete = _mapper.Map<ProduitDetailDTO, Produit>(produit.Value);

            Produit p = new Produit
            {
                IdProduit = produit.Value.Id
            };

            await dataRepositoryProduit.DeleteAsync(p);
            return NoContent();
        }
    }
}