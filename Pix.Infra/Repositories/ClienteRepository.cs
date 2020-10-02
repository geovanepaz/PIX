using Microsoft.EntityFrameworkCore;
using Pix.Domain;
using Pix.Infra.Contexts;
using System.Linq;

namespace Pix.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PixContext _context;

        public ClienteRepository(PixContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public IQueryable<Cliente> Query()
        {
            return _context.Clientes.AsNoTracking().AsQueryable();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
