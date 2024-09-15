using IrisECom.Models;
using IrisECom.Repositories;
using IrisECom.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IrisECom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        /// <returns>Uma lista com todos os usuérios cadastrados</returns>
        /// <response code="200">Usuários</response>
        /// <response code="404">Nenhum usuário encontrado</response>
        /// <response code="500">ex.Message</response>
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var usuarios = usuarioService.BuscarTodos();

                if (!usuarios.Any())
                {
                    return NotFound("Nenhum usuário encontrado.");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Busca um usuário por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuário encontrado</returns>
        /// <response code="200">Usuário</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">ex.Message</response>
        [HttpGet("/buscarId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var usuario = usuarioService.BuscarPorId(id);
                if(usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Busca um usuário por email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Um usuário</returns>
        /// <response code="200">Usuário</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">ex.Message</response>
        [HttpGet("/buscarEmail/{email}")]
        public IActionResult BuscarPorEmail(string email)
        {
            try
            {
                var usuario = usuarioService.BuscarPorEmail(email);
                if(usuario == null)
                {
                    return NotFound("Usuário não encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>O usuário criado</returns>
        /// <response code="200">Usuário</response>
        /// <response code="400">Usuário já cadastrado</response>
        /// <response code="500">ex.Message</response>
        [HttpPost]
        public IActionResult Inserir([FromBody] Usuario usuario)
        {
            try
            {
                if (usuarioService.BuscarPorEmail(usuario.Email) != null)
                {
                    return BadRequest("Usuário já cadastrado.");
                }
                usuarioService.Inserir(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados do usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>O usuário atualizado</returns>
        /// <response code="200">Usuário</response>
        /// <response code="500">ex.Message</response>
        [HttpPut]
        public IActionResult Atualizar(Usuario usuario)
        {
            try
            {
                usuarioService.Atualizar(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Exclui um usuário por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Uma mensagem de usuário não encontrado</returns>
        /// <response code="404">Usuário não encontrado. O usuário foi excluído.</response>
        /// <response code="500">ex.Message</response>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var numLinhas = usuarioService.Excluir(id);
                return NotFound("Usuário não encontrado. O usuário foi excluído.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}