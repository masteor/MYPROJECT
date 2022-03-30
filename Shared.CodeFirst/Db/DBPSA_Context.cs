using System;
using System.Data.Entity;
using log4net;

namespace QWERTY.Shared.Db
{
    public partial class _QWERTY_Entities : DbContext
    {
        private readonly ILog _log;

        public _QWERTY_Entities(string connectionString) : base(connectionString)
        {
            try
            {
                _log = LogManager.GetLogger("RequestsEntities");

                // disable code-first migrations
                Database.SetInitializer(new NullDatabaseInitializer<_QWERTY_Entities>());
                // Database.Initialize(true);

                // enable sql logging
                Database.Log += s => _log.Debug(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
