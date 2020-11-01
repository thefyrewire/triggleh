using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Collections.Specialized;
using System.Web;

using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace Triggleh
{
    public partial class LoginForm : Form
    {
        // static HttpListener httpListener = new HttpListener();
        public string username;
        public string user_id;

        public LoginForm()
        {
            InitializeComponent();
            /*httpListener.Prefixes.Add("http://localhost:3000/");
            httpListener.Start();

            Thread responseThread = new Thread(ResponseThread);
            responseThread.Start();*/
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            web_TrigglehLogin.Size = new Size(390, 600);
            web_TrigglehLogin.Navigate(Globals.AUTH_URL_TWITCH);
        }

        /*static void ResponseThread()
        {
            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                Console.WriteLine(context.Request.Url);
                byte[] responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost Server</title></head><body>Hello world!</body>");
                context.Response.OutputStream.Write(responseArray, 0, responseArray.Length);
                context.Response.KeepAlive = false;
                context.Response.Close();
            }
        }*/

        private void Web_TrigglehLogin_NavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
        {
            // string functionQuery = string.Format("document.body.innerText");
            // string queryResult = await web_TrigglehLogin.InvokeScriptAsync("eval", new string[] { functionQuery });
            // Console.WriteLine(queryResult);

            if (e.Uri.Host != Globals.HOST)
                return;

            NameValueCollection parameters = HttpUtility.ParseQueryString(e.Uri.Query);
            username = parameters.Get("username");
            user_id = parameters.Get("user_id");
        }
    }
}
