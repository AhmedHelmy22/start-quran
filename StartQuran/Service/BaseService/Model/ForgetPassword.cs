using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.BaseService.Model
{
    public class ForgetPassword
    {
        [Required(ErrorMessage = "من فضلك أدخل رقم الهاتف المحمول")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "من فضلك أدخل كلمة المرور الجديدة")]

        public string NewPassword { get; set; }
        [Required(ErrorMessage = "من فضلك أدخل تاكيد كلمة المرور")]
        [Compare("NewPassword", ErrorMessage = "تاكيد كلمة المرور لا تساوى كلمة المرور")]
        public string ConfirmPassword { get; set; }

    }
}
