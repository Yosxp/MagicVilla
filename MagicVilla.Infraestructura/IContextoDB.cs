using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Infraestructura.Interface
{
    public interface IContextoDB : IDisposable
    {
        DbContext Instance { get; }
    }
}
