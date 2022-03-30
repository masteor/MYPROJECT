using System;
using System.Collections;
using System.Collections.Generic;
using QWERTY.Shared.Db.Entities.Представления;

namespace QWERTY.Shared.Db.Компараторы
{
    public class VIEW_REPORT_ALL_RESOURCES__comparer : IEqualityComparer<VIEW_REPORT_ALL_RESOURCES>
    {

        public bool Equals(VIEW_REPORT_ALL_RESOURCES x, VIEW_REPORT_ALL_RESOURCES y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x.GetType() != y.GetType()) return false;
            
            return x.id_resource == y.id_resource;
        }

        public int GetHashCode(VIEW_REPORT_ALL_RESOURCES obj)
        {
            unchecked
            {
                    var hashCode = obj.id_resource;
                    /*hashCode = (hashCode * 397) ^ obj.resource_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.object_type_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.service_type_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.service_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.frag_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.path.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.description.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.secret_type_name.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.login_owner != null ? obj.login_owner.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.owner.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.owner_short_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.owner_org_fname.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.owner_job_name.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.login_responsible != null ? obj.login_responsible.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.responsible.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.responsible_short_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.responsible_org_fname.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.responsible_job_name.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.id_request_type_code_1.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.id_request_type_code_2.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.id_request_1.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.id_request_2.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.parent_1.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.parent_2.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.reg_num.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.create_date_1.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.create_date_2.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.create_request_state.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.end_date_1.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.end_date_2.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.end_request_state.GetHashCode();*/
                    return hashCode;
            }
        }
    }
}