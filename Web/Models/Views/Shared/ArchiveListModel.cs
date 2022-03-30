using System.Collections.Generic;

namespace DBPSA.Web.Models.Views.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public class ArchiveListModel
    {
        /// <summary>
        /// 
        /// </summary>
        public FilterRequests Filter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Acceptance> Acceptances { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<RequestState> States { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> DepBosses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> KSs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> PPOBosses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> DivBosses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> ExecutorBosses { get; set; }
    }
}