using chicken0122.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chicken0122.Controllers
{
    public class TestMemberController : Controller
    {
        // GET: TestMember
        public ActionResult Index()
        {
            return View();
        }
        public string testingInsert()
        {
            CMember22 x = new CMember22();
            x.fName = "Tesla";
            x.fEmail = "tesla@gmail.com";
            x.fPassword = "123";
            (new MemberFactory()).Create(x);
            return "PASS";
        }

        public ActionResult List()
        {
            var members = (new MemberFactory()).QueryAll();
            return View(members);
        }
    }
}