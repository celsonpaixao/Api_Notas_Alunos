using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Notas_Aluno.Models
{
    [Table("tbl_aluno")]
    public class Aluno
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

        [Required]
        [StringLength(25)]
        [Column("numero_bi")]
        public string NumeroBI { get; set; }

        [Column("data_nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}