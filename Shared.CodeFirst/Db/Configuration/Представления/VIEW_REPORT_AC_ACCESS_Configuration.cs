using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_AC_ACCESS_Configuration : EntityTypeConfiguration<VIEW_REPORT_AC_ACCESS>
    {
        public VIEW_REPORT_AC_ACCESS_Configuration()
        {
            ToTable(ИмяТаблицы.ViewReportAcAccessPrd, _EntityBase.SchemaName);

            HasKey(e => new {e.id_ac_access});
            Property(e => e.id_ac_access).HasColumnName(ИмяКолонки.ID_AC_ACCESS).IsRequired();
            
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsOptional();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsOptional();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsOptional();
            Property(e => e.family).HasColumnName(ИмяКолонки.FAMILY).IsOptional();
            Property(e => e.name).HasColumnName(ИмяКолонки.NAME).IsOptional();
            Property(e => e.patronymic).HasColumnName(ИмяКолонки.PATRONYMIC).IsOptional();
            Property(e => e.org_fname).HasColumnName(ИмяКолонки.ORG_FNAME).IsOptional();
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsOptional();
            Property(e => e.is_active_string).HasColumnName(ИмяКолонки.IS_ACTIVE_STRING).IsOptional();
            Property(e => e.reg_num).HasColumnName(ИмяКолонки.REG_NUM).IsOptional();
        }
    }
}

