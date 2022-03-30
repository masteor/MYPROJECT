using System;
using QWERTY.Shared.Db;

namespace QWERTY.Shared.Extensions.For_Tests
{
    public class EntityClass : Requested
    {
        public EntityClass()
        {
            create_date_1 = null;
            create_date_2 = null;
            create_request_state = null;

            end_date_1 = null;
            end_date_2 = null;
            end_request_state = null;
        }

        public EntityClass(ОбъектПроверки o)
        {
            create_date_1 = o.create_date_1;
            create_date_2 = o.create_date_2;
            create_request_state = o.create_request_state;

            end_date_1 = o.end_date_1;
            end_date_2 = o.end_date_2;
            end_request_state = o.end_request_state;
        }

        public sealed override DateTime? create_date_1 { get; set; }
        public sealed override DateTime? create_date_2 { get; set; }
        public sealed override int? create_request_state { get; set; }
        public sealed override DateTime? end_date_1 { get; set; }
        public sealed override DateTime? end_date_2 { get; set; }
        public sealed override int? end_request_state { get; set; }

    }
}