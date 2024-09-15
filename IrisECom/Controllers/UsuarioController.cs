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

        [HttpGet("/buscarEmail/{email}")]
        public IActionResult BuscarPorEmail(string email)
        {
            try
            {
                var usuarios = usuarioService.BuscarPorEmail(email);
                if(!usuarios.Any())
                {
                    return NotFound("Usuário não encontrado.");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Usuario usuario)
        {
            try
            {
                if (usuarioService.BuscarPorEmail(usuario.Email).Any())
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

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var numLinhas = usuarioService.Excluir(id);
                return NotFound("Usuário não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}