using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class MathController : Controller
    {

        [HttpPost("{operacion}={valor1}n{valor2}")]
        public IActionResult Post(string operacion, int valor1, int valor2)
        {
            int res = 0;
            switch (operacion)
            {
                case "suma":
                    res = valor1 + valor2;
                    break;
                case "resta":
                    res = valor1 - valor2;
                    break;
                case "multiplicacion":
                    res = valor1 * valor2;
                    break;
                case "division":
                    res = valor1 / valor2;
                    break;
            }
            return Ok(res);
        }


        [HttpPost]
        public IActionResult PostHeader()
        {
            try
            {
                int valor1 = int.Parse(HttpContext.Request.Headers["valor1"]);
                int valor2 = int.Parse(HttpContext.Request.Headers["valor2"]);
                var operacion = HttpContext.Request.Headers["operacion"];

                int resultado = 0;
                switch (operacion)
                {
                    case "suma":
                        resultado = valor1 + valor2;
                        break;
                    case "resta":
                        resultado = valor1 - valor2;
                        break;
                    case "division":
                        resultado = valor1 / valor2;
                        break;
                    case "multiplicacion":
                        resultado = valor1 * valor2;
                        break;
                }
                return Ok(resultado);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }
    }
}
