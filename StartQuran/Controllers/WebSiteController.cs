using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using tarteel.Service.RegisterService;
using EmailTest.Service;
using EmailTest.Models;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "PROGRAMMER")]
    public class WebSiteController : Controller
    {
        private readonly RegisterManager _RegistrationFamilyManager;
        private readonly MailService mailService;

        public WebSiteController(RegisterManager RegistrationFamilyManager, MailService mailService)
        {
            this.mailService = mailService;
            _RegistrationFamilyManager = RegistrationFamilyManager;
        }
        public IActionResult Index(string language)
        {
            if (language == null)
            {
                ViewBag.ActionName = nameof(HomeSave);
                return View("WebEN");
            }
            else
            {
                ViewBag.ActionName = nameof(HomeSaveAR);

                return View("WebAR");
            }
                
        }
        //--------------------------------------------------
        #region Get
        [Authorize(Roles = "ADMIN")]
        public IActionResult Home()
        {
            List<RegistrationFamily> MyList = _RegistrationFamilyManager.GetAll() as List<RegistrationFamily>;
            MyList?.Sort((x, y) => y.CreateDate.CompareTo(x.CreateDate));
            return View("Home", MyList);
        }

        [HttpPost]
        public async Task<IActionResult> HomeSave(RegistrationFamily model)
        {


            try
            {

                await _RegistrationFamilyManager.RegistrationFamily_Create(model);
                TempData["AlertMessage"] = "Done";
                await sendmessage(model);
                return RedirectToAction("Index", "website");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "website");
            }
        }

        [HttpPost]
        public async Task<IActionResult> HomeSaveAR(RegistrationFamily model)
        {


            try
            {

                await _RegistrationFamilyManager.RegistrationFamily_Create(model);
                TempData["AlertMessage"] = "Done";
               await sendmessage(model);
                return RedirectToAction("Index", "website", new { language = "AR" });
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "website", new { language = "AR" });
            }
        }

        #endregion

        #region Delete
        [Authorize(Roles = "ADMIN")]

        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {


                await _RegistrationFamilyManager.RegistrationFamily_Delete(Id);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Home", "website");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Home", "website");
            }
        }
        #endregion


        public async Task<IActionResult> IsRead(Guid Id)
        {
            try
            {


                await _RegistrationFamilyManager.RegistrationFamily_read(Id);
                TempData["AlertMessage"] = "DoneRead";
                return RedirectToAction("Home", "website");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "ErrorRead";
                return RedirectToAction("Home", "website");
            }
        }

        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }

        async Task sendmessage(RegistrationFamily model)
        {
            MailRequest request = new MailRequest();
            //request.ToEmail = "start.ayat.academy2023@gmail.com";
            request.ToEmail = "contact@start-quran.com";
            request.Subject = "New Registration Client";
            request.Body = GenerateMessage(model);
            await mailService.SendEmailAsync(request);
        }

        public string GenerateMessage(RegistrationFamily model)
        {

            string msg = "Name : " + model.FullName + "     <br /> ";
            msg += "CountryCode :" + model.CountryCode + "     <br /> ";
            msg += "PhoneNumber :" + model.PhoneNumber + "     <br /> ";
            msg += "Governorate :" + model.WhatsApp + "     <br /> ";
            msg += "WhatsApp :" + model.Message + "     <br /> ";
            msg += "Date :" + DateTime.Now + "    <br /> ";
            return msg;

        }
    }
}
