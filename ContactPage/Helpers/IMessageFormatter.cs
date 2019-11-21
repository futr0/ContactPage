namespace ContactPage.Helpers
{
    public interface IMessageFormatter
    {
        string FormatBody(string senderName, string senderSurname, string senderPhone,
            string message, string senderEmail);
    }
}
