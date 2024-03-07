using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Notas_Aluno.DTO;

namespace Api_Notas_Aluno.DAL.IRepository
{
    public interface INotaRepository
    {
        Task<DTOResposta> BuscarTodasNotas(); // Buscar todas as notas de todos os alunos

        Task<DTOResposta> BuscarNotasPorCurso(); // Buscar notas por curso

        Task<DTOResposta> BuscarNotasPorNomeAluno(string nomeAluno); // Buscar notas por nome do aluno

        Task<DTOResposta> BuscarNotasPorDisciplina(string disciplina); // Buscar notas por disciplina

        Task<DTOResposta> CadastrarProva(int idAluno);
        // Cadastrar uma nova prova para um aluno
    }
}
