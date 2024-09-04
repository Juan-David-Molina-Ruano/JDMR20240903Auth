using JDMR20240903.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JDMR20240903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        static List<Matricula> matriculas = new List<Matricula>();

        [HttpGet]
        [Authorize]
        public IEnumerable<object> ObtenerMatriculaPorId(int id)
        {
            var matricula = matriculas.Where(x => x.Id == id);
            return matricula;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CrearMatricula(Matricula matricula)
        {
            matriculas.Add(matricula);
            return Ok("Matricula Creada Correctamente");
        }

        [HttpPut]
        [Authorize]
        public IActionResult ModificarMatricula(int id, Matricula matricula)
        {
            var matriculaExistente = matriculas.FirstOrDefault(x => x.Id == id);
            if (matriculaExistente != null)
            {
                matriculaExistente.Nombre = matricula.Nombre;
                matriculaExistente.Apellido = matricula.Apellido;
                matriculaExistente.Fecha = matricula.Fecha;
                return Ok("Matricula Actualizada Correctamente");
            }
            return NotFound("Matricula no encontrada");
        }


    }
}
