using System;
using System.Diagnostics;
using System.Linq;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Entities.Таблицы;
using QWERTY.Shared.Extensions;
using QWERTY.Shared.Models;
using log4net;
using static QWERTY.Shared.Enums.БуквенныеКодыТиповЗаявок;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService // в прошлом IARM_DEVICE_Service
    {
        object ПолучитьСодержимоеЗаявки(ПолучитьСодержимоеЗаявкиМодель модель);
    }

    public partial class Common_Service
    {
        private const string СИЛС = "CИЛС";
        private const string ЗЛИВС = "ЗЛИВС";
        
        public object ПолучитьСодержимоеЗаявки(ПолучитьСодержимоеЗаявкиМодель модель) 
            =>
            модель.requestTypeCode switch
            {
                ЗаявкаНаСозданиеПрофиляДоступа => _ПолучитьПрофильИзПредставления(модель),
                ЗаявкаНаСозданиеЗащищаемогоРесурса => _ПолучитьРесурсИзПредставления(модель, СИЛС),
                ЗаявкаНаСозданиеЗащищаемогоРесурсаЗЛИВС => _ПолучитьРесурсИзПредставления(модель, ЗЛИВС),
                ЗаявкаНаПредоставлениеДоступаСубъектам => _ПолучитьДоступыСубъектов(модель),
                _ => throw new NotImplementedException()
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="м"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private object _ПолучитьДоступыСубъектов(ПолучитьСодержимоеЗаявкиМодель м)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="м"></param>
        /// <param name="типСети"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private object _ПолучитьРесурсИзПредставления(ПолучитьСодержимоеЗаявкиМодель м, string типСети)
        {
            var ресурсИзПредставления = ПолучитьРесурсИзПредставления(
                v => v.id_request_1_parent == м.idRequest)
                ?? throw new Exception($@"Ресурс c id_request_1_parent={м.idRequest} не найден");;

            if (МожноОтдатьТолькоДляПривилегОтветствВладелец(ресурсИзПредставления, м.employee.id, м.isPrivileged)
                .Нет()) throw new Exception("Нет доступа к данным");

            if (типСети == СИЛС)
            {
                return new
                {
                    _resource = new
                    {
                        ресурсИзПредставления.id_request_1,
                        ресурсИзПредставления.id_request_1_parent,
                        ресурсИзПредставления.id_resource,
                        ресурсИзПредставления.resource_name,
                        ресурсИзПредставления.object_type_name,
                        ресурсИзПредставления.service_type_name,
                        ресурсИзПредставления.service_name,
                        ресурсИзПредставления.frag_name,
                        ресурсИзПредставления.secret_type_name,
                        ресурсИзПредставления.path,
                        ресурсИзПредставления.description,
                        ресурсИзПредставления.owner,
                        ресурсИзПредставления.responsible,
                    },
                };
            }
            
            // для ресурса ЗЛИВС подгружаем субъектов допуска
            var сотрудниковДопущенныхКоРесурсуЗливс = 
                ПолучитьСотрудниковДопущенныхКоРесурсуЗЛИВС
                (v => v.id_resource == ресурсИзПредставления.id_resource);

            var оргДопущенныеКоРесурсуЗливс = ПолучитьОргДопущенныеКоРесурсуЗЛИВС
                (v => v.id_resource == ресурсИзПредставления.id_resource);
                
            return new {
                    _resource = new
                    {
                        ресурсИзПредставления.id_request_1,
                        ресурсИзПредставления.id_request_1_parent,
                        ресурсИзПредставления.id_resource,
                        ресурсИзПредставления.resource_name,
                        ресурсИзПредставления.object_type_name,
                        ресурсИзПредставления.service_type_name,
                        ресурсИзПредставления.service_name,
                        ресурсИзПредставления.frag_name,
                        ресурсИзПредставления.secret_type_name,
                        ресурсИзПредставления.path,
                        ресурсИзПредставления.description,
                        ресурсИзПредставления.owner,
                        ресурсИзПредставления.responsible,
                    
                        resource_members = (сотрудниковДопущенныхКоРесурсуЗливс 
                                            ?? Array.Empty<VIEW_RESOURCE_MEMBER_EMPLOYEE>())
                            .Select(v => new
                            {
                                name = v.fio_full
                            }).ToArray(),
                        
                        resource_orgs = (оргДопущенныеКоРесурсуЗливс 
                                         ?? Array.Empty<VIEW_RESOURCE_MEMBER_ORG>())
                            .Select(v => new
                            {
                                name = v.fname
                            }).ToArray()
                    },
                }
            ;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="м"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private object _ПолучитьПрофильИзПредставления(ПолучитьСодержимоеЗаявкиМодель м)
        {
            var profile = ПолучитьПрофильИзПредставления
                          (v => v.id_request_parent == м.idRequest) 
                          ?? throw new Exception ($@"Профиль c id_request_parent={м.idRequest} не найден");

            if (МожноОтдатьТолькоДляПривилегИлиПолучатель(profile, м.employee.id, м.isPrivileged)
                .Нет()) throw new Exception("Нет доступа к данным"); 

            var profileObjectRights = 
                (ПолучитьДанныеИзПредставления_VIEW_PROFILE_OBJECT_RIGHT
                     (v => v.id_profile == profile.id_profile)
                 ?? 
                 Array.Empty<VIEW_PROFILE_OBJECT_RIGHT>())
                .ToList();

            return new {
                _profile = new
                {
                    profile.id_profile,
                    profile.id_request,
                    profile.id_request_parent,
                    profile.object_type_name,
                    profile.frag_name,
                    profile.profile_name,
                    profile.resource_name,
                    profile.secret_type_name,
                    profile.service_type_name,
                        
                    _objects = profileObjectRights
                },
            };
        }
    }
}