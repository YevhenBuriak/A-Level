using System.Net.Mail;

namespace L2;

public class Invoice
{
    public long InvAmount { get; set; }
    public DateTime InvDate { get; set; }
    public void AddInvoice()
    {
        try
        {
            var mailMessage = new MailMessage("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
            SendInvoiceEmail(mailMessage);
        }
        catch (Exception ex)
        {
            File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
        }
    }
    public void DeleteInvoice()
    {
        try
        {
            // logic here
        }
        catch (Exception ex)
        {
            File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
        }
    }
    public void SendInvoiceEmail(MailMessage mailMessage)
    {
        try
        {
            //logic here
        }
        catch (Exception ex)
        {
            File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
        }
    }
}




//------------------------------------------------------------------------//




public class MailSender
{
    public string EMailFrom { get; set; }
    public string EMailTo { get; set; }
    public string EMailSubject { get; set; }
    public string EMailBody { get; set; }
    public void SendEmail()
    {
        //sends email
    }
}

public interface ILogger
{
    void Info(string info);
    void Debug(string info);
    void Error(string message, Exception ex);
}
public class Logger : ILogger
{
    public Logger()
    {
    }
    public void Info(string info)
    {
        // here we need to write the Code for info information into the ErrorLog text file
    }
    public void Debug(string info)
    {
        // here we need to write the Code for Debug information into the ErrorLog text file
    }
    public void Error(string message, Exception ex)
    {
        // here we need to write the Code for Error information into the ErrorLog text file
    }
}