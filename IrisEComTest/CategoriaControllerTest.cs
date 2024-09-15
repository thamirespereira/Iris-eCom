using RestSharp;
using IrisECom.Controllers;
using IrisECom.Services;
using IrisECom.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace IrisEComTest
{
    public class CategoriaControllerTest
    {
        private readonly RestClient restClient;

        public CategoriaControllerTest()
        {
            restClient = new RestClient("https://localhost:7178/api/Categoria");
        }

        /// <summary>
        /// Deve retornar uma lista com as categorias Hardware e Periféricos
        /// </summary>
        [Fact]
        public void BuscarTodosTest()
        {
            // Arrange
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.BuscarTodos())
                        .Returns(GetTestCategorias());

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.BuscarTodos();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Categoria>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        //Função auxiliar
        private List<Categoria> GetTestCategorias()
        {
            return new List<Categoria>
            {
                new Categoria { Id = 1, Nome = "Hardware" },
                new Categoria { Id = 2, Nome = "Periféricos" }
            };
        }

        /// <summary>
        /// Deve retornar a categoria com id 1
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(1)]
        public void BuscarPorIdTest(int id)
        {
            // Arrange
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.BuscarPorId(id))
                        .Returns(GetCategoriaPorId(id));

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.BuscarPorId(id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Categoria>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
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
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.BuscarPorId(id))
                        .Returns((Categoria)null);

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.BuscarPorId(id);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Categoria não encontrada.", notFoundResult.Value);
        }

        //Função auxiliar
        private Categoria GetCategoriaPorId(int id)
        {
            return new Categoria { Id = id, Nome = "Hardware" };
        }

        /// <summary>
        /// Deve retornar duas categorias, Hardware e Periféricos
        /// </summary>
        /// <param name="nome"></param>
        [Theory]
        [InlineData("Hardware")]
        [InlineData("Periféricos")]
        public void BuscarPorNomeTest(string nome)
        {
            // Arrange
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.BuscarPorNome(nome))
                        .Returns(GetCategoriaPorNome(nome));

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.BuscarPorNome(nome);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Categoria>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        //Função auxiliar
        private List<Categoria> GetCategoriaPorNome(string nome)
        {
            return new List<Categoria>
                {
                new Categoria { Id = 1, Nome = nome },
                new Categoria { Id = 2, Nome = nome }
                };
        }

        /// <summary>
        /// Deve inserir uma categoria com Id 5 e Nome Smartphone
        /// </summary>
        [Fact]
        public void InserirCategoriaTest()
        {
            // Arrange
            var categoria = new Categoria { Id = 5, Nome = "Smartphone" };
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.Inserir(categoria))
                        .Returns((categoria.Id));

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.Inserir(categoria);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Categoria>(okResult.Value);
            Assert.Equal(5, returnValue.Id);
            Assert.Equal("Smartphone", returnValue.Nome);
        }

        /// <summary>
        /// Deve atualizar o nome da categoria com Id 5 para Celular
        /// </summary>
        [Fact]
       public void AtualizarCategoriaTest()
        {
            // Arrange
            var categoria = new Categoria { Id = 5, Nome = "Celular" };
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.Atualizar(categoria))
                        .Returns((categoria.Id));

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.Atualizar(categoria);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<Categoria>(okResult.Value);
            Assert.Equal(5, returnValue.Id);
            Assert.Equal("Celular", returnValue.Nome);
        }

        /// <summary>
        /// Deve retornar Not Found
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData(5)]
        public void ExcluirCategoriaTest(int id)
        {
            // Arrange
            var mockService = new Mock<ICategoriaService>();
            mockService.Setup(service => service.Excluir(id))
                        .Returns((id));

            //Act
            var controller = new CategoriaController(mockService.Object);

            var result = controller.Excluir(id);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Categoria não encontrada. A categoria foi excluída.", notFoundResult.Value);
            
        }
    }
}
