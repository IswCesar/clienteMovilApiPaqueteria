using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Newtonsoft.Json;

namespace InsertarMovimiento
{
    [Activity(Label = "InsertarMovimiento", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public EditText txtDescripcion;
        public EditText txtTipo;
        public EditText txtIdUsuario;
        public EditText txtIdPedido;
        public EditText txtU, txtP;
        public Button btnInsert,btnAcceder;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.login);
            btnAcceder = FindViewById<Button>(Resource.Id.btnAcceder);
            btnAcceder.Click += btnAcceder_Click;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            txtU = FindViewById<EditText>(Resource.Id.txtU);
            txtP = FindViewById<EditText>(Resource.Id.txtP);
            Service newService = new Service();
            log mov = new log();
            mov.usuario = txtU.Text;
            mov.clave = txtP.Text;
            string body = JsonConvert.SerializeObject(mov);
            string results = newService.callService(body);
            var answer = JsonConvert.DeserializeObject<ResultsInsert>(results);
            try { Toast.MakeText(this, answer.ToString(), ToastLength.Long).Show(); } catch (Exception ex) { Toast.MakeText(this, "FALLIDA", ToastLength.Long).Show(); }
            txtU.Text = "";
            txtP.Text = "";
            SetContentView(Resource.Layout.Main);
            txtDescripcion = FindViewById<EditText>(Resource.Id.editText1);
            txtTipo = FindViewById<EditText>(Resource.Id.editText2);
            txtIdUsuario = FindViewById<EditText>(Resource.Id.editText3);
            txtIdPedido = FindViewById<EditText>(Resource.Id.editText4);
            btnInsert = FindViewById<Button>(Resource.Id.btnInsert);
            btnInsert.Click += btnInsert_Click;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Service newService = new Service();
            insertMov mov = new insertMov();
            mov.descripcion = txtDescripcion.Text;
            mov.tipo = Convert.ToInt32(txtTipo.Text);
            mov.idusuario = Convert.ToInt32(txtIdUsuario.Text);
            mov.idpedido = Convert.ToInt32(txtIdPedido.Text);
            string body = JsonConvert.SerializeObject(mov);
            string results = newService.callService(body);
            var answer = JsonConvert.DeserializeObject<ResultsLog>(results);
            try { Toast.MakeText(this, answer.ToString(), ToastLength.Long).Show(); } catch (Exception ex) { Toast.MakeText(this, "ERROR AL REGISTRAR", ToastLength.Long).Show(); }
            txtDescripcion.Text = "";
            txtIdPedido.Text = "";
            txtIdUsuario.Text = "";
            txtTipo.Text = "";
        }
    }
}

