using System.Data.Entity.ModelConfiguration;
using DBPSA.Shared.Db.Entities;
using DBPSA.Shared.Db.Entities.Представления;

namespace DBPSA.Shared.Db.Configuration.Представления
{
    public class VIEW_EMPLOYEE_LOGIN_PRD__Configuration : EntityTypeConfiguration<VIEW_EMPLOYEE_LOGIN_PRD>
    {
        public VIEW_EMPLOYEE_LOGIN_PRD__Configuration()
        {
            ToTable(ИмяТаблицы.ViewEmployeeLoginPrd, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.name1).HasColumnName(ИмяКолонки.NAME_1).IsOptional();
            Property(e => e.name2).HasColumnName(ИмяКолонки.NAME_2).IsOptional();
            Property(e => e.name3).HasColumnName(ИмяКолонки.NAME_3).IsOptional();
            Property(e => e.login).HasColumnName(ИмяКолонки.LOGIN).IsOptional();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsOptional();
        }
    }
}
