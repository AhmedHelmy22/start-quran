using Microsoft.AspNetCore.Identity;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentMarketerService;
using StartQuran.Service.StudentMarketerService.Model;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.StudentTeacherService.Model;
using StartQuran.Service.SupervisorService;
using StartQuran.Service.SupervisorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tarteel.Models.DataBase;
using tarteel.Service.ModeratorTeacherService.Model;

namespace tarteel.Service.ModeratorTeacherManager
{
    public class ModeratorSupervisorManager
    {
        //
        private readonly IRepository<ModeratorSupervisor> _ModeratorSupervisor;
        private readonly IRepository<Teacher> _Teacher;
        private readonly IRepository<Family> _Family;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SupervisorManager _SupervisorManager;
        private readonly StudentManager _StudentManager;
        private readonly FamilyManager _FamilyManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly StudentMarketerManager _StudentMarketerManager;
        public ModeratorSupervisorManager(StudentMarketerManager StudentMarketerManager,StudentTeacherManager StudentTeacherManager,FamilyManager FamilyManager,StudentManager StudentManager, SupervisorManager SupervisorManager, UserManager<ApplicationUser> userManager, IRepository<ModeratorSupervisor> ModeratorSupervisor, IRepository<Teacher> Teacher, IRepository<Family> Family)
        {


            _ModeratorSupervisor = ModeratorSupervisor;
            _Teacher = Teacher;
            _Family = Family;
            _userManager = userManager;
            _SupervisorManager= SupervisorManager;
            _StudentManager= StudentManager;
            _FamilyManager= FamilyManager;
            _StudentTeacherManager= StudentTeacherManager;
            _StudentMarketerManager = StudentMarketerManager;
        }

        #region ModeratorTeacher
        //---------ModeratorTeacher--------------
        #region Get
        public List<ModeratorSupervisorRM> ModeratorSupervisor_GetAll()
        {

            List<ModeratorSupervisor> model = _ModeratorSupervisor.GetAll(c => c.IsDeleted == false, "Moderator").ToList();
            foreach(ModeratorSupervisor rm in model)
            {
                rm.Supervisor = new Supervisor();
                var sup = _SupervisorManager.Get(rm.SupervisorId).Result;
                rm.Supervisor.FullName =sup.FullName;
                rm.Supervisor.Id = sup.Id;

                rm.Moderator = new Supervisor();
                var mod = _SupervisorManager.Get(rm.ModeratorId).Result;
                rm.Moderator.FullName = mod.FullName;
                rm.Moderator.Id = mod.Id;

            }
            return ConvRM(model);
        }

       
        public List<Teacher> TeacherOfSuperVisor_GetAll(string id)
        {

            List<Teacher> model = _Teacher.GetAll(c => c.IsDeleted == false && c.SupervisorId == id, "Supervisor").ToList();
            return model;
        }

        
        public List<ModeratorSupervisorRM> SuperVisorModerator_Moderator_GetAll(string id)
        {

            List<ModeratorSupervisor> model =_ModeratorSupervisor.GetAll(c => c.IsDeleted == false && c.ModeratorId == id, "Moderator,Supervisor").ToList();
            
            return ConvRM(model);
        }

        public List<SupervisorRM> SuperVisor_Moderator_GetAll(string id,bool withme=false)
        {

            List<ModeratorSupervisor> model = _ModeratorSupervisor.Get(c => c.IsDeleted == false && c.ModeratorId == id).ToList();
            List<SupervisorRM> suprs = new List<SupervisorRM>();
            foreach (ModeratorSupervisor rm in model)
            {
                rm.Supervisor = new Supervisor();
                suprs.Add(_SupervisorManager.Get(rm.SupervisorId).Result);
            }
            if (withme == true)
            {
                suprs.Add(_SupervisorManager.Get(id).Result);
            }
            return suprs;
        }

        public List<Teacher> TeacherOfModerator_GetAll(string id, bool withme = false)
        {
            List<ModeratorSupervisorRM> MSRM = SuperVisorModerator_Moderator_GetAll(id);
            List<Teacher> model = new List<Teacher>();
            foreach (var item in MSRM)
            {
                model.AddRange(_Teacher.GetAll(c => c.IsDeleted == false && c.SupervisorId == item.SupervisorId, "Supervisor").ToList());

            }
            if (withme == true)
            {
                model.AddRange(_Teacher.GetAll(c => c.IsDeleted == false && c.SupervisorId == id, "Supervisor").ToList());
            }
            return model;
        }

        public List<Family> FamilyOfModerator_GetAll(string id, bool withme = false)
        {
            List<ModeratorSupervisorRM> MSRM = SuperVisorModerator_Moderator_GetAll(id);
            List<Family> model = new List<Family>();
            foreach (var item in MSRM)
            {
                model.AddRange(_FamilyManager.FamilyOfSuperVisor_GetAll(item.SupervisorId.ToString()));

            }
            if (withme == true)
            {
                model.AddRange(_FamilyManager.FamilyOfSuperVisor_GetAll(id));
            }
            return model;
        }


