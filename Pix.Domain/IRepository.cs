using Pix.Domain.DomainObjects;
using System;

namespace Pix.Domain
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
