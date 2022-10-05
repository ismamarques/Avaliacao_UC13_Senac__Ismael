using Xunit;
using CadastroAluno.Models;

namespace CadastroAlunoTest
{
    public class AlunoTest
    {
        [Theory]
        [InlineData("Silva", "2")]
        [InlineData("Pedro", "3")]
        [InlineData("R ", "2")]
        [InlineData("Ricardo", "2")]
        [InlineData("Ricardo", "2")]
        [InlineData("", " ")]
        [InlineData("", "")]


        public void AtualizarDados(string nome, string turma)
        {

            Aluno aluno = new Aluno();
            aluno.AtualizarDados(nome, turma);
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]

        public void VerificarAprovacao_MediaMaior(int n1)
        {
            Aluno aluno = new Aluno();
            aluno.Media = n1;
            var media = aluno.VerificaAprovacao();
            Assert.True(media);
        }
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void AtualizarDados_Media(double novaMedia)
        {

            Aluno aluno = new Aluno();
            aluno.AtualizaMedia(novaMedia);
            Assert.Equal(aluno.Media, novaMedia);
        }
    }
}