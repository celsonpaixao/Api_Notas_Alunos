using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_prova")]
    public class Prova
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("p1")]
        public decimal P1 { get; set; }

        [Required]
        [Column("p2")]
        public decimal P2 { get; set; }

        [Required]
        [Column("pt")]
        public decimal Pt { get; set; }

        [Column("id_aluno")]
        public int IdAluno { get; set; }

        [Column("id_disciplina")]
        public int IdDisciplina { get; set; }

        [Column("id_classe")]
        public int IdClasse { get; set; }

        [StringLength(25)]
        [Column("trimestre")]
        public string Trimestre { get; set; }

        [Column("mdf")]
        public decimal? Mdf { get; set; }
    }
}