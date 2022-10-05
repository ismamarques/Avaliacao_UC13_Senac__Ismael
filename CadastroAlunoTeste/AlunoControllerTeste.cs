using Bogus;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CadastroCliente.Test
{
    public class AlunosControllerTest
    {
        Mock<IAlunoRepository> _repository;
        Aluno clienteValido;

        public AlunosControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();

            //clienteValido = new Faker<Cliente>("pt_BR")
            //    .CustomInstantiator(faker => new Cliente
            //    (
            //        faker.Name.FirstName(),
            //        faker.Date.Past(20),
            //        faker.Internet.Email()
            //    ));

            clienteValido = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(faker => new Aluno
                (
                    faker.Name.FirstName(),
                    faker.Date.Past(20),
                    faker.Internet.Email()
                    )
                ).RuleFor(cli => cli.Email, (f, c) => f.Internet.Email(c.Nome, f.Name.LastName()));
        }

        #region Testes Index Positivos

        [Fact]
        public async void GetClientes_ExecutaAcao_RetornaOkStatus()
        {
            //Arrange
            AlunosControllerTest controller = new AlunosControllerTest(_repository.Object);

            //Act
            var clientes = await controller.GetAlunos();

            //Assert
            Assert.IsType<OkObjectResult>(clientes.Result);
        }

        [Fact]
        public async void GetClientes_ExecutaAcao_RetornaArrayClientesCasoExistam()
        {
            //Arrange
            AlunosControllerTest controller = new AlunosControllerTest(_repository.Object);

            var listaDeClientes = new List<Aluno>()
            {
               new Aluno("José", DateTime.Now, "mail@mail.com"),
               new Aluno("Joao", DateTime.Now, "mail@mail.com")
            };

            _repository.Setup(repo => repo.GetClientes())
                .Returns(Task.FromResult(new List<Aluno>()
                {
                    new Aluno("João", DateTime.Now, "mail@mail"),
                    new Aluno("João", DateTime.Now, "mail@mail")
                }));

            //Act
            var result = await controller.GetAlunos();

            //Assert 
            var clientes = Assert.IsType<List<Aluno>>((result.Result as OkObjectResult).Value);
            Assert.Equal(2, clientes.Count);
        }

        [Fact]
        public async void GetCliente_ExecutaAcao_RetornaUmCliente()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);



            _repository.Setup(repo => repo.GetClienteById(1))
                .Returns(Task.FromResult(alunoValido));

            //Act
            var consulta = await controller.GetAluno(1);

            //Assert 
            var clientes = Assert.IsType<Aluno>(consulta.Value);
        }

        #endregion

        #region Teste Index Negativos
        [Fact(DisplayName = "Cliente Inexistente NotFound")]
        public async void GetAluno_ClienteInexistente_RetornaNotFound()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);

            //Act
            var consulta = await controller.GetAluno(1);

            //Assert 
            Assert.IsType<NotFoundResult>(consulta.Result);
        }
        #endregion

        #region Post Aluno Positivos

        [Fact]
        public async void PostAluno_ModelStateValida_ChamaRepositorioUmaVez()
        {
            //Arrange
            var controller = new AlunosController(_repository.Object);

            _repository.Setup(r => r.AddAluno(clienteValido))
                .ReturnsAsync(alunoValido);

            //Act
            await controller.PostAluno(alunoValido);

            //Assert 
            _repository.Verify(repo => repo.AddAluno(alunoValido), Times.Once);
        }


        [Fact]
        public async void PostAluno_ModelStateValida_RetornaCreated()
        {
            //Arrange
            var controller = new AlunosController(_repository.Object);

            _repository.Setup(r => r.AddAluno(clienteValido))
                .ReturnsAsync(alunoValido);

            //Act
            var result = await controller.PostAluno(alunoValido);

            //Assert 
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }
        #endregion

        #region Post Aluno Negativos
        [Fact]
        public async void PostAluno_ModelStateInvalida_NaoChamaRepositorio()
        {
            //Arrange
            var controller = new AlunosController(_repository.Object);
            var aluno = new Aluno("", DateTime.Now, "mail@mail");
            controller.ModelState.AddModelError("", "");

            _repository.Setup(r => r.AddAluno(aluno))
                .ReturnsAsync(aluno);

            //Act
            await controller.PostAluno(aluno);

            //Assert 
            _repository.Verify(repo => repo.AddAluno(aluno), Times.Never);
        }

        #endregion
    }

}