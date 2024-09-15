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

        /// <summary>
        /// Busca todas as categorias
        /// </summary>
        /// <returns>Uma lista com todas as categorias</returns>
        /// <response code="200">Categorias</response>
        /// <response code="500">ex.Message</response>
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

        /// <summary>
        /// Busca categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A categoria pesquisada</returns>
        /// <response code="200">Categoria</response>
        /// <response code="404">Categoria não encontrada</response>
        /// <response code="500">ex.Message</response>
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

        /// <summary>
        /// Busca categoria pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Uma lista de categorias que contenham o nome pesquisado </returns>
        /// <response code="200">Categorias</response>
        /// <response code="404">Categoria não encontrada</response>
        /// <response code="500">ex.Message</response>
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

        /// <summary>
        /// Cria uma categoria nova
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>A categoria criada</returns>
        /// <response code="200">Categoria</response>
        /// <response code="500">ex.Message</response>
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

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>A categoria atualizada</returns>
        /// <response code="200">Categoria</response>
        /// <response code="500">ex.Message</response>
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

        /// <summary>
        /// Exclui uma categoria por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma mensagem de categoria não encontrada</returns>
        /// <response code="404">Categoria não encontrada. A categoria foi excluída.</response>
        /// <response code="500">ex.Message</response>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                categoriaService.Excluir(id);
                return NotFound("Categoria não encontrada. A categoria foi excluída.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}