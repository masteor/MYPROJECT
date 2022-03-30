using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class USER_ROOM_Configuration : EntityTypeConfiguration<USER_ROOM>
    {
        public USER_ROOM_Configuration()
        {
            ToTable("_USER_ROOM", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_room).HasColumnName("ID_ROOM").IsRequired();
            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();
        }
    }
}