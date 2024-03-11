using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Notas_Aluno.DTO;

namespace Api_Notas_Aluno.DAL.IRepository
{
    public interface INotaRepository
    {
        Task<DTOResposta> BuscarTodasNotas(); // Buscar todas as notas de todos os alunos

        Task<DTOResposta> BuscarNotasPorCurso(string Nomecurso); // Buscar notas por curso

        Task<DTOResposta> BuscarNotasPorNomeAluno(string nomeAluno); // Buscar notas por nome do aluno

        Task<DTOResposta> BuscarNotasPorDisciplina(string disciplina); // Buscar notas por disciplina

        Task<DTOResposta> CadastrarProva(int idAluno, decimal P1, decimal P2, decimal Pt, string Trimestre, int idDisciplina, int IdClasse);
        // Cadastrar uma nova prova para um aluno
         Task<DTOResposta> AtualizarProva(int idProva, decimal P1, decimal P2, decimal Pt, string Trimestre);
        Task<DTOResposta> DeletarProva(int idProva);
    }
}
