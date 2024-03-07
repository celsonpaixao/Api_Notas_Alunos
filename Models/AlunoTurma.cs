using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_aluno_turma")]
    public class AlunoTurma
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_aluno")]
        public int IdAluno { get; set; }

        [Column("id_turma")]
        public int IdTurma { get; set; }
    }
}