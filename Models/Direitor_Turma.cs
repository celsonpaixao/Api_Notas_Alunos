using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_director_turma")]
    public class DirectorTurma
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        [Column("primeiro_nome")]
        public string PrimeiroNome { get; set; }

        [Required]
        [StringLength(25)]
        [Column("ultimo_nome")]
        public string UltimoNome { get; set; }
    }
}