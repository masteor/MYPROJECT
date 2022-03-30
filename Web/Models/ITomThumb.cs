using QWERTY.Shared.Db.Services;
using QWERTY.Web.Core.Authentication;

namespace QWERTY.Web.Models
{
    public interface ITomThumb
    {
        ICommonService CommonService { get; set; }
        IUserAccount CurrentUserAccount { get; set; }
    }

    public class TomThumb : ITomThumb
    {
        public ICommonService CommonService { get; set; }
        public IUserAccount CurrentUserAccount { get; set; }

        public TomThumb(ICommonService commonService)
        {
            CommonService = commonService;
        }

        public TomThumb()
        {
            return;
        }

    }
}