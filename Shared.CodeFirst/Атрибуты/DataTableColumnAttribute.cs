using System;

namespace QWERTY.Shared.Атрибуты
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class DataTableColumnAttribute : Attribute  
    {  
        string name;  
        public DataTableColumnAttribute(string name)  
        {  
            this.name = name;  
        }  
        
        public string GetName()  
        {  
            return name;  
        }  
    }
}