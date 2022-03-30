using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class ARM_Configuration : EntityTypeConfiguration<ARM>
    {
        public ARM_Configuration()
        {
            ToTable("_ARM", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();

            Property(e => e.рег_номер_арма).HasColumnName("REG_NUM_ARM").HasMaxLength(50).IsRequired();
            Property(e => e.рег_номер_формуляра).HasColumnName("REG_NUM_LOGBOOK").HasMaxLength(50).IsOptional();
            Property(e => e.ид_помещения).HasColumnName("ID_ROOM").IsOptional();
            Property(e => e.ид_актуальной_записи).HasColumnName("ID_NEW").IsOptional();
            Property(e => e.ид_заявки_постановки_на_учёт).HasColumnName("ID_REQUEST_1").IsOptional();
            Property(e => e.ид_заявки_снятия_с_учёта).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.СТАРЫЕ_АРМЫ)
                .WithOptional(e => e.АКТУАЛЬНЫЙ)
                .HasForeignKey(e => e.ид_актуальной_записи);
            
            HasMany(e => e.УСТРОЙСТВА)
                .WithRequired(e => e.ARM)
                .HasForeignKey(e => e.ид_арма)
                .WillCascadeOnDelete(false);
            
            HasMany(e => e.ДОПУСКИ_СОТРУДНИКОВ)
                .WithRequired(e => e.ARM)
                .HasForeignKey(e => e.ид_арма)
                .WillCascadeOnDelete(false);*/
        }
    }
}