using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace CapstoneProject
{
  public class Emailer
  {
    private void SendMail(string emailTo, string emailFrom, string emailSubject, string emailBody) 
    {
      MailMessage message = new MailMessage();
      message.From = new MailAddress(emailFrom);
      message.To.Add(new MailAddress("me@domain.com"));
      message.Subject = emailSubject;
      message.Body = emailBody;
      
      SmtpClient client = new SmtpClient();
      client.Host = "127.0.0.1";
      client.Send(message);    

    }

    public void SendAcctRequest(string subject, string content)
    {
      //to: Admins
      //from: request form
      //subject: acct request
      //body: username that is requesting access to application.


      this.SendMail("admins", "requestAccess@capstone.edu", "", content);
    }

  }
}