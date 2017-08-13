using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;

namespace InsertarMovimiento
{
    class Service
    {
        private string url { get; set; }
        private HttpWebRequest httpRequest { get; set; }
        private HttpWebResponse httpResponse { get; set; }
        private StreamWriter streamWriter { get; set; }
        private StreamReader streamReader { get; set; }
        private string body { get; set; }
        private string results { get; set; }

        public Service()
        {
            url = "http://192.168.43.246/webServicePaqueteria/";
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";
            streamWriter = new StreamWriter(httpRequest.GetRequestStream());
        }

        public string callService(string parameters)
        {
            body = parameters;
            streamWriter.InitializeLifetimeService();
            streamWriter.Write(body);
            streamWriter.Flush();
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                results = streamReader.ReadToEnd();
            }
            return results;
        }
    }
}