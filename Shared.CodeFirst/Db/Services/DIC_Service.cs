using System.Collections.Generic;
using System.Linq;

namespace QWERTY.Shared.Db.Services
{
    public partial interface ICommonService
    {
        List<string>? ПолучитьВсеРусскиеСлова();
        List<string>? ПолучитьВсеАнглийскиеСлова();
    }
    public partial class Common_Service
     {
         public List<string>? ПолучитьВсеРусскиеСлова() => 
            _dicRepository?.GetAll().Select(r => r.rus).ToList();

        public List<string>? ПолучитьВсеАнглийскиеСлова() => 
            _dicRepository?.GetAll().Select(r => r.eng).ToList();
    }
}