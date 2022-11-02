using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Windows.Forms;

namespace MoneyLog.DAL
{
    public static class EmailUtil
    {

        public static void SendEmail(string title, string content, string receiverEmail)
        {
            //Hotmail account, Gmail not support less security app sending email 
            string strAccount = "**************@hotmail.com";
            //Password
            string strPwd = "*************************";
            //Server port
            int port = 587;
            // email server
            var smtpServer = "smtp.office365.com";

            // new email client
            SmtpClient Client = new SmtpClient()
            {
                //Using GMail SMTP
                Host = smtpServer,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = strAccount, //Returns valid Gmail address.
                    Password = strPwd //Password to access email above. 
                }
            };
            MailAddress FromeMail = new MailAddress(strAccount, "From");
            MailAddress ToeMail = new MailAddress(receiverEmail, "To");

            MailMessage Message = new MailMessage()
            {
                From = FromeMail,
                Subject = title,
                Body = content
            };

            Message.To.Add(ToeMail);

            try
            {
                Client.Send(Message);
                MessageBox.Show("Email sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
