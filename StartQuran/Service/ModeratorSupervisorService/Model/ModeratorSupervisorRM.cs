using StartQuran.Models.DataBase;
using StartQuran.Service.SupervisorService.Model;
using System;
using tarteel.Models.DataBase;

namespace tarteel.Service.ModeratorTeacherService.Model
{
    public class ModeratorSupervisorRM
    {
        public Guid ID { get; set; }
        public string SupervisorId { get; set; }
        public string ModeratorId { get; set; }
        public Supervisor Supervisor { get; set; }
        public Supervisor Moderator { get; set; }

        public ModeratorSupervisorRM() { }

        public ModeratorSupervisorRM(ModeratorSupervisor model)
        {
            this.ID = model.ID;

            this.SupervisorId = model.SupervisorId;

            this.ModeratorId = model.ModeratorId;
            this.Moderator = model.Moderator;
            this.Supervisor = model.Supervisor;


        }
    }

    
}

