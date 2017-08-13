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
    class insertMov
    {
        public string action { get; set; }

        public string descripcion { get; set; }

        public int tipo { get; set; }

        public int idusuario { get; set; }

        public int idpedido { get; set; }




        public insertMov()
        {
            action = "insertarMovimiento";
        }

    }
    class ResultsInsert
    {
        public string message { get; set; }

        public override string ToString()
        {
            return message;
        }
    }
}