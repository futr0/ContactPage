namespace ContactPage.Helpers
{
    public class EmailMessageFormatter : IMessageFormatter
    {
        public string FormatBody(string senderName, string senderSurname, string senderPhone, string message, string senderEmail)
        {
            return
                $"Message from: {senderName} {senderSurname}\n Text: {message} \n Contact: e-mail: {senderEmail}, phone number: {senderPhone}";
        }
    }
}
