namespace Dora.School.Controllers
{
    using Core;
    using Domain.Entities.School;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Services.School.Interfaces;
    using System.Linq;

    [Authorize]
    public class ProfessionalController : Controller
    {
        private readonly ILogger _logger;
        private IProfessionalService _ProfessionalService;

        public ProfessionalController(ILoggerFactory loggerFactory, IProfessionalService professionalService)
        {
            this._ProfessionalService = professionalService;
            _logger = loggerFactory.CreateLogger<ProfessionalController>();
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<Professional>(_ProfessionalService.GetAll().Include(b => b.Department)
                .Where(b => string.IsNullOrEmpty(searchKey) || b.ProfessionalId.Contains(searchKey) || b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

        public IActionResult Index1()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult Index4()
        {
            return View();
        }
        public IActionResult Index5()
        {
            return View();
        }
        public IActionResult Index6()
        {
            return View();
        }
        public IActionResult Index7()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
        #region
        public string ManageMessage(ManageMessageId? message = null)
        {
            var StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";
            return StatusMessage;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            AddLoginSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
        #endregion

    }
}