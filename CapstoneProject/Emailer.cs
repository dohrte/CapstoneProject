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
            message.To.Add(new MailAddress(emailTo));
            message.Subject = emailSubject;
            message.Body = emailBody;

            SmtpClient client = new SmtpClient();
            client.Host = "localhost";
            client.Send(message);

        }

        public void SendAcctRequest(string subject, string content)
        {
            //to: Admins
            //from: request form
            //subject: acct request
            //body: username that is requesting access to application.


            foreach(string address in this.MailTo() )
            {
                this.SendMail(address, "requestAccess@capstone.edu", subject, content);
            }
            
        }

        private List<string> MailTo()
        {
            List<string> mailList = new List<string>();
            mailList.Add("mldarga@oakland.edu");
            mailList.Add("ecdohert@oakland.edu");
            mailList.Add("stwright@oakland.edu");
            mailList.Add("njlaforg@oakland.edu");

            return mailList;

        }
    }
}
