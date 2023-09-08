using Microsoft.AspNetCore.Mvc;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Domain.Services.Facade;
using Rede.Varejista.Repository;

namespace Rede.Varejista.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaCommandServiceFacade _categoriaCommandServiceFacade;

        private readonly CategoriaQueryServiceFacade _categoriaQueryServiceFacade;

        public CategoriasController(CategoriaCommandServiceFacade categoriaCommandServiceFacade, CategoriaQueryServiceFacade categoriaQueryServiceFacade)
        {
            this._categoriaCommandServiceFacade = categoriaCommandServiceFacade;
            this._categoriaQueryServiceFacade = categoriaQueryServiceFacade; 
        }

        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            try
            {
                return this._categoriaQueryServiceFacade.Listar();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Categoria> Get(string id)
        {
            try
            {
                var categoria = this._categoriaQueryServiceFacade.Obter(id);

                if (categoria is null)
                {
                    return NotFound();
                }

                return categoria;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(Categoria novaCategoria)
        {
            try
            {
                this._categoriaCommandServiceFacade.Adicionar(novaCategoria);
                return CreatedAtAction(nameof(Get), new { id = novaCategoria.Id }, novaCategoria);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Categoria atualizacaoCategoria)
        {
            try
            {
                var categoria = this._categoriaQueryServiceFacade.Obter(id);

                if (categoria is null)
                {
                    return NotFound();
                }

                atualizacaoCategoria.Id = categoria.Id;

                this._categoriaCommandServiceFacade.Atualizar(id, atualizacaoCategoria);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var categoria = this._categoriaQueryServiceFacade.Obter(id);

                if (categoria is null)
                {
                    return NotFound();
                }

                this._categoriaQueryServiceFacade.Deletar(id);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}