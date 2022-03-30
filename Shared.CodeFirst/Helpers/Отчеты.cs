using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DBPSA.Common.Helpers
{
    public class Отчеты
    {
        private List<FieldInfo> fields;
        
        public Отчеты()
        {
            fields = typeof(название_отчета).GetFields().ToList();
        }

        public int НомерОтчета(string названиеОтчета) => fields.FindIndex(r => (string) r.GetValue(fields) == названиеОтчета);

        public string НазваниеОтчета(int номерОтчета)
        {
            try
            {
                return fields[номерОтчета].GetValue(fields).ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public string ПолучитьНазваниеМетодаОбработчика(string названиеОтчета)
        {
            Type t = typeof(название_отчета);
            var sd = t.GetProperties().Where(r=> r.GetCustomAttribute<МетодОбработчикAttribute>().GetName() == названиеОтчета);
            return null; 
            /*sd.GetCustomAttribute<МетодОбработчикAttribute>().GetName();*/
        }
    }
}