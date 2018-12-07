using System;
using System.Linq;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using System.Net.Mail;
using System.Net;


namespace fa18Team28_FinalProject.Utilities
{
    public static class EmailMessaging
    {
        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {
            //Create an email client to send the emails
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                //This is the SENDING email address and password
                Credentials = new NetworkCredential("team28bevosbookstore@gmail.com", "MISpassword123"),
                EnableSsl = true
            };
            //Add anything that you need to the body of the message
            // /n is a new line – this will add some white space after the main body of the message
            String finalMessage = emailBody + "\n\n Welcome to Bevos Books! Enjoy your book! \nSincerely, Team 28 at Bevo's Books";


            //Create an email address object for the sender address
            MailAddress senderEmail = new MailAddress("team28bevosbookstore@gmail.com", "MISpassword123");
            MailMessage mm = new MailMessage();
            mm.Subject = "Team 28 - " + emailSubject;
            mm.Sender = senderEmail;
            mm.From = senderEmail;
            mm.To.Add(new MailAddress(toEmailAddress));
            mm.Body = finalMessage;
            client.Send(mm);
        }
    }
}
