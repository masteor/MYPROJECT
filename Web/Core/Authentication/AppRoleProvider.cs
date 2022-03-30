using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using QWERTY.Shared.Db.Entities.Представления;
using QWERTY.Shared.Db.Services;
using log4net;

namespace QWERTY.Web.Core.Authentication
{
    public class AppRoleProvider : RoleProvider
    {
        private readonly ILog _log = LogManager.GetLogger(name: "AppRoleProvider");
        public override string? ApplicationName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            var roles = GetRolesForUser(domainAccount: username);
            return roles.Any(predicate: role => role == roleName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="domainAccount"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string? domainAccount)
        {
            var roles = new List<string>();
            
            try
            {
                if (string.IsNullOrWhiteSpace(value: domainAccount)) throw new Exception(message: $"username пустое или null");
                
                var account = new UserAccount(domainAccount: domainAccount!);

                if (string.IsNullOrWhiteSpace(value: account.Domain)) throw new Exception(message: $"account.Domain пустое или null");
                if (string.IsNullOrWhiteSpace(value: account.Login)) throw new Exception(message: $"account.Login пустое или null");
                
                var service = DependencyResolver.Current.GetService<ICommonService>();
                
                var staffUnitLogins = (service
                        .ПолучитьРолиСотрудникаПоЛогину(@where: v=> true) ?? Array.Empty<VIEW_STAFF_UNIT_LOGINS>())
                    .Where(predicate: r => r.login.ToLower() == account.Login?.ToLower())
                    .ToList();
                
                staffUnitLogins.ForEach(action: v => roles.Add(item: v.role));
            }
            catch (Exception e)
            {
                _log.Error(message: $"Ошибка запроса ролей для пользователя '{domainAccount}'.{e}");
            }
            
            // если ни одна роль с правами не назначена, тогда назначается бесправная роль анонима
            roles.Add(item: ServiceRoles.User);
            _log.Debug(message: $"Пользователь '{domainAccount}' выполняет роли: [{roles.Aggregate(func: (prev, next) => $"{prev} {next}")}]");
            return roles.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}