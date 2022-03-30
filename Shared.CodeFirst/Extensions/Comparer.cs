using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Shared.Extensions
{
    public class Comparer
    {
        public class AC_FRAGMENT__Comparer : IEqualityComparer<AC_FRAGMENT>
        {
            public bool Equals(AC_FRAGMENT r1, AC_FRAGMENT r2)
            {
                // todo: убрать каменты когда будет готова таблица
                /*if ((r1 != null && r2 != null) && (r1.Домен != null && r2.Домен != null))
                    return (r1.ID == r2.ID) && 
                           (r1.FNAME == r2.FNAME) &&  
                            (r1.NAME == r2.NAME) &&
                            (Equals(r1.Домен, r2.Домен));*/
                return false;
            }

            public int GetHashCode(AC_FRAGMENT acF)
            {
                if (acF == null) return 0;
                int hc = acF.id;
                return hc.GetHashCode();
            }
        }
    }

    public class ОдинаковыеПрофилиВ_MEMBER : IEqualityComparer<MEMBER>
    {
        public bool Equals(MEMBER r1, MEMBER r2)
        {
            if (r1 != null && r2 != null)
                return r1.id_profile == r2.id_profile;
            return false;
        }

        public int GetHashCode(MEMBER member)
        {
            return member.id_profile.GetHashCode();
        }
    }
}