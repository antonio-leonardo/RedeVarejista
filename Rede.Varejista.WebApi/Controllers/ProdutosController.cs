using Microsoft.AspNetCore.Mvc;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Domain.Services.Facade;

namespace Rede.Varejista.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ProdutosController : RedeVarejistaControllerBase
    {
        public ProdutosController(CategoriaCommandServiceFacade categoriaCommandServiceFacade, CategoriaQueryServiceFacade categoriaQueryServiceFacade)
            : base(categoriaCommandServiceFacade, categoriaQueryServiceFacade) { }

        [HttpGet("{idCategoria:length(24)},{idProduto:length(24)}")]
        public ActionResult<Produto> Get(string idCategoria, string idProduto)
        {
            try
            {
                return this._categoriaQueryServiceFacade.Obter(idCategoria).Produtos.Where(p => p.Id == idProduto).FirstOrDefault();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{idCategoria:length(24)}")]
        public ActionResult<List<Produto>> Get(string idCategoria)
        {
            try
            {
                var produtos = this._categoriaQueryServiceFacade.Obter(idCategoria).Produtos.ToList();

                if (produtos is null)
                {
                    return NotFound();
                }

                return produtos;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("{idCategoria:length(24)}")]
        public IActionResult Post(string idCategoria, Produto novoProduto)
        {
            try
            {
                this._categoriaCommandServiceFacade.AdicionarProdutoNumaCategoria(idCategoria, novoProduto);
                return CreatedAtAction(nameof(Get), new { idCategoria = idCategoria, idProduto = novoProduto.Id }, novoProduto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch("{idCategoria:length(24)}")]
        public IActionResult Update(string idCategoria, Produto produtoParaAtualizar)
        {
            try
            {
                var produto = this._categoriaQueryServiceFacade.Obter(idCategoria).Produtos.Where(p => p.Id == produtoParaAtualizar.Id).FirstOrDefault();

                if (produto is null)
                {
                    return NotFound();
                }

                this._categoriaCommandServiceFacade.AlterarProdutoNumaCategoria(idCategoria, produtoParaAtualizar);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{idCategoria:length(24)},{idProduto:length(24)}")]
        public IActionResult Delete(string idCategoria, string idProduto)
        {
            try
            {
                var produto = this._categoriaQueryServiceFacade.Obter(idCategoria).Produtos.Where(x => x.Id == idProduto).FirstOrDefault();

                if (produto is null)
                {
                    return NotFound();
                }

                this._categoriaQueryServiceFacade.DeletarUmProdutoDeUmaCategoria(idCategoria, produto);

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}