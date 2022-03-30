using QWERTY.Web.Properties;

namespace QWERTY.Web.Core
{
    public interface IConfigHelper
    {
        /*Dictionary<string, string> GetAdsDomains();*/
    }

    internal class ConfigHelper : IConfigHelper
    {
        private readonly Settings _settings;

        public ConfigHelper(QWERTY.Web.Properties.Settings settings)
        {
            _settings = settings;
        }

/*        public Dictionary<string, string> GetAdsDomains()
        {
            var res = new Dictionary<string, string>();
            foreach (var dn in _settings.DomainNames)
            {
                var parts = dn.Split(';');
                if (parts.Length != 2) continue;

                res.Add(parts[0], parts[1]);
            }
            return res;
        }*/
    }
}