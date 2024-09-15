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

        /// <summary>
        /// Deve retornar uma lista com os produtos com id 3 e 5
        /// </summary>
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

        /// <summary>
        /// Deve retornar o produto com Id 3
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Deve retornar Not Found
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Deve retornar o produto com nome Monitor
        /// </summary>
        /// <param name="nome"></param>
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

        /// <summary>
        /// Deve retornar o produto com id 2
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Deve inserir o produto Teclado com Id 6 e retornar o valor inserido
        /// </summary>
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

        /// <summary>
        /// Deve atualizar e retornar o produto com Id 6 e nome Teclado RGB
        /// </summary>
        [Fact]
        public void AtualizarProdutoTest()
        {
            // Arrange
            var produto = new Produto { Id = 6, Nome = "Teclado RGB" };
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.Atualizar(produto))
                        .Returns((produto.Id));

            //Act
            var controller = new ProdutoController(mockService.Object);

            var result = controller.Atualizar(produto);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Produto>(okResult.Value);
            Assert.Equal(6, returnValue.Id);
            Assert.Equal("Teclado RGB", returnValue.Nome);
        }

        /// <summary>
        /// Deve excluir o produto e retornar Produto não encontrado. O produto foi excluído.
        /// </summary>
        /// <param name="id"></param>
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
            Assert.Equal("Produto não encontrado. O produto foi excluído.", notFoundResult.Value);

        }
    }
}
