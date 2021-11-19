using APIRegistro.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace APIRegistro.Models
{
    public class RegistroSatelite : IObserver
    {
        public List<Registro> Satelites;

        public RegistroSatelite()
        {
            Satelites = new List<Registro>();
        }

        public List<Registro> ReturnRegistros()
        {
            return Satelites;
        }

        public void Update(Registro registro)
        {
            if (registro.Tipo == "Satelite")
                Satelites.Add(registro);
        }
    }
}
