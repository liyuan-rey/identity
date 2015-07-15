using System;

namespace IdentityNS.Server.Core.Common
{
    internal interface IRepository<TEntity> : IDisposable where
        TEntity : class, new()
    {

    }
}