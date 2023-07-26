using EmailTest.Models;
using System.Threading.Tasks;

namespace EmailTest.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
  