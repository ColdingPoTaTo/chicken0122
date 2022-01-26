using chicken0122.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace chicken0122.Controllers
{
    
    public class HomeController : Controller
    {
        
        dbChicken22Entities db = new dbChicken22Entities();

        // 首頁-取自烤雞
        public ActionResult Index()
        {
            //FormsIdentity id = (FormsIdentity)User.Identity;
            //FormsAuthenticationTicket ticket = id.Ticket;
            //Session["userRoles"] = ticket.UserData;
            return View();
        }
        // 註冊會員
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tMember m)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var member = db.tMember.Where(i => i.fEmail == m.fEmail).FirstOrDefault();
            if (member == null)
            {
                db.tMember.Add(m);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Message = "帳號重複";
            return View();
        }
        // ---

        // 登入會員
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(string fEmail, string fPassword)
        {
            var member = db.tMember.Where(i => i.fEmail == fEmail && i.fPassword == fPassword).FirstOrDefault();
            //if member is null,表示沒註冊
            if (member == null)
            {
                ViewBag.Message = "帳號密碼有誤" + "\n我輸入: " + fEmail + " 密碼: " + fPassword;
                return View();
            }
            string roles = (member.fGroup).ToString() + ",三眼怪";
            string userID = (member.fMemberID).ToString();
            Session["UserName"] = member.fName;
            SetAuthenTicket(roles, userID);
            //指定使用者帳號通過驗證(需要using System.Web.Security)
            //FormsAuthentication.RedirectFromLoginPage(member.Email, true);
            return RedirectToAction("Index", "Home");
        }

        //修改個人資料
        [Authorize]
        public ActionResult personalProfile()
        {
            int myID = Convert.ToInt32(User.Identity.Name);
            var member = db.tMember.Where(i => i.fMemberID == myID).FirstOrDefault();

            return View(member);
        }
        [HttpPost]
        public ActionResult personalProfile(tMember m)
        {
            int myID = Convert.ToInt32(User.Identity.Name);
            var temp = db.tMember.Where(i => i.fMemberID == myID).FirstOrDefault();
            temp.fName = m.fName;
            db.SaveChanges();
            return RedirectToAction("List", "Home");
        }


        // 顯示所有資料
        public ActionResult List()
        {
            var members = db.tMember.OrderBy(m => m.fMemberID).ToList();
            return View(members);
        }
        //public ActionResult Details(int id)
        //{
        //    var members = db.tMember.Where(m => m.fMemberID == id).FirstOrDefault();
        //    return View(members);
        //}

        //public ActionResult Edit(int id)
        //{
        //    tMember member = db.tMember.FirstOrDefault(m => m.fMemberID == id);
        //    if (member == null)
        //        return RedirectToAction("List");
        //    return View(member);
        //}

        //登出
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }

        [Authorize]
        [Authorize(Roles = "gVendor")]
        public ActionResult forGroup3()
        {
            return View();
        }
        [Authorize(Roles = "gCustomer")]
        public ActionResult forGroup2()
        {
            return View();
        }

        // 身分驗證方法
        void SetAuthenTicket(string roles, string userID)
        {
            //宣告一個驗證票
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            1,//版本
            userID,//使用者名稱orID，可以用User.Identity.Name取出
            DateTime.Now,//發行時間
            DateTime.Now.AddMinutes(20),//有效時間，也可以AddHours
            false,//是否將 Cookie 設定成 Session Cookie，如果是則會在瀏覽器關閉後移除。
            roles//寫入使用者角色
            );
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        //從User.Identity.Name取得ID並從DB取得對應姓名
        internal void getUserName(string myName)
        {
             Session["myRoles"] = myName;
            


            //if (true)
            //{
            //    int myID = Convert.ToInt32(User.Identity.Name);
            //    var temp = db.tMember.Where(i => i.fMemberID == myID).FirstOrDefault();                
            //    Session["UserName"] = temp.fName;
            //}
        }

    }
}