using OnionArchitecture.Core.Data;
using System;

namespace OnionArchitecture.Core.Services
{
    public interface IService : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
