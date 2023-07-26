using Microsoft.AspNetCore.Mvc;
using StartQuran.Models.DataBase;
using StartQuran.Service.InvoiceConfirmationService;
using System;
using System.Threading.Tasks;

namespace StartQuran.Controllers
{
    public class InvoiceConfirmationController : Controller
    {
        private readonly InvoiceConfirmationManager _InvoiceConfirmationManager;
        
        //private readonly StudentTeacherManager _StudentTeacherManager;

        public InvoiceConfirmationController( InvoiceConfirmationManager InvoiceConfirmationManager)
        {

            _InvoiceConfirmationManager = InvoiceConfirmationManager;
            //_StudentTeacherManager = StudentTeacherManager;
        }

        #region Get

        public  IActionResult Index()
        {
            return View("Index", _InvoiceConfirmationManager.GetAll());
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
           
            return View("InvoiceConfirmation", new InvoiceConfirmation());
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceConfirmation model)
        {


            try
            {

                await _InvoiceConfirmationManager.InvoiceConfirmation_Create(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "InvoiceConfirmation");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "InvoiceConfirmation");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);
            
            var InvoiceConfirmation = _InvoiceConfirmationManager.Get(id);

            return View("InvoiceConfirmation", InvoiceConfirmation);

        }

        [HttpPost]
        public async Task<IActionResult> Update(InvoiceConfirmation model)
        {

            try
            {

                await _InvoiceConfirmationManager.InvoiceConfirmation_Update(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "InvoiceConfirmation");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "InvoiceConfirmation", new { id = model.ID });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                
               
                await _InvoiceConfirmationManager.InvoiceConfirmation_Delete(Id);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "InvoiceConfirmation");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "InvoiceConfirmation");
            }
        }
        #endregion

    }
}
