using IrisECom.Models;
using IrisECom.Repositories;
using IrisECom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IrisECom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutoRepository produtoRepository;

        private readonly IProdutoService produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        /// <summary>
        /// Busca todos os produtos
        /// </summary>
        /// <returns>Uma lista com todos os produtos</returns>
        /// <response code="200">Produto</response>
        /// <response code="500">ex.Message</response>
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var produtos = produtoService.BuscarTodos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// Busca um produto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um produto</returns>
        /// <response code="200">Produto</response>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="500">ex.Message</response>
        [HttpGet("/BuscaPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var produto = produtoService.BuscarPorId(id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado.");
                }
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Busca produto por nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma lista de produtos que contenham o nome pesquisado</returns>
        /// <response code="200">Produto</response>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="500">ex.Message</response>
        [HttpGet("/BuscaPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            { 
                var produtos = produtoService.BuscarPorNome(nome);
                if (!produtos.Any())
                {
                    return NotFound("Produto não encontrado.");
                }
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Busca produtos por categoria
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>Uma lista de produtos com a mesma categoria</returns>
        /// <response code="200">Produtos</response>
        /// <response code="404">Categoria não encontrada</response>
        /// <response code="500">ex.Message</response>
        [HttpGet("/BuscaPorCategoria/{codigo}")]
        public IActionResult BuscarPorCategoria(int codigo)
        {
            try
            {
                var produtos = produtoService.BuscarPorCategoria(codigo);
                if (produtos == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>O produto criado</returns>
        /// <response code="200">Produto</response>
        /// <response code="500">ex.Message</response>
        [HttpPost]
        public IActionResult Inserir([FromBody] Produto produto)
        {
            try
            {
                produtoService.Inserir(produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>O produto atualizado</returns>
        /// <response code="200">Produto</response>
        /// <response code="500">ex.Message</response>
        [HttpPut]
        public IActionResult Atualizar(Produto produto)
        {
            try
            {
                produtoService.Atualizar(produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Apaga um produto por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma mensagem de produto não encontrado</returns>
        /// <response code="404">Produto não encontrado. O produto foi excluído.</response>
        /// <response code="500">ex.Message</response>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                produtoService.Excluir(id);
                return NotFound("Produto não encontrado. O produto foi excluído.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}