using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StartQuran.Models.DataBase;
using tarteel.Models.DataBase;

namespace StartQuran.Areas.Identity.Data
{

    public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Marketer> Marketers { get; set; }

        public DbSet<StudentMarketer> StudentMarketers { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<Tax> Tax { get; set; }
        public DbSet<InvoiceConfirmation> InvoiceConfirmation { get; set; }


        public DbSet<Predecessor> Predecessor { get; set; }

        public DbSet<ModeratorSupervisor> ModeratorSupervisor { get; set; }
        public DbSet<RegistrationFamily> RegistrationFamily { get; set; }

    }
}
