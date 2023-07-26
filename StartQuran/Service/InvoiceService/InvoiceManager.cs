using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.InvoiceConfirmationService;
using StartQuran.Service.InvoiceService.Model;
using StartQuran.Service.MarketerService;
using StartQuran.Service.MarketerService.Model;
using StartQuran.Service.PredecessorService;
using StartQuran.Service.StudentService;
using StartQuran.Service.TaxService;
using StartQuran.Service.TeacherService;
using StartQuran.Service.TeacherService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartQuran.Service.InvoiceService
{
    public class InvoiceManager
    {
        private readonly IRepository<Section> _Section;
        private readonly TeacherManager _TeacherManager;
        private readonly FamilyManager _FamilyManager;
        private readonly MarketerManager _MarketerManager;
        private readonly StudentManager _StudentManager;
        private readonly TaxManager _TaxManager;
        private readonly InvoiceConfirmationManager _InvoiceConfirmation;
        private readonly PredecessorManager _PredecessorManager;
        public InvoiceManager(MarketerManager MarketerManager, PredecessorManager PredecessorManager ,FamilyManager FamilyManager,TaxManager TaxManager,IRepository<Section> Section, TeacherManager TeacherManager, StudentManager StudentManager, InvoiceConfirmationManager InvoiceConfirmation)
        {
            _Section = Section;
            _TeacherManager = TeacherManager;
            _StudentManager = StudentManager;
            _InvoiceConfirmation = InvoiceConfirmation;
            _TaxManager = TaxManager;
            _FamilyManager = FamilyManager;
            _PredecessorManager = PredecessorManager;
            _MarketerManager = MarketerManager;
        }

        public InvoiceStudent Invoice_Student(Guid StudentID)
        {
            InvoiceStudent InvStu = new InvoiceStudent();

            List<Section> StudentSection; 
            InvStu.Student = _StudentManager.Student_Get(StudentID);
            InvStu.date = InvoiceDate();
            InvStu.Tax = _TaxManager.Get().tax;
            StudentSection = StudentSections(StudentID, InvStu.date);
            InvStu.Sections = StudentSection;
            InvStu.NumOfSection = StudentSection.Count;
            InvStu.NumOfHour =StudentSection.Sum(c => c.NumberOfHours) / 60.0;
            InvStu.Cach = InvStu.Student.PriceOfHour * InvStu.NumOfHour;
            InvStu.TotalTax = (InvStu.Cach * InvStu.Tax / 100);
            InvStu.TotalPayMent = InvStu.Cach + InvStu.TotalTax;
            return InvStu;
        }

        public InvoiceStudent Invoice_Student(Guid StudentID,DateTime Date)
        {
            InvoiceStudent InvStu = new InvoiceStudent();
            List<Section> StudentSection;
            InvStu.Student = _StudentManager.Student_Get(StudentID);
            InvStu.date = Date;
            InvStu.Tax = _TaxManager.Get().tax;
            StudentSection = StudentSections(StudentID, InvStu.date);
            InvStu.Sections = StudentSection;
            InvStu.NumOfSection = StudentSection.Count;
            InvStu.NumOfHour = StudentSection.Sum(c => c.NumberOfHours) / 60.0;
            InvStu.Cach = InvStu.Student.PriceOfHour * InvStu.NumOfHour;
            InvStu.TotalTax = (InvStu.Cach * InvStu.Tax / 100);
            InvStu.TotalPayMent = InvStu.Cach + InvStu.TotalTax;
            return InvStu;
        }

        public InvoiceFamily Invoice_Family(Guid FamilyID)
        {
            List<Section> StudentSection;
            InvoiceFamily Invfam = new InvoiceFamily();
            Invfam.Family = _FamilyManager.Family_Get(FamilyID);
            Invfam.date = InvoiceDate();
            Invfam.Tax = _TaxManager.Get().tax;
            Invfam.Sections = new List<Section>();
            foreach(var Student in Invfam.Family.Student)
            {
                StudentSection = StudentSections(Student.ID, Invfam.date);
                Invfam.Sections.AddRange(StudentSection);
                Invfam.NumOfSection += StudentSection.Count;
                Invfam.NumOfHour += StudentSection.Sum(c => c.NumberOfHours) / 60.0;
                Invfam.Cach += Student.PriceOfHour * (StudentSection.Sum(c => c.NumberOfHours) / 60.0);
                Invfam.PricePerHour = Student.PriceOfHour;
               
            }
            Invfam.TotalTax = (Invfam.Cach * Invfam.Tax / 100);
            Invfam.TotalPayMent = Invfam.Cach + Invfam.TotalTax;
            Invfam.TotalPayMent = Math.Round(Invfam.TotalPayMent, 2);

            Invfam.Message = WhatsAppMessage(Invfam);
            Invfam.MessageEN = WhatsAppMessageEN(Invfam);
            return Invfam;
        }

        public InvoiceFamily Invoice_Family(Guid FamilyID, DateTime Date)
        {
            List<Section> StudentSection;
            InvoiceFamily Invfam = new InvoiceFamily();
            Invfam.Family = _FamilyManager.Family_Get(FamilyID);
            Invfam.date = Date;
            Invfam.Tax = _TaxManager.Get().tax;
            Invfam.Sections = new List<Section>();
            foreach (var Student in Invfam.Family.Student)
            {
                StudentSection = StudentSections(Student.ID, Invfam.date);
                Invfam.Sections.AddRange(StudentSection);
                Invfam.NumOfSection += StudentSection.Count;
                Invfam.NumOfHour += StudentSection.Sum(c => c.NumberOfHours) / 60.0;
                Invfam.Cach += Student.PriceOfHour  *(StudentSection.Sum(c => c.NumberOfHours) / 60.0);
                Invfam.PricePerHour = Student.PriceOfHour;

            }
            Invfam.TotalTax = (Invfam.Cach * Invfam.Tax / 100);
            Invfam.TotalPayMent = Invfam.Cach + Invfam.TotalTax;
            Invfam.TotalPayMent = Math.Round(Invfam.TotalPayMent, 2);
            Invfam.Message = WhatsAppMessage(Invfam);
            Invfam.MessageEN = WhatsAppMessageEN(Invfam);
            return Invfam;
        }

        public async Task<InvoiceTeacher> Invoice_Teacher(string TeacherID, DateTime Date)
        {
            InvoiceTeacher InvTea = new InvoiceTeacher();

            List<Section> TeacherSection;
            InvTea.Teacher = await _TeacherManager.Get(TeacherID);
            InvTea.date = Date; //InvoiceDate();
            InvTea.Tax = 0;
            TeacherSection = TeacherSections(TeacherID, InvTea.date);
            InvTea.Sections = TeacherSection;
            InvTea.NumOfSection = TeacherSection.Count;
            InvTea.NumOfHour = TeacherSection.Sum(c => c.NumberOfHours) / 60.0;
            InvTea.Cach = InvTea.Teacher.SallaryBerHour * InvTea.NumOfHour;
            InvTea.TotalTax = 0;
            InvTea.TotalPredecessor = TotalPredecessorTeacher(TeacherID, Date);
            InvTea.TotalPayMent = InvTea.Cach + InvTea.TotalTax - InvTea.TotalPredecessor;
            return InvTea;
        }

        //public async Task<InvoiceTeacher> Invoice_Teacher(string TeacherID, DateTime Date)
        //{
        //    InvoiceTeacher InvTea = new InvoiceTeacher();

        //    List<Section> TeacherSection;
        //    InvTea.Teacher = await _TeacherManager.Get(TeacherID);
        //    InvTea.date = Date;
        //    InvTea.Tax = 0;
        //    TeacherSection = TeacherSections(TeacherID, InvTea.date);
        //    InvTea.Sections = TeacherSection;
        //    InvTea.NumOfSection = TeacherSection.Count;
        //    InvTea.NumOfHour = TeacherSection.Sum(c => c.NumberOfHours) / 60.0;
        //    InvTea.Cach = InvTea.Teacher.SallaryBerHour * InvTea.NumOfHour;
        //    InvTea.TotalTax = 0;
        //    InvTea.TotalPredecessor = TotalPredecessorTeacher(TeacherID, Date);
        //    InvTea.TotalPayMent = InvTea.Cach + InvTea.TotalTax - InvTea.TotalPredecessor;
        //    return InvTea;
        //}

        public async Task<InvoiceMarketer> Invoice_Marketer(string MarketerID)
        {
            InvoiceMarketer InvMar = new InvoiceMarketer();
            InvMar.Marketer = await _MarketerManager.Get(MarketerID);

            var MarStus = await _MarketerManager.StudentMarketet_Get(MarketerID);

            if (MarStus == null) return InvMar;
            else
            {
                foreach (var Mar in MarStus)
                {
                    if (Mar == null) continue;
                    else
                    {
                        
                       var InvStu = Invoice_Student(Mar.ID);

                        InvMar.InvoiceStudent.Add(InvStu);
                        InvMar.Cash += ((InvStu.Cach* InvMar.Marketer.Ratio) /100.0);
                        
                    }
                }
                InvMar.Salary = InvMar.Marketer.Salary;
                InvMar.totalCash = InvMar.Cash + InvMar.Salary;
            }
            return InvMar;
        }
        public async Task<InvoiceMarketer> Invoice_Marketer(string MarketerID,DateTime Date)
        {
            InvoiceMarketer InvMar = new InvoiceMarketer();
            InvMar.Marketer = await _MarketerManager.Get(MarketerID);

            var MarStus = await _MarketerManager.StudentMarketet_Get(MarketerID);

            if (MarStus == null) return InvMar;
            else
            {
                foreach (var Mar in MarStus)
                {
                    if (Mar == null) continue;
                    else
                    {
                        var InvStu = Invoice_Student(Mar.ID,Date);

                        InvMar.InvoiceStudent.Add(InvStu);
                        InvMar.Cash += ((InvStu.Cach * InvMar.Marketer.Ratio) / 100.0);
                    }
                }
            
                InvMar.Salary = InvMar.Marketer.Salary;
                InvMar.totalCash = InvMar.Cash + InvMar.Salary;
            }
            return InvMar;
        }
        //-----------------------------------------------------
        public TotalStudentInvoice TotalInvoice_Student() 
        {
                TotalStudentInvoice totalSInvoice = new TotalStudentInvoice();
                totalSInvoice.InvoiceStudent = new List<InvoiceStudent>();
                List<Student> LStu = _StudentManager.Student_GetAll(true).ToList();

                foreach (Student student in LStu)
                {
                    totalSInvoice.InvoiceStudent.Add(Invoice_Student(student.ID));
                }

            totalSInvoice.NumOfSection = totalSInvoice.InvoiceStudent.Sum(c => c.NumOfSection);
            totalSInvoice.NumOfHour = totalSInvoice.InvoiceStudent.Sum(c => c.NumOfHour);
            totalSInvoice.TotalPayMent = totalSInvoice.InvoiceStudent.Where(c=>c.NumOfSection>0).Sum(c => c.TotalPayMent);
            return totalSInvoice;

             
        }

        public TotalStudentInvoice TotalInvoice_Student(DateTime Date)
        {
            TotalStudentInvoice totalSInvoice = new TotalStudentInvoice();
            totalSInvoice.InvoiceStudent = new List<InvoiceStudent>();
            List<Student> LStu = _StudentManager.Student_GetAll().ToList();

            foreach (Student student in LStu)
            {
                totalSInvoice.InvoiceStudent.Add(Invoice_Student(student.ID,Date));
            }

            totalSInvoice.NumOfSection = totalSInvoice.InvoiceStudent.Sum(c => c.NumOfSection);
            totalSInvoice.NumOfHour = totalSInvoice.InvoiceStudent.Sum(c => c.NumOfHour);
            totalSInvoice.TotalPayMent = totalSInvoice.InvoiceStudent.Where(c => c.NumOfSection > 0).Sum(c => c.TotalPayMent);
            return totalSInvoice;


        }

        public TotalFamilyInvoice TotalInvoice_Family()
        {
            TotalFamilyInvoice totalFInvoice = new TotalFamilyInvoice();
            totalFInvoice.InvoiceFamily = new List<InvoiceFamily>();
            List<Family> Lfam = _FamilyManager.GetAll().ToList();

            foreach (Family family in Lfam)
            {
                totalFInvoice.InvoiceFamily.Add(Invoice_Family(family.ID));
            }

            totalFInvoice.NumOfSection = totalFInvoice.InvoiceFamily.Sum(c => c.NumOfSection);
            totalFInvoice.NumOfHour = totalFInvoice.InvoiceFamily.Sum(c => c.NumOfHour);
            totalFInvoice.TotalPayMent = totalFInvoice.InvoiceFamily.Where(c => c.NumOfSection > 0).Sum(c => c.TotalPayMent);
            return totalFInvoice;


        }
        public TotalFamilyInvoice TotalInvoice_Family(DateTime Date)
        {
            TotalFamilyInvoice totalFInvoice = new TotalFamilyInvoice();
            totalFInvoice.InvoiceFamily = new List<InvoiceFamily>();
            List<Family> Lfam = _FamilyManager.GetAll().ToList();

            foreach (Family family in Lfam)
            {
                totalFInvoice.InvoiceFamily.Add(Invoice_Family(family.ID,Date));
            }

            totalFInvoice.NumOfSection = totalFInvoice.InvoiceFamily.Sum(c => c.NumOfSection);
            totalFInvoice.NumOfHour = totalFInvoice.InvoiceFamily.Sum(c => c.NumOfHour);
            totalFInvoice.TotalPayMent = totalFInvoice.InvoiceFamily.Where(c => c.NumOfSection > 0).Sum(c => c.TotalPayMent);
            return totalFInvoice;


        }

        public TotalTeacherInvoice TotalInvoice_Teacher()
        {
            TotalTeacherInvoice totalInvoice = new TotalTeacherInvoice();
            totalInvoice.InvoiceTeacher = new List<InvoiceTeacher>();
            List<TeacherRM> Lteach = _TeacherManager.Get().Result;

            foreach (TeacherRM teacher in Lteach)
            {
                totalInvoice.InvoiceTeacher.Add(Invoice_Teacher(teacher.Id,DateTime.Now).Result);
            }

            totalInvoice.NumOfSection = totalInvoice.InvoiceTeacher.Sum(c => c.NumOfSection);
            totalInvoice.NumOfHour = totalInvoice.InvoiceTeacher.Sum(c => c.NumOfHour);

            totalInvoice.TotalPredecessor = totalInvoice.InvoiceTeacher.Sum(c => c.TotalPredecessor);

            totalInvoice.TotalPayMent = totalInvoice.InvoiceTeacher.Where(c => c.NumOfSection > 0).Sum(c => c.TotalPayMent);

            totalInvoice.TotalMarketer = TotalMarketer(DateTime.Now);

            totalInvoice.Total = totalInvoice.TotalPayMent - totalInvoice.TotalPredecessor + totalInvoice.TotalMarketer;

            return totalInvoice;

        }
        public TotalTeacherInvoice TotalInvoice_Teacher(DateTime Date)
        {
            TotalTeacherInvoice totalInvoice = new TotalTeacherInvoice();
            totalInvoice.InvoiceTeacher = new List<InvoiceTeacher>();
            List<TeacherRM> Lteach = _TeacherManager.Get().Result;

            foreach (TeacherRM teacher in Lteach)
            {
                totalInvoice.InvoiceTeacher.Add(Invoice_Teacher(teacher.Id, Date).Result);
            }

            totalInvoice.NumOfSection = totalInvoice.InvoiceTeacher.Sum(c => c.NumOfSection);
            totalInvoice.NumOfHour = totalInvoice.InvoiceTeacher.Sum(c => c.NumOfHour);


            totalInvoice.TotalPredecessor = totalInvoice.InvoiceTeacher.Sum(c => c.TotalPredecessor);


            totalInvoice.TotalPayMent = totalInvoice.InvoiceTeacher.Where(c => c.NumOfSection > 0).Sum(c => c.TotalPayMent);


            totalInvoice.TotalMarketer = TotalMarketer(Date);

            totalInvoice.Total = totalInvoice.TotalPayMent - totalInvoice.TotalPredecessor + totalInvoice.TotalMarketer;
            totalInvoice.date = Date;
            return totalInvoice;


        }

        #region Helper

        public bool ChickDateInvoice(DateTime RequestDate)
        {
            if (_InvoiceConfirmation.GetAll().Count() == 0)
            {
                return false;
            }
            return _InvoiceConfirmation.GetAll().Where(c => c.InvoiceDate.Year == RequestDate.Year && c.InvoiceDate.Month == RequestDate.Month).Count() > 0;
        }

        public DateTime InvoiceDate()
        {
            if (_InvoiceConfirmation.GetAll().Count() == 0)
            {
                return DateTime.Now; 
            }
            return _InvoiceConfirmation.GetAll().OrderByDescending(c=>c.InvoiceDate).FirstOrDefault().InvoiceDate;
        }

        public List<Section> StudentSections(Guid Id,DateTime date)
        {

           return _Section.GetAll(c => c.StudentId == Id && c.IsDeleted == false&&c.SectionDate.Year==date.Year&&c.SectionDate.Month==date.Month, "Student,Teacher").ToList(); 

        }

        public List<Section> TeacherSections(string Id, DateTime date)
        {

            return _Section.GetAll(c => c.TeacherId == Id && c.IsDeleted == false && c.SectionDate.Year == date.Year && c.SectionDate.Month == date.Month, "Student,Teacher").ToList();

        }


        public double TotalPredecessorTeacher(string TeacherId , DateTime Date)
        {
          return  _PredecessorManager.GetAll().Where(c=>c.TeacherId==TeacherId && c.Date.Year==Date.Year && c.Date.Month == Date.Month).Sum(c=>c.Cash);
        }
        public double TotalPredecessor( DateTime Date)
        {
            return _PredecessorManager.GetAll().Where(c=>c.Date.Year == Date.Year && c.Date.Month == Date.Month).Sum(c => c.Cash);
        }

        public double TotalMarketer(DateTime Date)
        {
            double total = 0;
            List<MarketerRM> marks = _MarketerManager.Get().Result;
            foreach (var item in marks)
            {
                total += Invoice_Marketer(item.Id, Date).Result.totalCash;
            }

            return total;
        }

        #endregion

        public string WhatsAppMessage(InvoiceFamily model)
        {
            StringBuilder message = new StringBuilder();
            message.Append("السلام عليكم ورحمة الله وبركاته");
            message.Append("%0a");
            message.Append("🌹الإدارة المالية لمركز ستارت قران  تتمنى لكم التوفيق🌹");
            message.Append("%0a");
            message.Append("تم اصدار فاتورة شهر ");
            message.Append(model.date.Month);
            message.Append("%0a");          
            message.Append("إجمالي المستحقات  لهذا الشهر ");
            message.Append(model.TotalPayMent);
            message.Append("%0a");
            message.Append("يمكنكم مراجعة الفاتورة من خلال هذا الرابط");
            message.Append("%0a");
            message.Append("http://startquran-001-site1.atempurl.com/Invoice/Family?id=" + model.Family.ID);
            message.Append("%0a");
            message.Append("🌹 وجزاكم الله خيرا  🌹");
            message.Append("%0a");

            return message.ToString();



        }

        public string WhatsAppMessageEN(InvoiceFamily model)
        {
            StringBuilder message = new StringBuilder();
            message.Append("May the peace, blessings, and mercy of God be upon you");
            message.Append("%0a");
            message.Append("🌹The financial management of Start Ayat Center wishes you success🌹");
            message.Append("%0a");
            message.Append("A monthly bill has been issued ");
            message.Append(model.date.Month);
            message.Append("%0a");
            message.Append("Total dues for the month ");
            message.Append(model.TotalPayMent);
            message.Append("%0a");
            message.Append("You can review the invoice through this link ");
            message.Append("%0a");
            message.Append("http://start-ayat.com/Invoice/Family?id=" + model.Family.ID);
            message.Append("%0a");
            message.Append("🌹 And God reward you with good  🌹");
            message.Append("%0a");

            return message.ToString();



        }
    }
}
