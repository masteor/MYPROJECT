using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Db.Configuration.Таблицы
{
    public class DOC_Configuration : EntityTypeConfiguration<DOC>
    {
        public DOC_Configuration()
        {
            ToTable("_DOC", _EntityBase.SchemaName);

            HasKey(e => e.id);
            Property(e => e.id).HasColumnName("ID").IsRequired();
            
            Property(e => e.id_doc_type).HasColumnName("ID_DOC_TYPE").IsRequired();
            Property(e => e.path).HasColumnName("PATH").IsRequired();
            
            /*Property(e => e.CONTENTS).HasColumnName("CONTENTS").HasColumnType("BLOB").IsRequired();*/
            
            Property(e => e.date_1).HasColumnName("DATE_1").HasColumnType("DATE").IsRequired();
            Property(e => e.state).HasColumnName("STATE").IsOptional();
            Property(e => e.doc_reg_num).HasColumnName("DOC_REG_NUM").HasMaxLength(50).IsRequired();
            Property(e => e.doc_reg_date).HasColumnName("DOC_REG_DATE").HasColumnType("DATE").IsOptional();
            Property(e => e.id_parent).HasColumnName("ID_PARENT").IsOptional();
            
            Property(e => e.id_request_1).HasColumnName("ID_REQUEST_1").IsRequired();
            Property(e => e.ид_заявки_на_удаление).HasColumnName("ID_REQUEST_2").IsOptional();

            /*HasMany(e => e.DOC_CHILD)
                .WithOptional(e => e.DOC_PARENT)
                .HasForeignKey(e => e.id_parent);*/

            // заявка может ссылаться на документ
            /*HasMany(e => e.REQUEST)
                .WithOptional(e => e.DOC)
                .HasForeignKey(e => e.id_doc);*/
        }
    }
}
