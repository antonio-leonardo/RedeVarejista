using Microsoft.AspNetCore.Mvc;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Domain.Services.Facade;
using Rede.Varejista.Repository;

namespace Rede.Varejista.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoCommandServiceFacade _produtoCommandServiceFacade;

        private readonly ProdutoQueryServiceFacade _produtoQueryServiceFacade;

        public ProdutosController(ProdutoCommandServiceFacade produtoCommandServiceFacade, ProdutoQueryServiceFacade produtoQueryServiceFacade)
        {
            this._produtoCommandServiceFacade = produtoCommandServiceFacade;
            this._produtoQueryServiceFacade = produtoQueryServiceFacade; 
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            try
            {
                return this._produtoQueryServiceFacade.Listar();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Produto> Get(string id)
        {
            try
            {
                var produto = this._produtoQueryServiceFacade.Obter(id);

                if (produto is null)
                {
                    return NotFound();
                }

                return produto;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(Produto novaProduto)
        {
            try
            {
                this._produtoCommandServiceFacade.Adicionar(novaProduto);
                return CreatedAtAction(nameof(Get), new { id = novaProduto.Id }, novaProduto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Produto atualizacaoProduto)
        {
            try
            {
                var produto = this._produtoQueryServiceFacade.Obter(id);

                if (produto is null)
                {
                    return NotFound();
                }

                atualizacaoProduto.Id = produto.Id;

                this._produtoCommandServiceFacade.Atualizar(id, atualizacaoProduto);

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
                var produto = this._produtoQueryServiceFacade.Obter(id);

                if (produto is null)
                {
                    return NotFound();
                }

                this._produtoQueryServiceFacade.Deletar(id);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}