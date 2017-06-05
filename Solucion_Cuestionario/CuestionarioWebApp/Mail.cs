using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Collections;

namespace CuestionarioWebApp
{
    public class Mail
    {
        //en la entidad [S_Configuracion Cuestionario] estan los datos del correo
        private string mstServerSMTP = "";
        private string mstSender = "";
        private string mstError = "";
        private string mstMailTo = "";
        private bool mboIsHTML = false;
        private System.Net.NetworkCredential mobCredentials;   
        private ArrayList mobAttachmentsPaths = new ArrayList();
        public string Error
        {
            get { return mstError; }
        }

        public ArrayList AttachPaths
        {
            get { return mobAttachmentsPaths; }
        }

        public bool IsHTML
        {
            get { return mboIsHTML; }
            set { this.mboIsHTML = value; }
        }

        public string SMTP
        {
            get { return mstServerSMTP; }
            set { this.mstServerSMTP = value; }
        }

        public string MailFrom
        {
            get { return mstSender; }
            set { this.mstSender = value; }
        }

        public string MailTo
        {
            get { return mstMailTo; }
            set { this.mstMailTo = value; }
        }

        public Mail()
        {
            mobCredentials = new System.Net.NetworkCredential("pvdasko@gmail.com", "rebotes28");
        
        }
        public Mail(string usrCredentials, string passCredentilas)
        {
            //mobCredentials = new System.Net.NetworkCredential(usrCredentials, passCredentilas);
            mobCredentials = new System.Net.NetworkCredential("pvdasko@gmail.com", "rebotes28"); 
        
        }

        public Mail(string pstServerSMTP, string pstMailTo, string pstFrom, string usrCredentials, string passCredentilas)
        {
            //mobCredentials = new System.Net.NetworkCredential(usrCredentials, passCredentilas);
            mobCredentials = new System.Net.NetworkCredential("pvdasko@gmail.com", "rebotes28");  
            this.mstServerSMTP = pstServerSMTP;
            this.mstSender = pstFrom;
            this.mstMailTo = pstMailTo;
        
        }

  

        public void sendMail(string asunto, string mensaje)
        {

            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();
            if (mstSender != "" && mstMailTo != "")
            {
                if (mobCredentials != null)
                    client.Credentials = mobCredentials;
                try
                {
                    msg.To.Add(new MailAddress(mstMailTo));
                    msg.From = new MailAddress(mstSender);
                }
                catch (Exception ex)
                {
                    this.mstError = ex.Message;
                }
                msg.Subject = asunto;
                msg.Body = mensaje;
                msg.IsBodyHtml = this.mboIsHTML;
                client.Host = this.mstServerSMTP;
                client.Port = 587;
                client.EnableSsl = true ;
                     

                foreach (string atach in mobAttachmentsPaths)
                {
                    Attachment atachFile = new Attachment(atach);
                    msg.Attachments.Add(atachFile);
                }

                try
                {
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    this.mstError += ex.Message;
                }
            }
        }
    }
}