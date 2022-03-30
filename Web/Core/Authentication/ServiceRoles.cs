using System;
using System.Collections.Generic;
using System.Linq;
using QWERTY.Web.Properties;
using Microsoft.Ajax.Utilities;

namespace QWERTY.Web.Core.Authentication
{
    /// <summary>
    /// Роли сервиса
    /// </summary>
    public static class ServiceRoles
    {
        /// <summary>
        /// Администратор сервиса
        /// </summary>
        public static readonly string Root = Settings.Default.Root;
        // алиас
        public static readonly string Admin = Root;

        public static readonly string Boss = Settings.Default.Boss;

        /// <summary>
        /// Исполнитель заявок
        /// </summary>
        public static readonly string Executor = Settings.Default.Executor;
        
        /// <summary>
        /// Оператор 
        /// </summary>
        public static readonly string Operator = Settings.Default.Operator;
        
        /// <summary>
        /// Пользователь, создавший какие-нибудь заявки
        /// </summary>
        public const string User = "user";
        
        /// <summary>
        /// Аноним, пользователь без логина, который вошёл в сервис вне домена 
        /// </summary>
        public static readonly string Anonim = Settings.Default.Anonim;

        public static readonly string[] Privileged = new[] {Executor,Boss,Root};
        
        
        public static bool IsPrivileged(IEnumerable<string> rolesForUser) 
            => 
                Privileged.Any(s => rolesForUser.Any(r => r == s));
        

        public static bool IsPrivileged(string? domainAccount) 
            =>
            !string.IsNullOrWhiteSpace(domainAccount) 
            && 
            IsPrivileged(new AppRoleProvider().GetRolesForUser(domainAccount));

        
        public static void ThrowIfNotPrivileged(string? domainAccount)
        {
            if (string.IsNullOrWhiteSpace(domainAccount)) throw new ArgumentOutOfRangeException(nameof(domainAccount));
            
            // проверяем привилегии учетки
            if (!IsPrivileged(domainAccount)) throw new Exception("Отсутствуют привилегии");
        }
        
        
        public static void ThrowIfNullOrWhiteSpace(string? domainAccount)
        {
            if (string.IsNullOrWhiteSpace(domainAccount)) throw new ArgumentOutOfRangeException(nameof(domainAccount));
        }
    }
}