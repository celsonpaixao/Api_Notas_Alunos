using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
   [Table("tbl_classe")]
    public class Classe
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        [Column("classe")]
        public string classe { get; set; }
    }
}