using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Notas_Aluno.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Notas_Aluno.DAL.Database
{
    public class NotaAlunoDbContext : DbContext
    {

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }
        public DbSet<DirectorTurma> Diretores { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<CursoDisciplina> CursosDisciplinas { get; set; }

        public DbSet<CursoClasse> CursoClasses { get; set; }
        public DbSet<Prova> Provas { get; set; }
        public DbSet<AlunoTurma> AlunosTurmas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura as opções de conexão com o PostgreSQL
            optionsBuilder.UseNpgsql(DbString.ConetionString());
        }
    }
}