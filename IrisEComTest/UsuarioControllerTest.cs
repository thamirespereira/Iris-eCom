using IrisECom.Controllers;
using IrisECom.Models;
using IrisECom.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisEComTest
{
    public class UsuarioControllerTest
    {
        private readonly RestClient restClient;

        public UsuarioControllerTest()
        {
            restClient = new RestClient("https://localhost:7178/api/Usuario");
        }

        [Fact]
        public void BuscarTodosTest()
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.BuscarTodos())
                        .Returns(GetTestUsuarios());

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.BuscarTodos();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Usuario>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        } 

        //Função auxiliar
        private List<Usuario> GetTestUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "Thamires" }
               
            };
        }

        [Theory]
        [InlineData(1)]
        public void BuscarPorIdTest(int id)
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.BuscarPorId(id))
                        .Returns(GetUsuarioPorId(id));

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.BuscarPorId(id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Usuario>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Theory]
        [InlineData(10)]
        public void BuscarPorIdNotFoundTest(int id)
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.BuscarPorId(id))
                        .Returns((Usuario)null);

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.BuscarPorId(id);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Usuário não encontrado.", notFoundResult.Value);
        }

        //Função auxiliar
        private Usuario GetUsuarioPorId(int id)
        {
            return new Usuario { Id = id, Nome = "Thamires" };
        }

        [Theory]
        [InlineData("thamiresemail.com")]
        public void BuscarPorEmailTest(string email)
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.BuscarPorEmail(email))
                        .Returns(GetUsuarioPorEmail(email));

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.BuscarPorEmail(email);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Usuario>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        }

        //Função auxiliar
        private List<Usuario> GetUsuarioPorEmail(string email)
        {
            return new List<Usuario>
                {
                new Usuario { Id = 1, Email = email },
                };
        }

        [Fact]
        public void InserirUsuarioTest()
        {
            // Arrange
            var usuario = new Usuario { Id = 5, Nome = "Nanda" };
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.Inserir(usuario))
                        .Returns((usuario.Id));

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.Inserir(usuario);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Usuario>(okResult.Value);
            Assert.Equal(5, returnValue.Id);
            Assert.Equal("Nanda", returnValue.Nome);
        }

        [Fact]
        public void AtualizarUsuarioTest()
        {
            // Arrange
            var usuario = new Usuario { Id = 5, Nome = "Fernanda" };
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.Atualizar(usuario))
                        .Returns((usuario.Id));

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.Atualizar(usuario);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Usuario>(okResult.Value);
            Assert.Equal(5, returnValue.Id);
            Assert.Equal("Fernanda", returnValue.Nome);
        }

        [Theory]
        [InlineData(5)]
        public void ExcluirUsuarioTest(int id)
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.Excluir(id))
                        .Returns((id));

            //Act
            var controller = new UsuarioController(mockService.Object);

            var result = controller.Excluir(id);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Usuário não encontrado.", notFoundResult.Value);

        }
    }
}
