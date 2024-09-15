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

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                produtoService.Excluir(id);
                return NotFound("Produto não encontrado.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}