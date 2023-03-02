using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SettingApp : MonoBehaviour
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClickRateUs()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }

    public void OnClickPrivacy()
    {
        Application.OpenURL("");
    }

    public void Mail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("myEmail@gmail.com");
        mail.To.Add(new MailAddress("hovanthien13061989@gmail.com"));
        
        mail.Subject = "Contact Baby Sleep";
        mail.Body = "";
        

        SmtpServer.Credentials = new System.Net.NetworkCredential("hovanthien13061989@gmail.com", "MyPasswordGoesHere") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }
}