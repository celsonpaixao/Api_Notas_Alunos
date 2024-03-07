using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_curso_classe")]
    public class CursoClasse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_curso")]
        public int IdCurso { get; set; }

        [Column("id_classe")]
        public int IdClasse { get; set; }
    }
}