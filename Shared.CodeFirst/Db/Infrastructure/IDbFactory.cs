using System;

namespace QWERTY.Shared.Db.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        _QWERTY_Entities Init();
    }
}
