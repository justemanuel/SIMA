using Newtonsoft.Json;

namespace APIRegistro.Models
{
    public class Registro
    {
        [JsonProperty(PropertyName = "tipo")]
        public string Tipo { get; set; }
        [JsonProperty(PropertyName = "temperaturaC")]
        public int TemperaturaC { get; set; }
        [JsonProperty(PropertyName = "tamañoKm")]
        public int TamañoKm { get; set; }
        [JsonProperty(PropertyName = "distanciaKm")]
        public int DistanciaKm { get; set; }
    }
}
