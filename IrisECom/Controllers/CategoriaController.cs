using IrisECom.Models;
using IrisECom.Repositories;
using IrisECom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IrisECom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaService;
        private readonly CategoriaRepository categoriaRepository;

        public CategoriaController(ICategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var categorias = categoriaService.BuscarTodos();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var categoria = categoriaService.BuscarPorId(id);
                if (categoria == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/BuscarPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            try
            {
                var categorias = categoriaService.BuscarPorNome(nome);

                if (!categorias.Any())
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Categoria categoria)
        {
            try
            {
                categoriaService.Inserir(categoria);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Categoria categoria)
        {
            try
            {
                categoriaService.Atualizar(categoria);
                return Ok(categoria);
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
                categoriaService.Excluir(id);
                return NotFound("Categoria não encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}