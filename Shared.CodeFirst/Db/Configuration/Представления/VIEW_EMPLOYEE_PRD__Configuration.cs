using System.Data.Entity.ModelConfiguration;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Shared.Db.Configuration.Представления
{
    public class VIEW_EMPLOYEE_PRD__Configuration : EntityTypeConfiguration<VIEW_EMPLOYEE_PRD>
    {
        public VIEW_EMPLOYEE_PRD__Configuration()
        {
            ToTable(ИмяТаблицы.ViewEmployeePrd, _EntityBase.SchemaName);

            HasKey(e => new {e.id_employee});

            Property(e => e.id_employee).HasColumnName(ИмяКолонки.ID_EMPLOYEE).IsRequired();
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsRequired();
            Property(e => e.employee_fio_full).HasColumnName(ИмяКолонки.EMPLOYEE_FIO_FULL).IsOptional();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsOptional();
            Property(e => e.form_perm).HasColumnName(ИмяКолонки.FORM_PERM).IsOptional();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsOptional();
            Property(e => e.is_active_descr).HasColumnName(ИмяКолонки.IS_ACTIVE_DESCR).IsOptional();
            Property(e => e.job_name).HasColumnName(ИмяКолонки.JOB_NAME).IsOptional();
            Property(e => e.wphone).HasColumnName(ИмяКолонки.WPHONE).IsOptional();
            Property(e => e.hphone).HasColumnName(ИмяКолонки.HPHONE).IsOptional();
            Property(e => e.build).HasColumnName(ИмяКолонки.BUILD).IsOptional();
            Property(e => e.prom_area).HasColumnName(ИмяКолонки.PROM_AREA).IsOptional();
            Property(e => e.room).HasColumnName(ИмяКолонки.ROOM).IsOptional();
            Property(e => e.dep_descr).HasColumnName(ИмяКолонки.DEP_DESCR).IsOptional();
            Property(e => e.div_descr).HasColumnName(ИмяКолонки.DIV_DESCR).IsOptional();
            Property(e => e.lab_descr).HasColumnName(ИмяКолонки.LAB_DESCR).IsOptional();
            Property(e => e.dep_boss_fio_full).HasColumnName(ИмяКолонки.DEP_BOSS_FIO_FULL).IsOptional();
            Property(e => e.div_boss_fio_full).HasColumnName(ИмяКолонки.DIV_BOSS_FIO_FULL).IsOptional();
            Property(e => e.lab_boss_fio_full).HasColumnName(ИмяКолонки.LAB_BOSS_FIO_FULL).IsOptional();
        }
    }
}
