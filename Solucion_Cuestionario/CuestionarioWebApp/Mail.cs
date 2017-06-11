using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Linq;
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
        private int mstPort = 0;
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

        public int Port
        {
            get { return mstPort; }
            set { this.mstPort = value; }
        }

        public Mail()
        {
            int pcorpo = int.Parse(HttpContext.Current.Session["scorpo"].ToString());
            string photel = HttpContext.Current.Session["shotel"].ToString();
            string ptipo = HttpContext.Current.Session["stipo"].ToString();

            using (CuestionarioEntities context = new CuestionarioEntities())
            {

                var config = (from c in context.S_Configuracion_Cuestionario
                              where c.Corporativo == pcorpo && c.Hotel == photel && c.Tipo_Cuestionario == ptipo
                              select new
                              {
                                  c

                              }).SingleOrDefault();
                mobCredentials = new System.Net.NetworkCredential(config.c.Email_Saliente, config.c.Contrasena_SMTP  );
            }
           
        
        }
        public Mail(string usrCredentials, string passCredentilas)
        {
            mobCredentials = new System.Net.NetworkCredential(usrCredentials, passCredentilas);
                   
        }

        public Mail(string pstServerSMTP, string pstMailTo, string pstFrom, string usrCredentials, string passCredentilas)
        {
            mobCredentials = new System.Net.NetworkCredential(usrCredentials, passCredentilas);          
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

                    foreach (var address in mstMailTo.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        msg.To.Add(new MailAddress(address));                     
                    }
                    //msg.To.Add(new MailAddress(mstMailTo));                     
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
                client.Port = this.Port; //587;
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