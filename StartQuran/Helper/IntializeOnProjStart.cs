
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.Helper
{
    public static class IntializeOnProjStart
    {
        public static async void InitializeAdmin(IServiceProvider serviceProvider, IApplicationBuilder app)
        {
            
                var scope = app.ApplicationServices.CreateScope();


            IdentityContext context = scope.ServiceProvider.GetRequiredService<IdentityContext>();
            UserManager<ApplicationUser> _userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            RoleManager<ApplicationRole> _roleManager = scope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
            IRepository<Tax> _TaxManager = scope.ServiceProvider.GetService<IRepository<Tax>>();
            try
            {
                foreach (var role in Enum.GetValues(typeof(UserType)))
                {
                    if (context.Roles.Where(c => c.Name.ToLower() == role.ToString().ToLower()).Count() == 0)
                    {
                        await _roleManager.CreateAsync(new ApplicationRole
                        {
                            Name = role.ToString(),
                            NormalizedName = role.ToString()
                        });
                    }

                }



                //////////////////////////////////////////////////////////////////////
                var Admin = new ApplicationUser();
                if (context.Users.Where(c => c.Email == "Admin@startquran.com").Count() == 0)
                {
                    Admin = new ApplicationUser()
                    {
                        FullName= "Admin",
                        Age=40,
                        Gender=Enums.Gender.ذكر,
                        Governorate="cairo",
                        UserName = "Admin",
                        Email = "Admin@startquran.com",
                        PhoneNumber = "01156082708",
                        EmailConfirmed = true
                    };
                    await _userManager.CreateAsync(Admin, "123456");
                }
                else
                {
                    Admin = context.Users.Where(c => c.UserName == "Admin").FirstOrDefault();
                }

                await context.SaveChangesAsync();

                await _userManager.AddToRoleAsync(Admin, UserType.ADMIN.ToString());

                //////////////////////////////////////////////////////////////////////
                ///

                //////////////////////////////////////////////////////////////////////
                var Programmer = new ApplicationUser();
                if (context.Users.Where(c => c.Email == "programmer@startquran.com").Count() == 0)
                {
                    Programmer = new ApplicationUser()
                    {
                        FullName = "Programmer",
                        Age = 40,
                        Gender = Enums.Gender.ذكر,
                        Governorate = "cairo",
                        UserName = "Programmer",
                        Email = "programmer@startquran.com",
                        PhoneNumber = "01156082707",
                        EmailConfirmed = true
                    };
                    await _userManager.CreateAsync(Programmer, "123456");
                }
                else
                {
                    Programmer = context.Users.Where(c => c.UserName == "Programmer").FirstOrDefault();
                }

                await context.SaveChangesAsync();

                await _userManager.AddToRoleAsync(Programmer, UserType.ADMIN.ToString());

                //////////////////////////////////////////////////////////////////////
                if (_TaxManager.Get(c => c.IsDeleted == false).Count() == 0)
                {
                    Tax taxmodel = new Tax();
                    taxmodel.tax = 1;
                    await _TaxManager.Add(taxmodel);
                }
                
                

            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }

        }


    }
}
