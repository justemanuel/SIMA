namespace APIRegistro.Models.Interfaces
{
    public interface IObservable
    {
        void Attach(IObserver observer);

        void Dettach(IObserver observer);

        void DettachAll();

        void Notify(Registro registro);
    }
}
