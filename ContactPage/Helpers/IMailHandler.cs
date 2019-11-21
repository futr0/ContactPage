using System.Threading.Tasks;

namespace ContactPage.Helpers
{
    public interface IMailHandler
    {
        Task SendEmail(string senderName, string senderSurname, string senderEmail,
            string senderPhone, string subject, string message);
        void Configure(string emailAddress, string displayName, string emailPassword, string host, string port);
    }
}
