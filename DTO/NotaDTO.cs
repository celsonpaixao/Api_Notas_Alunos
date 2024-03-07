using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Notas_Aluno.DTO
{
  public class NotaDTO
{
    public int Id { get; set; }
    public string NomeAluno { get; set; }
    public Dictionary<string, Dictionary<string, decimal>> NotasPorDisciplina { get; set; }
    public Dictionary<string, decimal> MDFPorDisciplina { get; set; }
}

}
