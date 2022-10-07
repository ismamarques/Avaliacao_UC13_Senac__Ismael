using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using CadastroAluno.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunoTest
{
    public class AlunoControllerTest
    {//  
        Mock<IAlunoRepository> _repository;
        Aluno alunoValido;
        Aluno alunoValido2;

        public AlunoControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
            alunoValido = new Aluno()
            {
                Id = 1,
                Nome = "Nome",
                Media = 8,
                Turma = "Turma 1"
            };
            alunoValido2 = new Aluno()
            {
                Id = -2,
                Nome = "",
                Media = 11,
                Turma = ""
            };
        }

        [Fact]
        public void Executa_Acao_RetornaOkAction()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Chama uma vex Repo")]

        public void ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);
            controller.Index();
            

            _repository.Verify(repo => repo.Index(), Times.Once);
        }
        [Fact(DisplayName = "Não  existe o aluno NotFound")]
        public void AlunoNaoExisteNotFound()
        {

            AlunosController controller = new AlunosController
                (
                     _repository.Object
                );


            _repository.Setup(repo => repo.Details(1)).Returns
                (
                     alunoValido
                );

            var consulta = controller.Create(2);
            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact(DisplayName = "Aluno Não Existe BadRequest")]
        public void AlunoNaoExiste_RetornBadRequest()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            var consulta = controller.Create(-1);
            
            Assert.IsType<BadRequestResult>
                (
                    consulta
                );
        }

        [Fact(DisplayName = "Chama Repo 1 Vez")]
        public void DetalhesChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(repo => repo.Details(1));
            controller.Create(1);
           
            _repository.Verify(repo => repo.Details(1), Times.Once);
        }

        [Fact(DisplayName = "Detalhes Retorna View Result")]
        public void RetornaViewResul()

        {
            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);
            var result = controller.Create(1);
            Assert.IsType<ViewResult>(result);
        }


        [Fact(DisplayName = "Criar Retorna ViewResult")]
        public void ExecutaAcao_RetornaViewResultSempre()
        {

            AlunosController controller = new AlunosController(_repository.Object);
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            var result = controller.Create(alunoValido);
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact(DisplayName = "[HttpPost] Create() ou RedirectToAction ")]
        public void ValidaDados_RetornaResposta()
        {   

            AlunosController controller = new AlunosController(_repository.Object);
            
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            var result = controller.Create(alunoValido);
            

            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact(DisplayName = " Redireciona para Ação ")]
        public void ValidaDados_RetornaResposta_NEgativo()

        {   

            AlunosController controller = new AlunosController(_repository.Object);
            

            _repository.Setup(repo => repo.Create(alunoValido2)).Returns(alunoValido2);
            var result = controller.Create(alunoValido2);
           


            _repository.Verify(repo => repo.Create(alunoValido2), Times.Once);
            Assert.IsType<ViewResult>(result);
        }


    }

}