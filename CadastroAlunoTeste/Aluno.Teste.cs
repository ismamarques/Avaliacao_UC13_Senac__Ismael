using CadastroAluno.Models;
using System;
using Xunit;

namespace CadastroAluno.Test
{
    public class AlunosTest
    {
        //Cliente cliente = new Cliente("José da Silva", new DateTime(2000, 06, 15), "josesilva@mail.com");

        [Fact]
        public void Idade_VinteAnosDepois_RetornaVinte()
        {
            //Arrange
            Alunos cliente = new Alunos("José da Silva", DateTime.Now.AddYears(-20), "josesilva@mail.com");

            //Act
            var idade = aluno.Idade();

            //Assert
            Assert.Equal(20, idade);
        }

        [Fact]
        public void Idade_VinteAnosEUmDiaDepois_RetornaVinte()
        {
            //Arrange
            Alunos aluno = new Alunos("José da Silva", DateTime.Now.AddYears(-20).AddDays(-1), "josesilva@mail.com");

            //Act
            var idade = aluno.Idade();

            //Assert
            Assert.Equal(20, idade);
        }

        [Fact]
        public void Idade_VinteAnosMenosUmDia_RetornaDezenove()
        {
            //Arrange
            Alunos aluno = new Alunos("José da Silva", DateTime.Now.AddYears(-20).AddDays(1), "josesilva@mail.com");

            //Act
            var idade = aluno.Idade();

            //Assert
            Assert.Equal(19, idade);
        }

        [Theory]
        [InlineData("Joao", "2001-06-15", "joaosilva@mail.com")]
        [InlineData("", "2001-06-15", "joaosilva@mail.com")]
        [InlineData("Joao", null, "joaosilva@mail.com")]
        [InlineData("Joao", "2001-06-15", "")]
        public void AtualizaDados_AlteraNomeEmailNascimento_RetornaDezenove(string nome, DateTime nascimento, string email)
        {
            //Arrange
            Alunos cliente = new Alunos("José da Silva", new DateTime(2000, 06, 15), "josesilva@mail.com");

            //Act
            aluno.AtualizaDados(nome, nascimento, email);

            //Assert
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Nascimeto, nascimento);
            Assert.Equal(aluno.Email, email);
        }
    }
}