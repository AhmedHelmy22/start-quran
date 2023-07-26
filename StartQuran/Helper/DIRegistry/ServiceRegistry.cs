
using EmailTest.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.BaseService;
using StartQuran.Service.FamilyService;
using StartQuran.Service.InvoiceConfirmationService;
using StartQuran.Service.InvoiceService;
using StartQuran.Service.MarketerService;
using StartQuran.Service.PredecessorService;
using StartQuran.Service.Roles;
using StartQuran.Service.SectionService;
using StartQuran.Service.StudentMarketerService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.SupervisorService;
using StartQuran.Service.TaxService;
using StartQuran.Service.TeacherService;
using tarteel.Service.ModeratorTeacherManager;
using tarteel.Service.RegisterService;

namespace StartQuran.Service.DIRegistry
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddServiceRegistry(this IServiceCollection services)
        {
            // repository    
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services    

            services.AddScoped<RoleManager>();

            services.AddScoped<SupervisorManager>();
            services.AddScoped<TeacherManager>();
            services.AddScoped<BaseManager>();
            services.AddScoped<StudentManager>();
            services.AddScoped<FamilyManager>();
            services.AddScoped<StudentTeacherManager>();
            services.AddScoped<StudentMarketerManager>();
            services.AddScoped<SectionManager>();
            services.AddScoped<TaxManager>();
            services.AddScoped<InvoiceManager>();
            services.AddScoped<MarketerManager>();
            services.AddScoped<PredecessorManager>();
            services.AddScoped<InvoiceConfirmationManager>();
            services.AddScoped<ModeratorSupervisorManager>();
            services.AddScoped<RegisterManager>();
            services.AddScoped<MailService>();
            return services;
        }

    }
}
