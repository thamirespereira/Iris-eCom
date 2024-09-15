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
    public class ProdutoControllerTest
    {
        private readonly RestClient restClient;

        public ProdutoControllerTest()
        {
            restClient = new RestClient("https://localhost:7178/api/Produto");
        }

        [Fact]
        public void BuscarTodosTest()
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.BuscarTodos())
                        .Returns(GetTestProdutos());

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.BuscarTodos();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        //Função auxiliar
        private List <Produto> GetTestProdutos()
        {
            return new List<Produto>
            {
                new Produto { Id = 3, Nome = "Notebook Inspiron 15" },
                new Produto { Id = 5, Nome = "Monitor Led" }

            };
        }

        [Theory]
        [InlineData(3)]
        public void BuscarPorIdTest(int id)
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.BuscarPorId(id))
                        .Returns(GetProdutoPorId(id));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.BuscarPorId(id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Produto>(okResult.Value);
            Assert.Equal(3, returnValue.Id);
        }

        [Theory]
        [InlineData(10)]
        public void BuscarPorIdNotFoundTest(int id)
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.BuscarPorId(id))
                        .Returns((Produto)null);

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.BuscarPorId(id);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Produto não encontrado.", notFoundResult.Value);
        }

        //Função auxiliar
        private Produto GetProdutoPorId(int id)
        {
            return new Produto { Id = id, Nome = "Notebook Inspiron 15" };
        }

        [Theory]
        [InlineData("Monitor")]
        public void BuscarPorNomeTest(string nome)
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.BuscarPorNome(nome))
                        .Returns(GetProdutoPorNome(nome));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.BuscarPorNome(nome);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        }

        //Função auxiliar
        private List<Produto> GetProdutoPorNome(string nome)
        {
            return new List<Produto>
                {
                new Produto { Id = 5, Nome = nome },
                };
        }

        [Theory]
        [InlineData(2)]
        public void BuscarPorCategoriaTest(int id)
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.BuscarPorCategoria(id))
                        .Returns(GetProdutoPorCategoria(id));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.BuscarPorCategoria(id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Produto>>(okResult.Value);
            Assert.Equal(1, returnValue.Count);
        }

        //Função auxiliar
        private List <Produto> GetProdutoPorCategoria(int id)
        {
            return new List<Produto> { new Produto { Id = id, Nome = "Monitor Led" } };
        }

        [Fact]
        public void InserirProdutoTest()
        {
            // Arrange
            var produto = new Produto { Id = 6, Nome = "Teclado" };
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.Inserir(produto))
                        .Returns((produto.Id));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.Inserir(produto);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Produto>(okResult.Value);
            Assert.Equal(6, returnValue.Id);
            Assert.Equal("Teclado", returnValue.Nome);
        }

        [Fact]
        public void AtualizarProdutoTest()
        {
            // Arrange
            var produto = new Produto { Id = 5, Nome = "Teclado RGB" };
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.Atualizar(produto))
                        .Returns((produto.Id));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.Atualizar(produto);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Produto>(okResult.Value);
            Assert.Equal(5, returnValue.Id);
            Assert.Equal("Teclado RGB", returnValue.Nome);
        }

        [Theory]
        [InlineData(6)]
        public void ExcluirProdutoTest(int id)
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.Excluir(id))
                        .Returns((id));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.Excluir(id);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Produto não encontrado.", notFoundResult.Value);

        }
    }
}
