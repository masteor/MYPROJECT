using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Services;
using QWERTY.Shared.Doc;
using log4net;

namespace QWERTY.Shared.Models.Заявки
{
    interface IДокумент_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
    {
        
    }
    
    public class Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель : Документы, IДокумент_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
    {
        public string ObjectName { get; set; } = "";
        public string ObjectTypeName { get; set; } = "";
        public string SecretTypeName { get; set; } = "";
        // public string[]? ResourceUca { get; set; }
        public string ResourceDescription { get; set; } = "";
        public string ResourceResponsibleFullName { get; set; } = "";
        public string ResponsibleJobName { get; set; } = "";
        public string ResponsibleOrgFname { get; set; } = "";
        
        public string ResourceResponsibleShortName { get; set; } = "";
        public string OwnerOrgFname { get; set; } = "";
        public string OwnerShortName { get; set; } = "";
        
        public List<RESOURCE_MEMBER_DOC>? ResourceMemberEmployees { get; set; }
        
        public List<string>? ResourceMemberOrgs { get; set; }
        
        
        public Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель()
        {
            
        }

        public Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель (
            VIEW_REPORT_ALL_RESOURCES? _,
            List<RESOURCE_MEMBER_DOC>? допущенныеСотрудники,
            List<string> допущенныеОрг
        )
        {
            ObjectName = _.resource_name;
            ObjectTypeName = _.object_type_name;
            SecretTypeName = _.secret_type_name;
            ResourceDescription = _.description;
            ResourceResponsibleFullName = _.responsible;
            ResponsibleJobName = _.responsible_job_name;
            ResponsibleOrgFname = _.responsible_org_fname;
            ResourceMemberEmployees = допущенныеСотрудники;
            ResourceMemberOrgs = допущенныеОрг;
            ResourceResponsibleShortName = _.responsible_short_name;
            OwnerOrgFname = _.owner_org_fname;
            OwnerShortName = _.owner_short_name;
        }

        public Документ_СозданиеЗащищаемогоРесурсаЗЛИВС_модель
            (ICommonService? commonService, ILog? log, int ресурсId)
        {
            var _ = commonService?
                .ПолучитьРесурсИзПредставления(v => v.id_resource == ресурсId);
                
            var допущенныеСотрудники = 
                (commonService?.ПолучитьСотрудниковДопущенныхКоРесурсуЗЛИВС
                     (v => v.id_resource == ресурсId)
                 ?? 
                    Array.Empty<VIEW_RESOURCE_MEMBER_EMPLOYEE>())
                .Select(r => new RESOURCE_MEMBER_DOC
                {
                    Fullname = r.fio_full,
                    JobName = r.job_name,
                    OrgFname = r.org_fname
                })
                .ToList();
            
            var допущенныеОрг = 
                (commonService?.ПолучитьОргДопущенныеКоРесурсуЗЛИВС
                     (v => v.id_resource == ресурсId)
                 ?? Array.Empty<VIEW_RESOURCE_MEMBER_ORG>())
                .Select(r => r.fname)
                .ToList();
            
            ObjectName = _.resource_name;
            ObjectTypeName = _.object_type_name;
            SecretTypeName = _.secret_type_name;
            ResourceDescription = _.description;
            ResourceResponsibleFullName = _.responsible;
            ResponsibleJobName = _.responsible_job_name;
            ResponsibleOrgFname = _.responsible_org_fname;
            ResourceMemberEmployees = допущенныеСотрудники;
            ResourceMemberOrgs = допущенныеОрг;
            ResourceResponsibleShortName = _.responsible_short_name;
            OwnerOrgFname = _.owner_org_fname;
            OwnerShortName = _.owner_short_name;
        }

        
    }
}