using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecruitmentTracker.Data;
using RecruitmentTracker.Models;
using RecruitmentTracker.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;
        private readonly SaveApplicantInfo saveApplicantInfo;
        private readonly GetApplicantInfo getApplicantInfo;
        private readonly DelApplicantInfo delApplicantInfo;
        private readonly EditApplicantInfo editApplicantInfo;
        private readonly CheckLog checkLog;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AddNewAdminUser addNewAdminUser;

        public HomeController(ILogger<HomeController> logger, MyDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this._logger = logger;
            this._context = dbContext;
            this.saveApplicantInfo = new SaveApplicantInfo();
            this.getApplicantInfo = new GetApplicantInfo();
            this.delApplicantInfo = new DelApplicantInfo();
            this.editApplicantInfo = new EditApplicantInfo();
            this.checkLog = new CheckLog();
            this._httpContextAccessor = httpContextAccessor;
            this.addNewAdminUser = new AddNewAdminUser();
        }

        public IActionResult LoadingScreen()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string FullName, string Email, string Username, string Password)
        {
            var check = this.addNewAdminUser.AddNewAdmin(FullName, Email, Username, Password);

            return Json(new
            {
                check = check
            });
        }

        public IActionResult Logout()
        {
            this._httpContextAccessor.HttpContext.Session.Remove("email");
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        public IActionResult CheckLogin(string email, string password)
        {
            
            var check = this.checkLog.CheckLogin(email, password);
            if (check)
            {
                this._httpContextAccessor.HttpContext.Session.SetString("email", email);
                return Json(new
                {
                    IsValid = true
                });
            }
            return Json(new
            {
                IsValid = false
            });
        }

        public IActionResult Index()
        {
            string IsSession = this._httpContextAccessor.HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(IsSession))
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                ViewBag.data = _context.ApplicantInfo.FromSqlRaw("EXEC pr_ApplicantInfo").ToList();
                return View();
            }
        }

        [HttpPost]
        public IActionResult SaveInfo(ApplicantInfo applicant)
        {
            this.saveApplicantInfo.SaveApplicantInfoService(applicant.ApplicantFirstName, applicant.ApplicantPosition, applicant.ApplicantStatus, applicant.ApplicantStatusDetail, applicant.ApplicantInterview, applicant.ApplicantExpSalary, applicant.ApplicantRecSalary, applicant.ApplicantCurSalary, applicant.ApplicantComment, applicant.ApplicantMiddleName, applicant.ApplicantLastName);

            return Json(new
            {
                msg = true
            });
        }

        [HttpGet]
        public IActionResult GetUserApplicant(int id)
        {
            return Json(new
            {
                list = this.getApplicantInfo.ApplicantInfo(id)
            });
        }

        [HttpPost]
        public IActionResult UpdateApplicant(ApplicantInfo applicant)
        {
            this.editApplicantInfo.UpdateApplicantInfo(applicant.ApplicantId, applicant.ApplicantFirstName, applicant.ApplicantPosition, applicant.ApplicantStatus, applicant.ApplicantStatusDetail, applicant.ApplicantInterview, applicant.ApplicantExpSalary, applicant.ApplicantRecSalary, applicant.ApplicantCurSalary, applicant.ApplicantComment, applicant.ApplicantMiddleName, applicant.ApplicantLastName);
            return Json(new
            {
                check = true
            });
        }

        [HttpPost]
        public IActionResult RemoveApplicant(int id)
        {
            this.delApplicantInfo.RemoveApplicantInfo(id);
            return Json(new
            {
                check = true
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
