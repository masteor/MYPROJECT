using System;

namespace QWERTY.Web.Core.Атрибуты
{
    public class МетодОбработчикAttribute : Attribute
    {
        private readonly string _name;

        public МетодОбработчикAttribute(string name)
        {
            _name = name;
        }
        
        public string GetName()  
        {  
            return _name;  
        }
    }
}