
 







/* ---------------------------------------------------------------------------------------------------
*    ЭТО АВТОМАТИЧЕСКИ ГЕНЕРИРУЕМЫЙ ФАЙЛ
*    НЕ РЕДАКТИРУЙТЕ ЕГО - ВСЕ ИЗМЕНЕНИЯ БУДУТ УДАЛЕНЫ
*
*    РЕЗУЛЬТАТ СОХРАНИТЬ ЗДЕСЬ: \Db\Configuration\Представления\VIEW_EMPLOYEE_Configuration.cs
* ---------------------------------------------------------------------------------------------------*/
using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_EMPLOYEE_Configuration : EntityTypeConfiguration<VIEW_EMPLOYEE>
    {
        public VIEW_EMPLOYEE_Configuration()
        {
            ToTable(ИмяТаблицы.ViewEmployee, _EntityBase.SchemaName);

            HasKey(e => new {e.id_employee});

            Property(e => e.id_employee).HasColumnName(ИмяКолонки.ID_EMPLOYEE).IsRequired                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ();
            
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsRequired();
            Property(e => e.employee_fio_full).HasColumnName(ИмяКолонки.EMPLOYEE_FIO_FULL).IsRequired();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsRequired();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsRequired();
            Property(e => e.is_active_descr).HasColumnName(ИмяКолонки.IS_ACTIVE_DESCR).IsRequired();
            Property(e => e.job_name).HasColumnName(ИмяКолонки.JOB_NAME).IsRequired();
            Property(e => e.form_perm).HasColumnName(ИмяКолонки.FORM_PERM).IsRequired();
            Property(e => e.wphone).HasColumnName(ИмяКолонки.WPHONE).IsRequired();
            Property(e => e.hphone).HasColumnName(ИмяКолонки.HPHONE).IsRequired();
            Property(e => e.build).HasColumnName(ИмяКолонки.BUILD).IsRequired();
            Property(e => e.prom_area).HasColumnName(ИмяКолонки.PROM_AREA).IsRequired();
            Property(e => e.room).HasColumnName(ИмяКолонки.ROOM).IsRequired();
            
            Property(e => e.dep_descr).HasColumnName(ИмяКолонки.DEP_DESCR).IsRequired();
            Property(e => e.dep_utype_name).HasColumnName(ИмяКолонки.DEP_UTYPE_NAME).IsRequired();
            Property(e => e.dep_utype_code).HasColumnName(ИмяКолонки.DEP_UTYPE_CODE).IsRequired();
            
            Property(e => e.div_descr).HasColumnName(ИмяКолонки.DIV_DESCR).IsRequired();
            Property(e => e.div_utype_name).HasColumnName(ИмяКолонки.DIV_UTYPE_NAME).IsRequired();
            Property(e => e.div_utype_code).HasColumnName(ИмяКолонки.DIV_UTYPE_CODE).IsRequired();
        }
    }
}
