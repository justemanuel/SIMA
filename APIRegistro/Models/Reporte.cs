namespace APIRegistro.Models
{
    public class Reporte
    {
        public int Estrellas { get; set; }
        public int Planetas { get; set; }
        public int Satelites { get; set; }
        public double PromedioDistanciaEstrellas { get; set; }
        public double PromedioDistanciaPlanetas { get; set; }
        public double PromedioDistanciaSatelites { get; set; }
        public double PromedioTamEstrellas { get; set; }
        public double PromedioTamPlanetas { get; set; }
        public double PromedioTamSatelites { get; set; }
        public double PromedioTemperaturaEstrellas { get; set; }
        public string Moda { get; set; }
    }
}
