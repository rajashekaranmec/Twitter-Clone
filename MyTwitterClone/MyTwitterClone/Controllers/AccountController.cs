using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Cryptography;
using System.Text;
using MyTwitterClone.Business.Interface;

namespace MyTwitterClone.Controllers
{
    public class AccountController : Controller
    {
        ITwitterClone _ITwitterClone;
        public AccountController(ITwitterClone ITwitterClone)
        {
            _ITwitterClone = ITwitterClone;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Entity.PersonEntity model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var person = new Entity.PersonEntity()
                {
                    user_id = model.user_id,
                    password = model.password
                };
                if (_ITwitterClone.LoginUser(person))
                {
                    Session["UserName"] = model.user_id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
       
        public ActionResult Register()
        {
            ViewBag.IsAuthenticated = false;
            return View();
        }
        [HttpPost]
        public ActionResult Register(Entity.PersonEntity personEntity)
        {
            ViewBag.IsAuthenticated = false;
            personEntity.joined = DateTime.Now;
            _ITwitterClone.AddUser(personEntity);
            return View();
        }
        //
        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}