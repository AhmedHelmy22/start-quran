using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.InvoiceService;
using StartQuran.Service.InvoiceService.Model;
using StartQuran.Service.MarketerService;
using StartQuran.Service.SectionService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StartQuran.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly SectionManager _SectionManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StudentManager _StudentManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly FamilyManager _FamilyManager;
        private readonly MarketerManager _MarketerManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly InvoiceManager _InvoiceManager;

        public InvoiceController(MarketerManager MarketerManager,InvoiceManager InvoiceManager,StudentManager StudentManager, IRepository<ApplicationUser> AppUser, FamilyManager FamilyManager, SectionManager SectionManager, UserManager<ApplicationUser> userManager, StudentTeacherManager StudentTeacherManager)
        {
            _AppUser = AppUser;
            _StudentManager = StudentManager;
            _FamilyManager = FamilyManager;
            _StudentTeacherManager = StudentTeacherManager;
            _SectionManager = SectionManager;
            _userManager = userManager;
            _InvoiceManager = InvoiceManager;
            _MarketerManager = MarketerManager;
        }

        #region Invoice
        public IActionResult Student(Guid Id)
        {
            var invoice = _InvoiceManager.Invoice_Student(Id);
            return View(invoice);
        }

        public IActionResult StudentDate(Guid Id, DateTime Date)
        {
            if (!IsAdmin())
            {
                if (!_InvoiceManager.ChickDateInvoice(Date))
                {
                    TempData["AlertMessage"] = "Error";
                    return RedirectToAction("Student", "Invoice", new { Id = Id });
                }
            }
            var invoice = _InvoiceManager.Invoice_Student(Id, Date);

            return View("Student", invoice);
        }

        public IActionResult Family(Guid Id)
        {
            var invoice = _InvoiceManager.Invoice_Family(Id);
            return View(invoice);
        }
        public IActionResult FamilyDate(Guid Id, DateTime Date)
        {
            if (!IsAdmin())
            {
                if (!_InvoiceManager.ChickDateInvoice(Date))
                {
                    TempData["AlertMessage"] = "Error";
                    return RedirectToAction("Family", "Invoice", new { Id = Id });
                }
            }
            var invoice = _InvoiceManager.Invoice_Family(Id, Date);
            return View("Family", invoice);
        }

        public async Task<IActionResult> Teacher(string Id=null)
        {
            InvoiceTeacher invoice;
            if (Id == null)
            {
                 invoice = await _InvoiceManager.Invoice_Teacher(GitUserId(),DateTime.Now);
            }
            else
            {
                 invoice = await _InvoiceManager.Invoice_Teacher(Id,DateTime.Now);
            }
            
            return View(invoice);
        }

        public async Task<IActionResult> TeacherDate(string Id, DateTime Date)
        {
            InvoiceTeacher invoice;
            if (Id == null)
            {
                invoice = await _InvoiceManager.Invoice_Teacher(GitUserId(), Date);
            }
            else
            {
                invoice = await _InvoiceManager.Invoice_Teacher(Id, Date);
            }
           
            return View("Teacher", invoice);
        }



        public async Task<IActionResult> Marketer(string Id = null)
        {
            InvoiceMarketer invoice;
            if (Id == null)
            {
                invoice = await _InvoiceManager.Invoice_Marketer(GitUserId());
            }
            else
            {
                invoice = await _InvoiceManager.Invoice_Marketer(Id);
            }

            return View(invoice);
        }

        public async Task<IActionResult> MarketerDate(string Id, DateTime Date)
        {
            InvoiceMarketer invoice;
            if (Id == null)
            {
                invoice = await _InvoiceManager.Invoice_Marketer(GitUserId(), Date);
            }
            else
            {
                invoice = await _InvoiceManager.Invoice_Marketer(Id, Date);
            }

            return View("Marketer", invoice);
        }
        #endregion


        #region Total Invoice
        public IActionResult Students()
        {
            var invoice = _InvoiceManager.TotalInvoice_Student();
            return View(invoice);
        }

        public IActionResult StudentsDate(DateTime Date)
        {
            
            var invoice = _InvoiceManager.TotalInvoice_Student(Date);

            return View("Students", invoice);
        }

        public IActionResult Familys()
        {
            var invoice = _InvoiceManager.TotalInvoice_Family();
            return View(invoice);
        }
        public IActionResult FamilysDate( DateTime Date)
        {
          
            var invoice = _InvoiceManager.TotalInvoice_Family( Date);
            return View("Familys", invoice);
        }



        public async Task<IActionResult> Teachers()
        {
            var invoice =  _InvoiceManager.TotalInvoice_Teacher();
            return View(invoice);
        }

        public async Task<IActionResult> TeachersDate( DateTime Date)
        {
            
            var invoice =  _InvoiceManager.TotalInvoice_Teacher(Date);
            return View("Teachers", invoice);
        }
        #endregion


        public async Task<IActionResult> StudentLink()
        {
            return View(_StudentManager.Student_GetAll());
        }


        public async Task<IActionResult> FamilyLink()
        {
            return View(_FamilyManager.GetAll());
        }



        public bool IsSupervisor()
        {
            return User.IsInRole(UserType.SUPERVISOR.ToString());
        }

        public bool IsAdmin()
        {
            return User.IsInRole(UserType.ADMIN.ToString());
        }

        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }
    }
}
