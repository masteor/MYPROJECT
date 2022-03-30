using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_FIO_Configuration : EntityTypeConfiguration<VIEW_FIO>
    {
        public VIEW_FIO_Configuration()
        {
            ToTable(ИмяТаблицы.ViewFio, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsOptional();
            Property(e => e.id_new).HasColumnName(ИмяКолонки.ID_NEW).IsOptional();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsOptional();
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
        }
    }
}
