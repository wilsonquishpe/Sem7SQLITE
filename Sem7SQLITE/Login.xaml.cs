using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem7SQLITE.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sem7SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;


        public Login()
        {
            InitializeComponent();
            con=DependencyService.Get<Database>().GetConnection();

        }

     public static   IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena) {
            return db.Query<Estudiante>("Select * FROM Estudiante where usuario=? and Contrasena", usuario, contrasena);
        }
        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try 
            
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtCOntrasena.Text);
                if(resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                    }
                else {
                    DisplayAlert("Alerta" ,"Usuario Incorrecto", "cerrar");
                }
            }
            catch (Exception) {
                throw;
                    }
    }
    }
}