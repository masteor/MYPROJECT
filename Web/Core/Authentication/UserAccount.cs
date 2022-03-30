using System;
using Microsoft.Ajax.Utilities;

namespace QWERTY.Web.Core.Authentication
{
    public interface IUserAccount
    {
        string? Domain { get; set; }
        string? Login { get; set; }
    }
    
    public class UserAccount : IUserAccount
    {
        private string? _login;
        public string? Domain { get; set; }

        public string? Login
        {
            get => _login;
            
            set => _login = value;
        }

        public UserAccount(string domain, string login)
        {
            Domain = domain;
            Login = login;
        }

        public UserAccount(string? domainAccount)
        {
            try
            {
                Domain = "";
                Login = string.IsNullOrEmpty(value: domainAccount) ? "" : domainAccount!.ToLower();

                var parts = string.IsNullOrEmpty(value:domainAccount) 
                    ? new[] { "" } 
                    : domainAccount!.Split(new string[]{"\\"}, StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length <= 1) return;
                
                Domain = parts[0].ToLower();
                Login = parts[1].ToLower();
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e);
                throw;
            }
        }

        public override string ToString()
        {
            return $"Account (Domain={Domain}, Login={Login})";
        }
    }
}