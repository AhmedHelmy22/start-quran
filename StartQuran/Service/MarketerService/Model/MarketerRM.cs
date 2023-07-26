using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;

namespace StartQuran.Service.MarketerService.Model
{
    public class MarketerRM
    {

        public string Id { get; set; }

      

        public string fullName { get; set; }

        public string phone { get; set; }

        public string Governorate { get; set; }

        public string password { get; set; }

     
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public double Salary { get; set; }

        public int Ratio { get; set; }
        public MarketerRM() { }

        public MarketerRM(Marketer user)
        {
            this.Id = user.Id;

            this.fullName = user.FullName;
            this.phone = user.PhoneNumber;
            this.Governorate = user.Governorate;
            this.Gender = user.Gender;
            this.Age = user.Age;

            this.Salary = user.Salary;

            this.Ratio= user.Ratio; 
          
        }

    }
}
