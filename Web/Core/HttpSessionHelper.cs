using System.Web;
using QWERTY.Shared.Db.Entities.Таблицы;

namespace QWERTY.Web.Core
{
    public class HttpSessionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly HttpSessionStateBase _sessionState;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionState"></param>
        public HttpSessionHelper(HttpSessionStateBase sessionState)
        {
            _sessionState = sessionState;
        }

        /// <summary>
        /// 
        /// </summary>
        public EMPLOYEE CurrentUser
        {
            get { return _sessionState[name: "CurrentEmployee"] as EMPLOYEE; }
            set { _sessionState[name: "CurrentEmployee"] = value; }
        }
        
        public string Login
        {
            get { return _sessionState[name: "CurrentLogin"] as string; }
            set { _sessionState[name: "CurrentLogin"] = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string Action
        {
            get { return _sessionState[name: "LastActionName"] as string; }
            set
            {
                _sessionState[name: "LastActionName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Controller
        {
            get { return _sessionState[name: "LastControllerName"] as string; }
            set
            {
                _sessionState[name: "LastControllerName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddItem<T>(string name, T value)
        {
            _sessionState[name: name] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetItem<T>(string name)
        {
            var val = _sessionState[name: name];
            if (val == null)
            {
                return default(T);
            }
            return (T)val;
        }
    }
}