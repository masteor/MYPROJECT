using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_EMPLOYEE_EXT_Configuration : EntityTypeConfiguration<VIEW_EMPLOYEE_EXT>
    {
        public VIEW_EMPLOYEE_EXT_Configuration()
        {
            ToTable(ИмяТаблицы.ViewEmployeeExt, _EntityBase.SchemaName);

            HasKey(e => e.id_user);

            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.tnum).HasColumnName("TNUM").IsRequired();
            Property(e => e.date_1).HasColumnName(ИмяКолонки.DATE_1).IsRequired();
            Property(e => e.date_2).HasColumnName(ИмяКолонки.DATE_2).IsRequired();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsRequired();
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.id_request_2).HasColumnName("ID_REQUEST_2").IsRequired();
            Property(e => e.job_name).HasColumnName("JOB_NAME").IsRequired();
            Property(e => e.fp_name).HasColumnName("FP_NAME").IsRequired();
            Property(e => e.fp_description).HasColumnName("FP_DESCRIPTION").IsRequired();
            Property(e => e.login_name).HasColumnName("LOGIN_NAME").IsRequired();
            Property(e => e.id_domen).HasColumnName("ID_DOMEN").IsRequired();
            Property(e => e.org_fname).HasColumnName("ORG_FNAME").IsRequired();
            Property(e => e.name_1).HasColumnName("NAME_1").IsRequired();
            Property(e => e.name_2).HasColumnName("NAME_2").IsRequired();
            Property(e => e.name_3).HasColumnName("NAME_3").IsRequired();
        }   
    }
}