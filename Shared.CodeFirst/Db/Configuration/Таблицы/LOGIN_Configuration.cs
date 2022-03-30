using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class LOGIN_Configuration : EntityTypeConfiguration<LOGIN>
    {
        public LOGIN_Configuration()
        {
            ToTable(ИмяТаблицы.Login, _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName(ИмяКолонки.ID).IsRequired();
            
            Property(e => e.name).HasColumnName(ИмяКолонки.NAME).HasMaxLength(50).IsOptional();
            Property(e => e.email).HasColumnName(ИмяКолонки.EMAIL).HasMaxLength(50).IsOptional();
            Property(e => e.id_user).HasColumnName(ИмяКолонки.ID_USER).IsOptional();
            Property(e => e.id_domen).HasColumnName(ИмяКолонки.ID_DOMEN).IsOptional();
            Property(e => e.id_request_0).HasColumnName(ИмяКолонки.ID_REQUEST_0).IsOptional();
            Property(e => e.id_request_1).HasColumnName(ИмяКолонки.ID_REQUEST_1).IsOptional();
            Property(e => e.id_request_2).HasColumnName(ИмяКолонки.ID_REQUEST_2).IsOptional();
            Property(e => e.is_active).HasColumnName(ИмяКолонки.IS_ACTIVE).IsOptional();
        }
    }
}