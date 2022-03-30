using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class EMPLOYEE_Configuration : EntityTypeConfiguration<EMPLOYEE>
    {
        
        public EMPLOYEE_Configuration()
        {
            ToTable(ИмяТаблицы.Employee, _EntityBase.SchemaName);

            HasKey(entity => entity.id);
            Property(entity => entity.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            
            Property(entity => entity.tnum).HasColumnName(ИмяКолонки.TNUM).IsRequired();
            Property(entity => entity.job_begin_date).HasColumnName(ИмяКолонки.DATE_1).IsOptional().HasColumnType("date");
            Property(entity => entity.job_end_date).HasColumnName(ИмяКолонки.DATE_2).IsOptional().HasColumnType("date");
            Property(entity => entity.id_form_perm).HasColumnName(ИмяКолонки.ID_FORM_PERM).IsRequired();
            Property(entity => entity.id_job).HasColumnName(ИмяКолонки.ID_JOB).IsRequired();
            Property(entity => entity.ид_актуальной_записи).HasColumnName(ИмяКолонки.ID_NEW).IsOptional();
            Property(entity => entity.ид_заявки_создания).HasColumnName(ИмяКолонки.ID_REQUEST_1).IsOptional();
            Property(entity => entity.ид_заявки_удаления).HasColumnName(ИмяКолонки.ID_REQUEST_2).IsOptional();
            Property(entity => entity.id_fio).HasColumnName(ИмяКолонки.ID_FIO).IsOptional();
            
            /*HasMany(e => e.RESOURCE_RESP)
                .WithRequired(e => e.EMPLOYEE)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.ARM_USER)
                .WithRequired(e => e.СОТРУДНИК)
                .HasForeignKey(e => e.ид_сотрудника)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.AC_ACCESS)
                .WithRequired(e => e.СОТРУДНИК)
                .HasForeignKey(e => e.ид_пользователя)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ПОЛЬЗОВАТЕЛЬ_В_СТРУКТУРЕ)
                .WithRequired(e => e.СОТРУДНИК) 
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            HasMany(e => e.EMPLOYEE_OLD)
                .WithOptional(e => e.АКТУАЛЬНАЯ_ЗАПИСЬ)
                .HasForeignKey(e => e.ид_актуальной_записи);

            HasMany(e => e.ИСТОРИЯ_ФИО)
                .WithOptional(e => e.EMPLOYEE)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            HasMany(e => e.NOTIFY_REQUEST)
                .WithRequired(e => e.EMPLOYEE)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ПОДАННЫЕ_ЗАЯВКИ)
                .WithRequired(e => e.EMPLOYEE2)
                .HasForeignKey(e => e.ид_пользователя_подавшего_заявку)
                .WillCascadeOnDelete(false);

            HasMany(e => e.REQUEST3)
                .WithRequired(e => e.EMPLOYEE3)
                .HasForeignKey(e => e.ид_пользователя_получателя_услуги)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ORG)
                .WithRequired(e => e.БОСС)
                .HasForeignKey(e => e.id_user_boss)
                .WillCascadeOnDelete(false);

            

            HasMany(e => e.RESOURCE)
                .WithRequired(e => e.ВЛАДЕЛЕЦ)
                .HasForeignKey(e => e.ид_владельца)
                .WillCascadeOnDelete(false);

            HasMany(e => e.RESOURCE1)
                .WithRequired(e => e.ОТВЕТСТВЕННЫЙ)
                .HasForeignKey(e => e.ид_ответственного)
                .WillCascadeOnDelete(false);

            

            HasMany(e => e.STAFF_UNIT)
                .WithRequired(e => e.EMPLOYEE)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            HasMany(e => e.USER_ROOM)
                .WithRequired(e => e.EMPLOYEE)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.RSO)
                .WithRequired(e => e.EMPLOYEE)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);*/
        }
    }
}