        public List<Student> StudentOfModerator_GetAll(string id, bool withme = false)
        {
            List<ModeratorSupervisorRM> MSRM = SuperVisorModerator_Moderator_GetAll(id);
            List<Student> model = new List<Student>();
            foreach (var item in MSRM)
            {
                model.AddRange(_StudentManager.StudentOfSupervisor_GetAll(item.SupervisorId.ToString()));

            }
            if (withme == true)
            {
                model.AddRange(_StudentManager.StudentOfSupervisor_GetAll(id));
            }
            return model;
        }


        public List<StudentTeacherRM> StudentTeacherOfModerator_GetAll(string id)
        {
            List<ModeratorSupervisorRM> MSRM = SuperVisorModerator_Moderator_GetAll(id);
            List<StudentTeacherRM> model = new List<StudentTeacherRM>();
            foreach (var item in MSRM)
            {
                model.AddRange(_StudentTeacherManager.SuperVisor_StudentTeacher_GetAll(item.SupervisorId.ToString()));

            }
            return model;
        }


        public List<StudentMarketerVM> StudentMarketerOfModerator_GetAll(string id)
        {
            List<ModeratorSupervisorRM> MSRM = SuperVisorModerator_Moderator_GetAll(id);
            List<StudentMarketerVM> model = new List<StudentMarketerVM>();
            foreach (var item in MSRM)
            {
                model.AddRange(_StudentMarketerManager.StudentMarketer_Supervisor_GetAll(item.SupervisorId.ToString()));

            }
            return model;
        }


        public List<SupervisorRM> SupervisorNotInModerator_GetAll(string id)
        {
            List<SupervisorRM> SPRM = _SupervisorManager.Get().Result.ToList();
            List<SupervisorRM> MSRM = SuperVisor_Moderator_GetAll(id).ToList();
            List<ModeratorSupervisorRM>  SMSRM = ModeratorSupervisor_GetAll();
            List<SupervisorRM> model = new List<SupervisorRM>();
            foreach (SupervisorRM item in SPRM)
            {
                if(MSRM.Where(c=>c.Id==item.Id).Count()==0 && SMSRM.Where(c=>c.SupervisorId==item.Id).Count()==0)
                {
                    model.Add(item);
                }
            }
            return model.ToList();
        }

        public List<Predecessor> PredecessorOfModerator_GetAll(IEnumerable<Predecessor> Predecessors ,  string id)
        {
            List<ModeratorSupervisorRM> MSRM = SuperVisorModerator_Moderator_GetAll(id);
            List<Predecessor> model = new List<Predecessor>();
            foreach (var item in Predecessors)
            {
                if (MSRM.Where(c => c.SupervisorId == item.Teacher.SupervisorId).Count() != 0)
                {
                    model.Add(item);
                }
            }
            foreach (var item in Predecessors)
            {
                if (id == item.Teacher.SupervisorId)
                {
                    model.Add(item);
                }
            }
            return model;
        }

        #endregion


        public async Task<ModeratorSupervisor> ModeratorTeacher_Create(ModeratorSupervisorRM model)
        {
            ModeratorSupervisor modelCreate = new ModeratorSupervisor();
            modelCreate.SupervisorId = model.SupervisorId;
            modelCreate.ModeratorId = model.ModeratorId;
            modelCreate.ID = Guid.NewGuid();
            try
            {
                await _ModeratorSupervisor.Add(modelCreate);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            return modelCreate;
        }


        public async Task<ModeratorSupervisor> ModeratorTeacher_Create(string SupervisorId , string ModeratorId)
        {
            ModeratorSupervisor modelCreate = new ModeratorSupervisor();
            modelCreate.SupervisorId = SupervisorId;
            modelCreate.ModeratorId = ModeratorId;
            modelCreate.ID = Guid.NewGuid();
            try
            {
                await _ModeratorSupervisor.Add(modelCreate);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            return modelCreate;
        }


        public async Task<ModeratorSupervisor> ModeratorTeacher_Delete(Guid id)
        {
            var ModeratorTeacher = _ModeratorSupervisor.FirstOrDefault(c => c.ID == id).Result;
         

            await _ModeratorSupervisor.Remove(ModeratorTeacher);
            return ModeratorTeacher;
        }
        #endregion
        #region
        public List<ModeratorSupervisorRM> ConvRM(List<ModeratorSupervisor> model)
        {
            List<ModeratorSupervisorRM> m = new List<ModeratorSupervisorRM>();

            foreach (var st in model)
            {
                if (!st.IsDeleted)
                {
                    m.Add(new ModeratorSupervisorRM
                    {
                        ID = st.ID,

                        SupervisorId = st.SupervisorId,

                        ModeratorId = st.ModeratorId,
                        Moderator = st.Moderator,
                        Supervisor = st.Supervisor,

                    });
                }
            }
            return m;
        }
        #endregion



        public List<SupervisorRM> ConVSupervisorRM(IEnumerable<Supervisor> users)
        {
            List<SupervisorRM> LsupRM = new List<SupervisorRM>();

            foreach (var sp in users)
            {

                if (!sp.IsDeleted)
                {
                    LsupRM.Add(new SupervisorRM
                    {
                        Id = sp.Id,

                        FullName = sp.FullName,
                        phone = sp.PhoneNumber,
                        Gender = sp.Gender,
                        Age = sp.Age,
                        Governorate = sp.Governorate,
                        //ModeratorId = sp.ModeratorId,
                        //Moderator = sp.Moderator
                    });
                }
            }
            return LsupRM;
        }
    }
}
