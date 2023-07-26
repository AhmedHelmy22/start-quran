using Microsoft.AspNetCore.Mvc;
using StartQuran.Models.DataBase;
using StartQuran.Service.TaxService;
using System;
using System.Threading.Tasks;

namespace StartQuran.Controllers
{
    public class TaxController : Controller
    {
        private readonly TaxManager _TaxManager;
      
        
        public TaxController( TaxManager TaxManager)
        {
            _TaxManager = TaxManager;
          
        }


        #region Update
        public  IActionResult Update()
        {
            ViewBag.ActionName = nameof(Update);
           
            var Tax = _TaxManager.Get();

            return View("Index", Tax);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Tax model)
        {
            try
            {
                await _TaxManager.Tax_Update(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Update", "Tax");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "Tax");
            }
        }

        #endregion

    }
}
