using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class REQUEST_Configuration : EntityTypeConfiguration<REQUEST>
    {
        public REQUEST_Configuration()
        {
            ToTable(ИмяТаблицы.REQUEST, _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();

            Property(e => e.id_request_type).HasColumnName(ИмяКолонки.ID_REQUEST_TYPE).IsRequired();
            Property(e => e.date_1).HasColumnName(ИмяКолонки.DATE_1).IsRequired();
            Property(e => e.date_2).HasColumnName(ИмяКолонки.DATE_2).IsOptional();
            Property(e => e.id_user_1).HasColumnName(ИмяКолонки.ID_USER_1).IsRequired();
            Property(e => e.id_user_2).HasColumnName(ИмяКолонки.ID_USER_2).IsRequired();
            Property(e => e.id_request_state).HasColumnName(ИмяКолонки.ID_REQUEST_STATE).IsRequired();
            Property(e => e.id_doc).HasColumnName(ИмяКолонки.ID_DOC).IsOptional();
            Property(e => e.reg_num).HasColumnName(ИмяКолонки.REG_NUM).IsOptional();
            Property(e => e.parent).HasColumnName(ИмяКолонки.PARENT).IsOptional();

            /*HasMany(e => e.AC_ACCESS1)
                .WithOptional(e => e.ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА)
                .HasForeignKey(e=> e.ид_заявки_разрешения_допуска)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.AC_ACCESS2)
                .WithOptional(e => e.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА)
                .HasForeignKey(e=> e.ид_заявки_прекращения_допуска)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.ARM)
                .WithRequired(e => e.ЗАЯВКА_ПОСТАНОВКИ_НА_УЧЁТ)
                .HasForeignKey(e => e.ид_заявки_постановки_на_учёт)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ARM1)
                .WithOptional(e => e.ЗАЯВКА_СНЯТИЯ_С_УЧЁТА)
                .HasForeignKey(e => e.ид_заявки_снятия_с_учёта);
            
            HasMany(e => e.ARM_DEVICE)
                .WithRequired(e => e.REQUEST)
                .HasForeignKey(e => e.ид_заявки_начала_разрешения)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ARM_DEVICE1)
                .WithOptional(e => e.REQUEST1)
                .HasForeignKey(e => e.ид_заявки_окончания_разрешения);

            HasMany(e => e.ARM_USER)
                .WithRequired(e => e.ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА)
                .HasForeignKey(e => e.ид_заявки_разрешения_допуска)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ARM_USER1)
                .WithOptional(e => e.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА)
                .HasForeignKey(e => e.ид_заявки_прекращения_доступа);
            
            HasMany(e => e.DEVICE)
                .WithRequired(e => e.REQUEST)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.DEVICE1)
                .WithOptional(e => e.REQUEST1)
                .HasForeignKey(e => e.id_request_2);
            
            HasMany(e => e.RIGHT)
                .WithRequired(e => e.ЗАЯВКА_НА_СОЗДАНИЕ)
                .HasForeignKey(e => e.ид_заявки_на_создание)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RIGHT1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);
            
            HasMany(e => e.RESOURCE_UCA)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RESOURCE_UCA1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);

            HasMany(e => e.PROFILE)
                .WithRequired(e => e.ЗАЯВКА_НА_СОЗДАНИЕ)
                .HasForeignKey(e => e.ид_заявки_на_создание)
                .WillCascadeOnDelete(false);

            HasMany(e => e.PROFILE1)
                .WithOptional(e => e.ЗАЯВКА_НА_УДАЛЕНИЕ)
                .HasForeignKey(e => e.ид_заявки_на_удаление);

            HasMany(e => e.EMPLOYEE)
                .WithRequired(e => e.ЗАЯВКА_ПРИЁМА_НА_РАБОТУ)
                .HasForeignKey(e => e.ид_заявки_создания)
                .WillCascadeOnDelete(false);

            HasMany(e => e.EMPLOYEE1)
                .WithOptional(e => e.ЗАЯВКА_УВОЛЬНЕНИЯ_СОТРУДНИКА)
                .HasForeignKey(e => e.ид_заявки_удаления);

            HasMany(e => e.EMPLOYEE_ORG_2)
                .WithOptional(e => e.REQUEST)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.EMPLOYEE_ORG_1)
                .WithOptional(e => e.REQUEST1)
                .HasForeignKey(e => e.id_request_2);

            HasMany(e => e.EXECUTION)
                .WithRequired(e => e.REQUEST)
                .HasForeignKey(e => e.id_request)
                .WillCascadeOnDelete(false);

            HasMany(e => e.FIO)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.ид_заявки_на_создание)
                .WillCascadeOnDelete(false);

            HasMany(e => e.FIO1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.ид_заявки_на_удаление);

            HasMany(e => e.NOTIFY_REQUEST)
                .WithRequired(e => e.REQUEST)
                .HasForeignKey(e => e.id_request)
                .WillCascadeOnDelete(false);

            HasMany(e => e.OBJECT)
                .WithRequired(e => e.ЗАЯВКА_НА_СОЗДАНИЕ)
                .HasForeignKey(e => e.ид_заявки_на_создание)
                .WillCascadeOnDelete(false);

            HasMany(e => e.OBJECT1)
                .WithOptional(e => e.ЗАЯВКА_УДАЛЕНИЯ_ОБЪЕКТА)
                .HasForeignKey(e => e.ид_заявки_на_удаление);

            HasMany(e => e.ORG)
                .WithRequired(e => e.REQUEST)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ORG1)
                .WithOptional(e => e.REQUEST1)
                .HasForeignKey(e => e.id_request_2);

            HasMany(e => e.RESOURCE)
                .WithRequired(e => e.ЗАЯВКА_НА_СОЗДАНИЕ)
                .HasForeignKey(e => e.ид_заявки_на_создание)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RESOURCE1)
                .WithOptional(e => e.ЗАЯВКА_НА_УДАЛЕНИЕ)
                .HasForeignKey(e => e.ид_заявки_на_удаление);

            HasMany(e => e.SERVICE)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.SERVICE1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);

            HasMany(e => e.STAFF)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.STAFF1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);

            HasMany(e => e.STAFF_UNIT)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.STAFF_UNIT1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);

            HasMany(e => e.USER_ROOM)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.USER_ROOM1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);
            
            HasMany(e => e.RESOURCE_RESP)
                .WithRequired(e => e.REQUEST_0)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RESOURCE_RESP1)
                .WithOptional(e => e.REQUEST_1)
                .HasForeignKey(e => e.id_request_2);
            
            HasMany(e => e.MEMBER)
                .WithRequired(e => e.ЗАЯВКА_ПРЕДОСТАВЛЕНИЯ_ДОСТУПА)
                .HasForeignKey(e => e.ид_заявки_на_создание)
                .WillCascadeOnDelete(false);

            HasMany(e => e.MEMBER1)
                .WithOptional(e => e.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА)
                .HasForeignKey(e => e.ид_заявки_прекращения_доступа);

            HasMany(e => e.VIEW_AC_ACCESS_ORG_1)
                .WithRequired(e => e.ЗАЯВКА_РАЗРЕШЕНИЯ_ДОПУСКА)
                .HasForeignKey(e => e.id_request_1)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.VIEW_AC_ACCESS_ORG_2)
                .WithOptional(e => e.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОПУСКА)
                .HasForeignKey(e => e.id_request_2)
                .WillCascadeOnDelete(false);
            
            HasMany(e=> e.VIEW_OBJECT_USER_RIGHTS_1)
                .WithRequired(e=> e.ЗАЯВКА_ПРЕДОСТАВЛЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ)
                .HasForeignKey(e=> e.id_member_request_1)
                .WillCascadeOnDelete(false);
            
            HasMany(e=> e.VIEW_OBJECT_USER_RIGHTS_2)
                .WithRequired(e=> e.ЗАЯВКА_ПРЕКРАЩЕНИЯ_ДОСТУПА_СУБЪЕКТУ_К_ПРОФИЛЮ)
                .HasForeignKey(e=> e.id_member_request_2)
                .WillCascadeOnDelete(false);*/
        }
    }
}