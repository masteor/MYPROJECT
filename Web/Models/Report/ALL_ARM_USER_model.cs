using System;

namespace DBPSA.Web.Models.Report
{
    public class ALL_ARM_USER_model
    {
        /*public ALL_ARM_USER_model(string reportName, DateTime? dateTime = null)
        {
            report_name = reportName;
            date_time = dateTime;
            /*datetime = dateTime == null ? DateTime.MinValue : dateTime;#1#
        }*/
        /// <summary>
        /// 
        /// </summary>
        public ALL_ARM_USER_model()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportNumber"></param>
        /// <param name="dateTime"></param>
        public ALL_ARM_USER_model(int reportNumber, DateTime? dateTime = null)
        { 
            report_number = reportNumber;
            date_time = Convert.ToString(dateTime);
            /*datetime = dateTime == null ? DateTime.MinValue : dateTime;*/
        }
    }
}