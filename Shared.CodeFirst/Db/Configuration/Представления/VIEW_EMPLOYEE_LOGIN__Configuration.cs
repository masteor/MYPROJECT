using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_EMPLOYEE_LOGIN_Configuration : EntityTypeConfiguration<VIEW_EMPLOYEE_LOGIN>
    {
        public VIEW_EMPLOYEE_LOGIN_Configuration()
        {
            ToTable(ИмяТаблицы.ViewEmployeeLogin, _EntityBase.SchemaName);

            HasKey(e => new {e.id_user});

            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsRequired();
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsRequired();
            Property(e => e.name_1).HasColumnName(ИмяКолонки.NAME_1).IsRequired();
            Property(e => e.name_2).HasColumnName(ИмяКолонки.NAME_2).IsRequired();
            Property(e => e.name_3).HasColumnName(ИмяКолонки.NAME_3).IsRequired();
            Property(e => e.fio_full).HasColumnName(ИмяКолонки.FIO_FULL).IsRequired();
            Property(e => e.fio_full_login).HasColumnName(ИмяКолонки.FIO_FULL_LOGIN).IsRequired();
            Property(e => e.id_org).HasColumnName(ИмяКолонки.ID_ORG).IsRequired();
            Property(e => e.id_login).HasColumnName(ИмяКолонки.ID_LOGIN).IsRequired();
            Property(e => e.login_name).HasColumnName(ИмяКолонки.LOGIN_NAME).IsRequired();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsRequired();
        }
    }
}
