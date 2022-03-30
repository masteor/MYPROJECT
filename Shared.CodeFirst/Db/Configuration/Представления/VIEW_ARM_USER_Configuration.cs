using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_ARM_USER_Configuration : EntityTypeConfiguration<VIEW_ARM_USER>
    {
        public VIEW_ARM_USER_Configuration()
        {
            ToTable(ИмяТаблицы.ViewArmUser, _EntityBase.SchemaName);

            HasKey(e => new {e.id});

            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            Property(e => e.sfio).HasColumnName(ИмяКолонки.SFIO).IsOptional();
            Property(e => e.tnum).HasColumnName(ИмяКолонки.TNUM).IsOptional();
            Property(e => e.arm_reg_num).HasColumnName(ИмяКолонки.ARM_REG_NUM).IsOptional();
            Property(e => e.arm_user_role_name).HasColumnName(ИмяКолонки.ARM_USER_ROLE_NAME).IsOptional();
            
            Property(e => e.create_date_1).HasColumnName(ИмяКолонки.CREATE_DATE_1).IsOptional();
            Property(e => e.create_date_2).HasColumnName(ИмяКолонки.CREATE_DATE_2).IsOptional();
            Property(e => e.create_request_state).HasColumnName(ИмяКолонки.CREATE_REQUEST_STATE).IsOptional();
            
            Property(e => e.end_date_1).HasColumnName(ИмяКолонки.END_DATE_1).IsOptional();
            Property(e => e.end_date_2).HasColumnName(ИмяКолонки.END_DATE_2).IsOptional();
            Property(e => e.end_request_state).HasColumnName(ИмяКолонки.END_REQUEST_STATE).IsOptional();
        }
    }
}
