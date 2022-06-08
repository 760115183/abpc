using System.Web.Mvc;

namespace Lis.PiYanSuoReport.Web.Controllers
{
    public class HomeController : PiYanSuoReportControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}