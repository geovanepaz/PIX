using System.Threading.Tasks;

namespace Pix.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}