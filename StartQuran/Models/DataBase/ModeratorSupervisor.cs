using StartQuran.Models.DataBase;
using StartQuran.Models.Helper;
using System;
namespace tarteel.Models.DataBase
{
    public class ModeratorSupervisor : Base
    {
        public string SupervisorId { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public string ModeratorId { get; set; }
        public virtual Supervisor Moderator { get; set; }
    }
}
