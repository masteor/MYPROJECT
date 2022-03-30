using System.Diagnostics;
using System.Security.Principal;

namespace QWERTY.Web.Core.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class AuthUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUserLogin()
        {
            var usr = WindowsIdentity.GetCurrent() == null ? "" : WindowsIdentity.GetCurrent().Name;
            Debug.WriteLine(message: $"пользователь: {usr}");
            var parts = string.IsNullOrEmpty(value: usr) ? new[] { "" } : usr.Split('\\');
            return parts.Length > 1 ? parts[1] : parts[0];
        }
    }
}