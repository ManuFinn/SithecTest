using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class HumanoController : ControllerBase
    {
        public testdbContext Context { get; set; }

        HumanoRepository repo;

        public HumanoController(testdbContext con)
        {
            Context = con;
            repo = new HumanoRepository(Context);
        }

        [HttpGet("GetMock")]
        public IEnumerable<Humanotable> GetMock()
        {
            var hu1 = new Humanotable { Id = 1, Nombre = "Hector", Sexo = "Masculino", Edad = 25, Altura = 175, Peso = 70 };
            var hu2 = new Humanotable { Id = 2, Nombre = "Jesus", Sexo = "Masculino", Edad = 30, Altura = 165, Peso = 55 };
            var hu3 = new Humanotable { Id = 3, Nombre = "Pedro", Sexo = "Masculino", Edad = 40, Altura = 180, Peso = 85 };

            return new List<Humanotable> { hu1, hu2, hu3 };
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hu = repo.GetAll();
            return Ok(hu);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var hu = repo.GetById(id);
            if (hu != null)
            {
                return Ok(hu);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AgregarHumano")]
        public IActionResult Post([FromBody] Humanotable hu)
        {
            try
            {
                if (repo.IsValid(hu, out List<string> errores))
                {
                    repo.Insert(hu);
                    return Ok();
                }
                else
                {
                    return BadRequest(errores);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) { return StatusCode(500, ex.InnerException.Message); }
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("EditarHumano")]
        public IActionResult Put([FromBody] Humanotable hu)
        {
            try
            {
                var humanoOriginal = repo.GetById(hu.Id);
                if (humanoOriginal != null)
                {
                    if (repo.IsValid(hu, out List<string> errores))
                    {
                        humanoOriginal.Nombre = hu.Nombre;
                        humanoOriginal.Sexo = hu.Sexo;
                        humanoOriginal.Edad = hu.Edad;
                        humanoOriginal.Altura = hu.Altura;
                        humanoOriginal.Peso = hu.Peso;
                        repo.Update(humanoOriginal);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(errores);
                    }
                }
                else { return NotFound(); }
                
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) { return StatusCode(500, ex.InnerException.Message); }
                return StatusCode(500, ex.Message);
            }
        }
    }
}
