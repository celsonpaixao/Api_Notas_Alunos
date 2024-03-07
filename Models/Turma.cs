using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
   [Table("tbl_turma")]
    public class Turma
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_director")]
        public int IdDirector { get; set; }

        [Column("id_sala")]
        public int IdSala { get; set; }

        [StringLength(25)]
        [Column("turma")]
        public string TurmaNome { get; set; }

        [Column("id_curso")]
        public int? IdCurso { get; set; }
    }
}