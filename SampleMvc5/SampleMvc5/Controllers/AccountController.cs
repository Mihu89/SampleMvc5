using SampleMvc5.App_Start;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using System.Web;
using System.Threading.Tasks;
using SampleMvc5.ViewModels;
using System;
using SampleMvc5.Models;

namespace SampleMvc5.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {

        }

        public AccountController(ApplicationSignInManager signInManager, ApplicationUserManager userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public ApplicationSignInManager SignInManager {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            set
            {
                _signInManager = value;
            } 
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set
            {
                _userManager = value;
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // Post /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                    break;
                case SignInStatus.LockedOut:
                    return View("Lockout");
                    break;
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    break;
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt");
                    return View(model);
            }
        }

        //Get /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //Post /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberMe);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                    break;
                case SignInStatus.LockedOut:
                    return View("Lockout");
                    break;
                //case SignInStatus.RequiresVerification:
                //    // do something if is needed
                //    break;
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code");
                    return View(model);
            }
        }

        //GET : /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }

        // Get : /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //POST: /Account/ForgotPassword

        private void AddErrors(Microsoft.AspNet.Identity.IdentityResult result)
        {
            throw new NotImplementedException();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            throw new NotImplementedException();
        } 
        private ActionResult SendCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}