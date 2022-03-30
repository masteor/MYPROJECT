using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class FIO_Configuration : EntityTypeConfiguration<FIO>
    {
        public FIO_Configuration()
        {
            ToTable("_FIO", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.id_user).HasColumnName("ID_USER").IsOptional();
            Property(e => e.family).HasColumnName("NAME_1").HasMaxLength(50).IsRequired();
            Property(e => e.name).HasColumnName("NAME_2").HasMaxLength(50).IsRequired();
            Property(e => e.patronymic).HasColumnName("NAME_3").HasMaxLength(50).IsRequired();
            Property(e => e.id_new).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.ид_заявки_на_создание).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_на_удаление).HasColumnName("ID_REQUEST_2").IsOptional();
            
            /*HasMany(e=> e.EMPLOYEES)
                .WithOptional(e=> e.ФИО)
                .HasForeignKey(e=> e.id_fio)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.FIOs_OLD)
                .WithOptional(e => e.FioNew)
                .HasForeignKey(e => e.id_new);*/
        }
    }
}