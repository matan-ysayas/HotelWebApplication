using HotelWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebApplication.Controllers
{
    public class CEOController : Controller
    {
        public List<CEO> CEOList = new List<CEO>() {new CEO (0,"matan ysayas",25,"kjhgg@gsk.cp.il",30000),new CEO(1,"lior",24,"jhhuu@gamil.com",20000) ,new CEO(2,"asci",24,"wewe@sdsd.com",40000),new CEO(3,"bob",25,"werr@ty.com",3000),new CEO(4,"avner",26,"eeee@dfdf.com",25000)};
        
        // GET: CEO
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCEOName()
        {
            return View(CEOList[4]);
        }

        public ActionResult ShowCEO(int id)
        {
            CEO CEOFound = CEOList.First((item) => item.Id == id);
            
            return View(CEOFound);
        }
    }
}