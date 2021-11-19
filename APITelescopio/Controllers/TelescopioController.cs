using APITelescopio.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APITelescopio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelescopioController : ControllerBase
    {
        private static readonly string[] TiposDeCuerpo = new string[3] { "Planeta", "Estrella", "Satelite" };

        [HttpGet]
        public IActionResult Get()
        {
            var random = new Random();

            var cuerpoCeleste = new CuerpoCeleste()
            {
                Tipo = TiposDeCuerpo[random.Next(0, 3)],
                TamañoKm = random.Next(90000000, 900000000),
                DistanciaKm = random.Next(80000000, 800000000)
            };

            cuerpoCeleste.TemperaturaC = cuerpoCeleste.Tipo == "Estrella" ? random.Next(-20, 55) : 0;

            return Ok(cuerpoCeleste);
        }
    }
}
