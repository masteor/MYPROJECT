using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class REQUEST_STATE_Configuration : EntityTypeConfiguration<REQUEST_STATE>
    {
        public REQUEST_STATE_Configuration()
        {
            ToTable(ИмяТаблицы.REQUEST_STATE, _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();

            Property(e => e.name).HasColumnName(ИмяКолонки.NAME).IsRequired();
            Property(e => e.code).HasColumnName(ИмяКолонки.CODE).IsRequired();

            /*HasMany(e => e.EXECUTION_0)
                .WithRequired(e => e.REQUEST_STATE)
                .HasForeignKey(e => e.id_request_state_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.EXECUTION_1)
                .WithOptional(e => e.REQUEST_STATE1)
                .HasForeignKey(e => e.id_request_state_2);

            HasMany(e => e.REQUEST)
                .WithRequired(e => e.REQUEST_STATE)
                .HasForeignKey(e => e.ид_текущего_статуса_заявки)
                .WillCascadeOnDelete(false);*/
        }
    }
}