using System.Web.Mvc;
using WE_Asgn_3.DAL;
using WE_Asgn_3.Models;

namespace WE_Asgn_3.Controllers
{
    public class MobileController : Controller
    {
        // GET: Mobile
        public ActionResult Index()
        {
            MobileEntity mobile = new MobileEntity();
            return View(mobile.GetMobiles());
        }
        public ActionResult AddMobile()
        {
            OSEntity oSEntity = new OSEntity();
            ViewBag.osList = oSEntity.getOS();

            return View();
        }
        [HttpPost]
        public ActionResult AddMobile(Mobile mobile)
        {
            OSEntity oSEntity = new OSEntity();
            MobileEntity entity = new MobileEntity();
            ViewBag.osList = oSEntity.getOS();
            if (ModelState.IsValid)
            {
                ViewBag.successMsg = entity.AddMobile(mobile);
                return RedirectToAction("Index");
            }
            return View(mobile);
        }
    }
}