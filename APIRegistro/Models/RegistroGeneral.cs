using APIRegistro.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace APIRegistro.Models
{
    public class RegistroGeneral : IObservable
    {

        public List<IObserver> Observers;

        public RegistroGeneral()
        {
            Observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Dettach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void DettachAll()
        {
            Observers.Clear();
        }

        public void Notify(Registro registro)
        {
            foreach (var observer in Observers)
            {
                observer.Update(registro);
            }
        }

        public Reporte GetReporte()
        {
            var registros = new List<Registro>();

            foreach (var observer in Observers)
            {
                registros.AddRange(observer.ReturnRegistros());
            }

            var reporte = new Reporte()
            {
                Estrellas = registros.Count(x => x.Tipo == "Estrella"),
                Planetas = registros.Count(x => x.Tipo == "Planeta"),
                Satelites = registros.Count(x => x.Tipo == "Satelite")
            };

            var estrellas = registros.Where(x => x.Tipo == "Estrella");
            var planetas = registros.Where(x => x.Tipo == "Planeta");
            var satelites = registros.Where(x => x.Tipo == "Satelite");
            reporte.PromedioDistanciaEstrellas = !estrellas.Any() ? 0 : estrellas.Average(x => x.DistanciaKm);
            reporte.PromedioDistanciaPlanetas = !planetas.Any() ? 0 : planetas.Average(x => x.DistanciaKm);
            reporte.PromedioDistanciaSatelites = !satelites.Any() ? 0 : satelites.Average(x => x.DistanciaKm);

            reporte.PromedioTamEstrellas = !estrellas.Any() ? 0 : estrellas.Average(x => x.TamañoKm);
            reporte.PromedioTamPlanetas = !planetas.Any() ? 0 : planetas.Average(x => x.TamañoKm);
            reporte.PromedioTamSatelites = !satelites.Any() ? 0 : satelites.Average(x => x.TamañoKm);

            reporte.PromedioTemperaturaEstrellas = !estrellas.Any() ? 0 : estrellas.Average(x => x.TemperaturaC);

            if ((reporte.Estrellas > reporte.Planetas) && (reporte.Estrellas > reporte.Satelites))
            {
                reporte.Moda = "Estrellas";
            }
            else if (reporte.Planetas > reporte.Satelites)
                reporte.Moda = "Planetas";
            else reporte.Moda = "Satelites";

            return reporte;
        }
    }
}
