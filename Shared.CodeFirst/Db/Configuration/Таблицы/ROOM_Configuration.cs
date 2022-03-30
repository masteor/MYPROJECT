using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ROOM_Configuration : EntityTypeConfiguration<ROOM>
    {
        public ROOM_Configuration()
        {
            ToTable(ИмяТаблицы.Room, _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.hphone).HasColumnName(ИмяКолонки.HPHONE).HasMaxLength(10).IsOptional();
            Property(e => e.wphone).HasColumnName(ИмяКолонки.WPHONE).HasMaxLength(10).IsRequired();
            Property(e => e.num).HasColumnName(ИмяКолонки.NUM).HasMaxLength(50).IsRequired();
            Property(e => e.id_building).HasColumnName(ИмяКолонки.ID_BUILDING).IsRequired();

            /*HasMany(e => e.ARM)
                .WithOptional(e => e.ПОМЕЩЕНИЕ_В_КОТОРОМ_НАХОДИТСЯ)
                .HasForeignKey(e => e.ид_помещения);

            HasMany(e => e.USER_ROOM)
                .WithRequired(e => e.ROOM)
                .HasForeignKey(e => e.id_room)
                .WillCascadeOnDelete(false);*/
        }
    }
}