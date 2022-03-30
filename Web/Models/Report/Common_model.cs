using System;
using System.Web.Routing;
using DBPSA.Shared.Enums;

namespace DBPSA.Web.Models.Report
{
    public abstract class Common_model
    {
        /// <summary>
        /// 
        /// </summary>
        public string date_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string report_name;
        /// <summary>
        /// 
        /// </summary>
        private int? _report_number;
        public int? report_number
        {
            get => _report_number;
            set {
                _report_number = value;
                if (report_number == null) { throw new NotImplementedException(); }
                report_name = new Отчеты().НазваниеОтчета((int) report_number);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Query_mode? query_mode;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int? _query_mode_number;
        public int? query_mode_number
        {
            get => _query_mode_number;
            set {
                _query_mode_number = value;
                query_mode = (Query_mode?) _query_mode_number;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? GetQueryModeNumber() => (int?) query_mode;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RouteValueDictionary ToRouteValueDictionary()
        {
            throw new NotImplementedException("метод более не используется");
            var routeValues = new RouteValueDictionary
            {
                {$"{nameof(report_number)}", Convert.ToString(report_number)},
                {$"{nameof(query_mode_number)}", Convert.ToString(query_mode_number)},
                // warn: нужно использовать ТОЛЬКО CultureInfo.InvariantCulture, иначе дата не будет передаваться из представления
                {$"{nameof(date_time)}", date_time}, 
                {"test", "test"}
            };
            return routeValues;
        }
    }
}