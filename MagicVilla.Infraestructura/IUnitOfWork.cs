namespace MagicVilla.Infraestructura.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IContextoDB Contexto { get; }

        void Commit();

        void CommitAndRefreshChanges();
    }
}
