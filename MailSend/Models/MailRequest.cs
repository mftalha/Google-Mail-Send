namespace MailSend.Models;

public class MailRequest
{
    public string Name { get; set; } // maili gönderen kişinin ismi
    public string SenderMail { get; set; } //Gönderen
    public string ReceiverMail { get; set; } // alıcı
    public string Subject { get; set; } // başlık
    public string Body { get; set; } // mail içeriği
}
