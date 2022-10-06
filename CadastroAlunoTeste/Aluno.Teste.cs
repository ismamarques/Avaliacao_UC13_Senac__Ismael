using Xunit;
using CadastroAluno.Models;



namespace CadastroAlunoTest
{


    public class AlunoTest
    {
        [Theory]
        [InlineData("Ismael", "2")]
        [InlineData("Bruno", "3")]
        [InlineData("J ", "2")]
        [InlineData("Bia", "2")]
        [InlineData("Ana", "2")]
        [InlineData("", " ")]
        [InlineData("", "")]

        // Atualizar Dados 

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



        // Verificar Aprovacao Media Maior

        public void VerificarAprovacao_MediaMaior(int n1)
        {
            Aluno aluno = new Aluno();
            aluno.Media = n1;
            var media = aluno.VerificaAprovacao();
            Assert.True(media);

        }
        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]


        // Atualizar Dados  Media 

        public void AtualizarDados_Media(double novaMedia)

        {
            Aluno aluno = new Aluno();
            aluno.AtualizaMedia(novaMedia);
            Assert.Equal(aluno.Media, novaMedia);
        }
    }
}