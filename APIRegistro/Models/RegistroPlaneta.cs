using APIRegistro.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRegistro.Models
{
    public class RegistroPlaneta : IObserver
    {
        public List<Registro> Planetas;

        public RegistroPlaneta()
        {
            Planetas = new List<Registro>();
        }

        public List<Registro> ReturnRegistros()
        {
            return Planetas;
        }
        public void Update(Registro registro)
        {
            if (registro.Tipo == "Planeta")
                Planetas.Add(registro);
        }
    }
}
