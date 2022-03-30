using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Таблицы;

namespace DBPSA.Web.Models.Report
{
    public class USERS_ACCEPTED_RESOURCE
    {
        public int id { get; }
        public RESOURCE ресурс { get; }

        public USERS_ACCEPTED_RESOURCE(int id, RESOURCE ресурс)
        {
            this.id = id;
            this.ресурс = ресурс;
        }

        public override string ToString()
        {
            return $"{{ id = {id}, ресурс = {ресурс} }}";
        }
    }
}