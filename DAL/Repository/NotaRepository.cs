using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Notas_Aluno.DAL.Database;
using Api_Notas_Aluno.DAL.IRepository;
using Api_Notas_Aluno.DTO;
using Api_Notas_Aluno.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Notas_Aluno.DAL.Repository
{
    public class NotaRepository : INotaRepository
    {
        private readonly NotaAlunoDbContext _notaAlunoDb;

        public NotaRepository(NotaAlunoDbContext notaAlunoDbContext)
        {
            _notaAlunoDb = notaAlunoDbContext;
        }

        public Task<DTOResposta> BuscarNotasPorCurso()
        {
            throw new NotImplementedException();
        }

        public Task<DTOResposta> BuscarNotasPorDisciplina(string disciplina)
        {
            throw new NotImplementedException();
        }

        public Task<DTOResposta> BuscarNotasPorNomeAluno(string nomeAluno)
        {
            throw new NotImplementedException();
        }

        public async Task<DTOResposta> BuscarTodasNotas()
        {
            DTOResposta notas = new DTOResposta();
            try
            {
                var result = from prova in _notaAlunoDb.Provas
                             join aluno in _notaAlunoDb.Alunos on prova.IdAluno equals aluno.Id
                             join dispiplina in _notaAlunoDb.Disciplinas on prova.IdDisciplina equals dispiplina.Id
                             join classe in _notaAlunoDb.Classes on prova.IdClasse equals classe.Id
                             join classecurso in _notaAlunoDb.CursoClasses on classe.Id equals classecurso.IdClasse
                             join curso in _notaAlunoDb.Cursos on classecurso.IdCurso equals curso.Id
                             select new
                             {
                                 Aluno = aluno,
                                 Classe = classe.classe,
                                 Curso = curso.curso,
                                 dispiplina = dispiplina.DisciplinaNome,
                                 Trimestre = prova.Trimestre,
                                 P1 = prova.P1,
                                 P2 = prova.P2,
                                 Pt = prova.Pt,
                                 Media = prova.Mdf,
                             };

                notas.resposta = result;
                notas.mensagem = "Notas de Todos os Alunos";
            }
            catch (System.Exception ex)
            {
                notas.mensagem = ex.ToString();
            }
            return notas;
        }

        public Task<DTOResposta> CadastrarProva(int idAluno)
        {
            throw new NotImplementedException();
        }
    }
}
