using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_nota")]
    public class Nota
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_prova")]
        public int IdProva { get; set; }
    }
}