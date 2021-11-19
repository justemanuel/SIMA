using APIRegistro.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace APIRegistro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly HttpClient http;
        private static readonly RegistroGeneral registroGeneral = new();
        private static readonly RegistroPlaneta registroPlaneta = new();
        private static readonly RegistroEstrella registroEstrella = new();
        private static readonly RegistroSatelite registroSatelite = new();

        private static bool state;

        public RegistroController()
        {
            http = new HttpClient();
            state = false;
        }

        [HttpPost]
        public async Task<IActionResult> Start()
        {
            registroGeneral.DettachAll();

            registroGeneral.Attach(registroEstrella);
            registroGeneral.Attach(registroPlaneta);
            registroGeneral.Attach(registroSatelite);

            state = true;

            while (state)
            {
                HttpResponseMessage response = await http.GetAsync("http://localhost:34929/api/telescopio");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var registro = JsonConvert.DeserializeObject<Registro>(responseBody);

                registroGeneral.Notify(registro);

                Thread.Sleep(500);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Stop()
        {
            state = false;

            var reporte = registroGeneral.GetReporte();

            return Ok(reporte);
        }
    }
}
