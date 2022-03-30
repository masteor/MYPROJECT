using System;

namespace DBPSA.Web.Models.Report
{
    public class Query_model : Common_model
    {
        public Query_model()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportNumber"></param>
        /// <param name="dateTime"></param>
        /// <param name="queryModeNumber"></param>
        public Query_model(int? reportNumber, DateTime? dateTime = null, int? queryModeNumber = null) : this()
        {
            report_number = reportNumber;
            date_time = dateTime?.ToShortDateString();
            query_mode_number = queryModeNumber;
        }
    }
}