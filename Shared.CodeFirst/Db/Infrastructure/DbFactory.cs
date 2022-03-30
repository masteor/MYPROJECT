namespace QWERTY.Shared.Db.Infrastructure
{
    public class DbFactory : DisposableObject, IDbFactory
    {
        private readonly string _connectionString;
        private _QWERTY_Entities _dbContext;

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public _QWERTY_Entities Init()
        {
            /*return _dbContext ?? (_dbContext = new QWERTY_Entities());*/
            return _dbContext ?? (_dbContext = new _QWERTY_Entities(_connectionString));
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }

        public _QWERTY_Entities GET_DB_CONTEXT => _dbContext;

    }
}