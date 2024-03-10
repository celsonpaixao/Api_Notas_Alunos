using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Notas_Aluno.DAL.IRepository;
using Api_Notas_Aluno.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api_Notas_Aluno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly INotaRepository nota;
        public NotaController(INotaRepository _nota)
        {
            nota = _nota;
        }
        [HttpGet("BuscarTodasNotas")]

        public async Task<ActionResult<DTOResposta>> BuscarTodasNotas()
        {
            return await nota.BuscarTodasNotas();
        }

        [HttpGet("Buscar_Notas_Por_Disciplina")]

        public async Task<ActionResult<DTOResposta>> Buscar_Notas_Por_Disciplina(string disciplina)
        {
            return await nota.BuscarNotasPorDisciplina(disciplina);
        }
        [HttpPost("Cadastrar_Nota_Do_Aluno")]
        public async Task<ActionResult<DTOResposta>> CadastrarNota(int idAluno, decimal P1, decimal P2, decimal Pt, string Trimestre, int idDisciplina, int IdClasse)
        {
            var resposta = await nota.CadastrarProva(idAluno, P1, P2, Pt, Trimestre, idDisciplina, IdClasse);
            return Ok(resposta);
        }
        [HttpGet("Buscar_Notas_Por_Curso")]

        public async Task<ActionResult<DTOResposta>> Buscar_Notas_Por_Curso(string curso)
        {
            return await nota.BuscarNotasPorCurso(curso);
        }
        [HttpGet("BuscarNotasPorNomeAluno")]

        public async Task<ActionResult<DTOResposta>> Buscar_Notas_Por_Nome_Aluno(string nome)
        {
            return await nota.BuscarNotasPorNomeAluno(nome);
        }
    }
}