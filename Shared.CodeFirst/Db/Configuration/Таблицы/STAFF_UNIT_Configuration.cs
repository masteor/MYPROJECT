using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class STAFF_UNIT_Configuration : EntityTypeConfiguration<STAFF_UNIT>
    {
        public STAFF_UNIT_Configuration()
        {
            ToTable(ИмяТаблицы.StaffUnit, _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.id_staff).HasColumnName("ID_STAFF").IsRequired();
            Property(e => e.id_user).HasColumnName("ID_USER").IsRequired();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsOptional();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.EXECUTION)
                .WithRequired(e => e.STAFF_UNIT)
                .HasForeignKey(e => e.id_executor)
                .WillCascadeOnDelete(false);

            HasMany(e => e.NOTIFY_SUB_0)
                .WithRequired(e => e.STAFF_UNIT)
                .HasForeignKey(e => e.subscriber)
                .WillCascadeOnDelete(false);

            HasMany(e => e.NOTIFY_SUB_1)
                .WithRequired(e => e.STAFF_UNIT1)
                .HasForeignKey(e => e.producer)
                .WillCascadeOnDelete(false);

            HasMany(e => e.STAFF_UNIT_1)
                .WithOptional(e => e.STAFF_UNIT_2)
                .HasForeignKey(e => e.id_new);*/
        }
    }
}