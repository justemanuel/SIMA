using System.Collections.Generic;

namespace APIRegistro.Models.Interfaces
{
    public interface IObserver
    {
        void Update(Registro registro);
        List<Registro> ReturnRegistros();
    }
}
