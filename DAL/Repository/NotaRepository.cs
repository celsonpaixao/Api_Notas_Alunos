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

        public async Task<DTOResposta> BuscarNotasPorCurso(string Nomecurso)
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
                             where curso.curso == Nomecurso
                             select new
                             {
                                 Aluno = new
                                 {
                                     Id = aluno.Id,
                                     Nome = aluno.PrimeiroNome,
                                     Sobrenome = aluno.UltimoNome,
                                     Classe = classe.classe,
                                     Curso = curso.curso,
                                     Prova = new
                                     {
                                         dispiplina = dispiplina.DisciplinaNome,
                                         Trimestre = prova.Trimestre,
                                         P1 = prova.P1,
                                         P2 = prova.P2,
                                         Pt = prova.Pt,
                                         Media = prova.Mdf,
                                     },
                                 },
                             };

                notas.resposta =  result.ToList();
                notas.mensagem = "Notas do curso " + Nomecurso;
            }
            catch (System.Exception ex)
            {
                notas.mensagem = ex.ToString();
            }

            return  notas;
        }
        public async Task<DTOResposta> BuscarNotasPorDisciplina(string disciplina)
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
                             where dispiplina.DisciplinaNome == disciplina
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

                notas.resposta = result.ToList();
                notas.mensagem = "Notas da disciplina " + disciplina;
            }
            catch (System.Exception ex)
            {
                notas.mensagem = ex.ToString();
            }

            return notas;
        }


        public async Task<DTOResposta> BuscarNotasPorNomeAluno(string nomeAluno)
        {
            DTOResposta nota = new DTOResposta();
            try
            {
                var result = from prova in _notaAlunoDb.Provas
                             join aluno in _notaAlunoDb.Alunos on prova.IdAluno equals aluno.Id
                             join dispiplina in _notaAlunoDb.Disciplinas on prova.IdDisciplina equals dispiplina.Id
                             join classe in _notaAlunoDb.Classes on prova.IdClasse equals classe.Id
                             join classecurso in _notaAlunoDb.CursoClasses on classe.Id equals classecurso.IdClasse
                             join curso in _notaAlunoDb.Cursos on classecurso.IdCurso equals curso.Id
                             where aluno.PrimeiroNome == nomeAluno
                             select new
                             {
                                 Aluno = new
                                 {
                                     Id = aluno.Id,
                                     Nome = aluno.PrimeiroNome,
                                     Sobrenome = aluno.UltimoNome,
                                     Classe = classe.classe,
                                     Curso = curso.curso,
                                     Prova = new
                                     {
                                         dispiplina = dispiplina.DisciplinaNome,
                                         Trimestre = prova.Trimestre,
                                         P1 = prova.P1,
                                         P2 = prova.P2,
                                         Pt = prova.Pt,
                                         Media = prova.Mdf,
                                     },
                                 },

                             };

                nota.resposta = result;
                nota.mensagem = "Sucesso";
            }
            catch (System.Exception e)
            {

                nota.mensagem = e.ToString();
            }

            return nota;
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

        public async Task<DTOResposta> CadastrarProva(int idAluno, decimal P1, decimal P2, decimal Pt, string Trimestre, int idDisciplina, int idClasse)
        {
            DTOResposta resposta = new DTOResposta();

            try
            {
                // Verifique se o aluno existe
                var aluno = await _notaAlunoDb.Alunos.FindAsync(idAluno);
                if (aluno == null)
                {
                    resposta.mensagem = "Aluno não encontrado.";
                    return resposta;
                }

                // Verifique se a disciplina existe
                var disciplina = await _notaAlunoDb.Disciplinas.FindAsync(idDisciplina);
                if (disciplina == null)
                {
                    resposta.mensagem = "Disciplina não encontrada.";
                    return resposta;
                }

                // Calcule a média das notas
                decimal media = (P1 + P2 + Pt) / 3;

                // Crie uma nova instância de Prova
                Prova novaProva = new Prova
                {
                    IdAluno = idAluno,
                    IdClasse = idClasse,
                    P1 = P1,
                    P2 = P2,
                    Pt = Pt,
                    Mdf = media,
                    Trimestre = Trimestre,
                    IdDisciplina = disciplina.Id
                };

                // Adicione a prova ao contexto do banco de dados
                _notaAlunoDb.Provas.Add(novaProva);

                // Salve as mudanças no banco de dados
                await _notaAlunoDb.SaveChangesAsync();

                resposta.mensagem = "Prova cadastrada com sucesso.";
                resposta.resposta = novaProva;
            }
            catch (Exception ex)
            {
                resposta.mensagem = ex.InnerException?.Message;
                // resposta.excecaoDetalhada = ex.InnerException?.Message; // Adicionando detalhes da exceção interna
            }

            return resposta;
        }
    }
}
