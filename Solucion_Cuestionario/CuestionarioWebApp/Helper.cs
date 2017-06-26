using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;


namespace CuestionarioWebApp
{

    
    public static class Helper
    {
      
        public static void RegisterRedirectOnSessionEndScript(this Page page)
        {
            
            string EmptyPage = "Empty.aspx?paction=4";           
            int sessionTimeout = HttpContext.Current.Session.Timeout;           
            int redirectTimeout = (sessionTimeout * 60000) - 60000;
                      
            StringBuilder javascript = new StringBuilder();
            javascript.Append("var redirectTimeout;");
            javascript.Append("clearTimeout(redirectTimeout);");
            javascript.Append(String.Format("setTimeout(\"window.location.href='{0}'\",{1});", EmptyPage, redirectTimeout));
                       
            page.ClientScript.RegisterStartupScript(page.GetType(), "RegisterRedirectOnSessionEndScript", javascript.ToString(), true);
        }
    }
}
