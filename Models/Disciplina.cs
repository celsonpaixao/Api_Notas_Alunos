using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_disciplina")]
    public class Disciplina
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_professor")]
        public int IdProfessor { get; set; }

        [Required]
        [StringLength(150)]
        [Column("disciplina")]
        public string DisciplinaNome { get; set; }
    }
}