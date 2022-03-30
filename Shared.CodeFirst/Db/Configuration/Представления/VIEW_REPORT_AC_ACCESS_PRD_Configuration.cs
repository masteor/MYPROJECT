using System.Data.Entity.ModelConfiguration;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Shared.Db.Configuration.Представления
{
    public class VIEW_REPORT_AC_ACCESS_PRD_Configuration : EntityTypeConfiguration<VIEW_REPORT_AC_ACCESS_PRD>
    {
        public VIEW_REPORT_AC_ACCESS_PRD_Configuration()
        {
            ToTable(ИмяТаблицы.ViewReportAcAccessPrd, _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            Property(e => e.id).HasColumnName(ИмяКолонки.ID_AC_ACCESS).IsRequired();
            
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsOptional();
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
            Property(e => e.reg_num).HasColumnName(ИмяКолонки.REG_NUM).IsOptional();
            
        }
    }
}