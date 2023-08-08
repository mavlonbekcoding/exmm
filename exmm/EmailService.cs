using System.Net.Mail;
using System.Net;

public class EmailService
{
    public string CredentialAddress { get; init; }
    public string CredentialPassword { get; init; }

    public EmailService(string credentialAddress, string credentialPassword)
    {
        CredentialAddress = credentialAddress;
        CredentialPassword = credentialPassword;
    }

    public void SendEmail(string receiverEmail)
    {
        var mail = new MailMessage(CredentialAddress, receiverEmail);
        mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
        mail.Body = "Hurmatli foydalanuvchi siz sistemadan muvaffaqiyatli o'tdingiz";

        var smtpClient = new SmtpClient("smtp.gmail.com", 587); // Replace with your SMTP server address and port
        smtpClient.Credentials = new NetworkCredential(CredentialAddress, CredentialPassword);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);
    }
}
