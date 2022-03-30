using System.Collections.Generic;
using System.Diagnostics;

namespace DBPSA.Web.Models.Report
{
    public class AC_ACCESS_model 
    {
        public List<НаименованиеОбъектовСтруктурыОрганизации> Orgs;
        /*public AC_ACCESS_model(string reportName, Query_mode? queryMode = null, DateTime? dateTime = null)
        {
            report_name = reportName;
            date_time = dateTime;
            query_mode = queryMode ?? Query_mode.Все;
        }*/
        /*public AC_ACCESS_model(DateTime? dateTime = null)
        {
            date_time = dateTime;
        }*/

        /*public AC_ACCESS_model(string reportName, DateTime? dateTime = null) : this(dateTime)
        {
            report_name = reportName;
        }*/

        public AC_ACCESS_model()
        {
            Debug.WriteLine($"Активирую пустой конструктор {nameof(AC_ACCESS_model)}");    
        }

        /*public AC_ACCESS_model(Common_model model)
        {
            date_time = model.date_time;
            report_number = model.report_number;
            query_mode_number = model.query_mode_number;
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportNumber"></param>
        /*public AC_ACCESS_model(int? reportNumber) : this()
        {
            report_number = reportNumber;
        }*/
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="reportNumber"></param>
        /// <param name="dateTime"></param>
        /// <param name="queryModeNumber"></param>
        /*public AC_ACCESS_model(int? reportNumber, DateTime? dateTime = null, int? queryModeNumber = null)
        {
            query_mode_number = queryModeNumber;
            date_time = dateTime?.ToShortDateString();
        }*/
        
        /*public AC_ACCESS_model(string reportName, DateTime? dateTime = null, Query_mode? queryModeNumber = null) : this(dateTime, queryModeNumber)
        {
            report_name = reportName;
        }*/
        
        /*public AC_ACCESS_model(string reportName, DateTime? dateTime = null, int? queryModeNumber = null) : this(reportName, dateTime)
        {
            query_mode = queryModeNumber == null ? Query_mode.Все : (Query_mode?) queryModeNumber;
        }
        
        public AC_ACCESS_model(string reportName, DateTime? dateTime = null, Query_mode? queryMode = null) : this(reportName, dateTime)
        {
            query_mode = queryMode ?? Query_mode.Все;
        }*/

        
    }
}