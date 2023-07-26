using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.PredecessorService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartQuran.Controllers
{
    public class PredecessorController : Controller
    {
        private readonly PredecessorManager _PredecessorManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        //private readonly StudentTeacherManager _StudentTeacherManager;

        public PredecessorController(PredecessorManager PredecessorManager,IRepository<ApplicationUser> AppUser)
        {
            _AppUser = AppUser;
            _PredecessorManager = PredecessorManager;
            //_StudentTeacherManager = StudentTeacherManager;
        }

        #region Get

        public IActionResult Index()
        {
            return View("Index", _PredecessorManager.GetAll());
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            ViewBag.Teacher = new SelectList(_AppUser.Get(c => c.IsDeleted == false && c.usertype == UserType.TEACHER), "Id", "FullName");
            return View("Predecessor", new Predecessor());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Predecessor model)
        {


            try
            {

                await _PredecessorManager.Predecessor_Create(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "Predecessor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "Predecessor");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);

            var Predecessor = _PredecessorManager.Get(id);

            return View("Predecessor", Predecessor);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Predecessor model)
        {

            try
            {

                await _PredecessorManager.Predecessor_Update(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Predecessor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "Predecessor", new { id = model.ID });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {


                await _PredecessorManager.Predecessor_Delete(Id);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Predecessor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Predecessor");
            }
        }
        #endregion
    }
}
