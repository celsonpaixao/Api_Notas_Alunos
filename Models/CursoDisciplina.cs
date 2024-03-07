using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
     [Table("tbl_curso_disciplina")]
    public class CursoDisciplina
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_curso")]
        public int IdCurso { get; set; }

        [Column("id_disciplina")]
        public int IdDisciplina { get; set; }
    }
}