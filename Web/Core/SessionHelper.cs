using System;
using System.Web;

namespace QWERTY.Web.Core
{
    public class SessionHelper
    {
        private readonly HttpSessionStateBase _session;
        //private int _adminArchiveMonth;

        public SessionHelper(HttpSessionStateBase session)
        {
            _session = session;
        }

        public int UserArchiveYear
        {
            get { return (int?) _session[name: "UserArchiveYear"] ?? DateTime.Today.Year; }
            set { _session[name: "UserArchiveYear"] = value; }
        }

        public int UserArchiveMonth
        {
            get { return (int?) _session[name: "UserArchiveMonth"] ?? DateTime.Today.Month; }
            set { _session[name: "UserArchiveMonth"] = value; }
        }

        public int AdminArchiveYear
        {
            get { return (int?) _session[name: "AdminArchiveYear"] ?? DateTime.Today.Year; }
            set { _session[name: "AdminArchiveYear"] = value; }
        }

        public int AdminArchiveMonth
        {
            get { return (int?) _session[name: "AdminArchiveMonth"] ?? DateTime.Today.Month; }
            set { _session[name: "AdminArchiveMonth"] = value; }
        }
    }
}