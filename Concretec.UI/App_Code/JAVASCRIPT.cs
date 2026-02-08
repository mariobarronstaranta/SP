using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls; 

/// <summary>
/// Summary description for JAVASCRIPT
/// </summary>
  public class JAVASCRIPT
    {

        /// displays an alert box with a specified message 

        public static void Alert(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"-script language=JavaScript>");
            sb.Append(@"alert('" + message + "');");
            sb.Append(@"</");
            sb.Append(@"script>");

            ((System.Web.UI.Page)HttpContext.Current.Handler).RegisterStartupScript(new Guid().ToString(), sb.ToString());
        }


        /// Displays an OkConfirm box with a specified message and will redirect to a specified URL if the Ok button is pressed 

        public static void OkConfirm(string message, string hyperLink)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"-script language=JavaScript>");
            sb.Append(@"if (confirm('" + message + "')) {location='" + hyperLink + "'};");
            sb.Append(@"</");
            sb.Append(@"script>");

            ((Page)HttpContext.Current.Handler).RegisterStartupScript(new Guid().ToString(), sb.ToString());

    }


        /// Displays a prompt box that will direct the user to a specified hyperlink with a specified querystring definition for an ok click or a cancel click. The querystring value will be inserted by the entered value in the prompt box only if ok was clicked. No need to enter any equal or question mark characters. 

        public static void PromptBox(string message, string defaultPromptvalue, string hyperlink, string queryString, string cancelHyperlink)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"-script language=JavaScript>");
            sb.Append(@"var return_value = prompt('" + message + "', '" + defaultPromptvalue + "');");
            sb.Append(@"if (return_value != null)");
            sb.Append(@"{location='" + hyperlink + "?" + queryString + "=' + return_value;}");
            sb.Append(@"else");
            sb.Append(@"{location='" + cancelHyperlink + ";}");
            sb.Append(@"");
            sb.Append(@"</");
            sb.Append(@"script>");

            #pragma warning disable CS0618 // Type or member is obsolete
                    ((Page)HttpContext.Current.Handler).RegisterStartupScript(new Guid().ToString(), sb.ToString());
            #pragma warning restore CS0618 // Type or member is obsolete
    }
    } 
