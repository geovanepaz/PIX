using System.Linq;

namespace Pix.Domain
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IQueryable<Cliente> Query();
    }
}
