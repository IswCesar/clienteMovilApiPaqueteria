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

namespace InsertarMovimiento
{
    class log
    {
        public string action { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }

        public log()
        {
            action = "loggin";
        }
    }

    class ResultsLog
    {
        public string message { get; set; }

        public override string ToString()
        {
            return message;
        }
    }
}