using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class TEST_Configuration : EntityTypeConfiguration<TEST>
    {
        public TEST_Configuration()
        {
            ToTable("Херня", _EntityBase.SchemaName);

            HasKey(e => new {e.id});
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();

            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsOptional();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsOptional();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsOptional();
            Property(e => e.job_name).HasColumnName(ИмяКолонки.JOB_NAME).IsOptional();
            Property(e => e.org_name).HasColumnName(ИмяКолонки.ORG_NAME).IsOptional();
            Property(e => e.form_perm).HasColumnName(ИмяКолонки.FORM_PERM).IsOptional();
            Property(e => e.profile_name).HasColumnName(ИмяКолонки.PROFILE_NAME).IsOptional();
            Property(e => e.resource_name).HasColumnName(ИмяКолонки.RESOURCE_NAME).IsOptional();
            
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
        }
    }
}