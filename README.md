# Avaliacao_UC13_Senac__Ismael

Etapa 2 - Escrita de testes
Escreva testes para a model Aluno 
    R: ok , testes escritos ModelAluno


O método AtualizarDados() deve alterar as propriedades Nome e Turma com sucesso, independente dos dados passados.
    R:ok, 6 dados alterados com sucesso.



O método VerificaAprovacao() deve retornar VERDADEIRO se, e somente se a média for maior ou igual a 5.
    R:Teste feito , porem da erro pois quando a média é igual a 5 o teste da falso.



O método AtualizaMedia() deve atualizar a propriedade Media com o novo valor recebido.
    R: teste realizado 5 ok's


Anote quais as inconsistências encontradas na model Aluno, mas não a corrija ainda.
    R: Ao executar todos os testes foi encontrado erro no teste VerificaAprovação_MediaMaior , quando a mesma é exatamente
igual ao valor 5 .

Escreva testes para a controller AlunosController
O método Index() deve retornar um ViewResult, contendo ou não registros no banco.
        R: ok , retornando com registros no banco
        
        
O método Index() deve retornar chamar o repositório apenas uma vez.






