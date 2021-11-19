using APIRegistro.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRegistro.Models
{
    public class RegistroEstrella : IObserver
    {

        public List<Registro> Estrellas;

        public RegistroEstrella()
        {
            Estrellas = new List<Registro>();
        }

        public List<Registro> ReturnRegistros()
        {
            return Estrellas;
        }

        public void Update(Registro registro)
        {
            if (registro.Tipo == "Estrella")
                Estrellas.Add(registro);
        }
    }
}
