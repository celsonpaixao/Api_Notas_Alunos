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
    }
}