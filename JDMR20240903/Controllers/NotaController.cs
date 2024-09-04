using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace JDMR20240903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotaController : ControllerBase
    {

        static List<object> notas = new List<object>();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> ObtenerNotas()
        {
            return notas;
        }

        [HttpPost]
        [Authorize]
        public IActionResult RegistrarNota(int nota, string materia)
        {
            notas.Add(new {nota, materia});
            return Ok("Nota creada");
        }


    }
}
