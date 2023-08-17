using System;
using System.Net;
using System.Text;

namespace Listener
{
    public class MyHttpListenerHandler
    {
        public void Start()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();

            Console.WriteLine("Listening...");

            while (true)
            {
                var context = listener.GetContext();
                ProcessRequest(context);
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            string resourcePath = context.Request.Url.AbsolutePath;

            if (resourcePath == "/MyName/")
            {
                SendResponse(context.Response, "Vitali");
            }
            else if (resourcePath == "/Information/")
            {
                SendResponse(context.Response, "Information");
            }
            else if (resourcePath == "/Success/")
            {
                SendResponse(context.Response, "Success");
            }
            else if (resourcePath == "/Redirection/")
            {
                SendResponse(context.Response, "Redirection");
            }
            else if (resourcePath == "/ClientError/")
            {
                SendResponse(context.Response, "Client error");
            }
            else if (resourcePath == "/ServerError/")
            {
                SendResponse(context.Response, "Server error");
            }
            else if (resourcePath == "/MyNameByHeader/")
            {
                SendResponseWithHeader(context.Response, "Name from header");
            }
            else if (resourcePath == "/MyNameByCookies/")
            {
                SendResponseWithCookie(context.Response, "Name from cookie");
            }
            else
            {
                SendResponse(context.Response, "Unknown request");
            }

            context.Response.Close();
        }

        private void SendResponse(HttpListenerResponse response, string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        private void SendResponseWithHeader(HttpListenerResponse response, string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            response.ContentLength64 = buffer.Length;
            response.Headers.Add("X-Response-Header", "Header Value");
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        private void SendResponseWithCookie(HttpListenerResponse response, string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            response.ContentLength64 = buffer.Length;

            var cookie = new Cookie("MyName", "Vitali Varabyeu");
            response.Cookies.Add(cookie);

            response.OutputStream.Write(buffer, 0, buffer.Length);
        }
    }
}
