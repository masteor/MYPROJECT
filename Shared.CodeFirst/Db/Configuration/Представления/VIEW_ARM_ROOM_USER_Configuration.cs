using System.Data.Entity.ModelConfiguration;
using QWERTY.Shared.Db.Entities;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Configuration.Представления
{
    public class VIEW_ARM_ROOM_USER_Configuration : EntityTypeConfiguration<VIEW_ARM_ROOM_USER>
    {
        public VIEW_ARM_ROOM_USER_Configuration()
        {
            ToTable(ИмяТаблицы.ViewArmRoomUser, _EntityBase.SchemaName);

            HasKey(e => e.id);
            
            Property(e => e.id).HasColumnName("ID").IsRequired();   
            Property(e => e.reg_num_arm).HasColumnName("REG_NUM_ARM").IsRequired();
            Property(e => e.arm_id_new).HasColumnName("ARM_ID_NEW").IsRequired();
            
            Property(e => e.arm_id_request_1).HasColumnName("ARM_ID_REQUEST_1").IsRequired();
            Property(e => e.create_date_1).HasColumnName("CREATE_DATE_1").IsRequired();
            Property(e => e.create_date_2).HasColumnName("CREATE_DATE_2").IsRequired();
            Property(e => e.create_request_state).HasColumnName("CREATE_REQUEST_STATE").IsRequired();
            
            Property(e => e.arm_id_request_2).HasColumnName("ARM_ID_REQUEST_2").IsRequired();
            Property(e => e.end_date_1).HasColumnName("END_DATE_1").IsRequired();
            Property(e => e.end_date_2).HasColumnName("END_DATE_2").IsRequired();
            Property(e => e.end_request_state).HasColumnName("END_REQUEST_STATE").IsRequired();
            
            Property(e => e.reg_num_logbook).HasColumnName("REG_NUM_LOGBOOK").IsRequired();
            Property(e => e.room_num).HasColumnName("ROOM_NUM").IsRequired();
            Property(e => e.building_name).HasColumnName("BUILDING_NAME").IsRequired();
            Property(e => e.prom_area_name).HasColumnName("PROM_AREA_NAME").IsRequired();
            Property(e => e.arm_user_id_user).HasColumnName("ARM_USER_ID_USER").IsRequired();
            Property(e => e.user_room_id_user).HasColumnName("USER_ROOM_ID_USER").IsRequired();
        }   
    }
}