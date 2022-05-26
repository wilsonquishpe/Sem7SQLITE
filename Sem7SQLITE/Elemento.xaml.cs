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
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> Rupdate;
        IEnumerable<Estudiante> Rdelete;
        public Elemento(int id, string nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            idSeleccionado = id;
            con = DependencyService.Get<Database>().GetConnection();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasena.Text = contrasena;
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id) {
            return db.Query<Estudiante>("Delete from Estudiante where Id= ?", id);
        }
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("Update Estudiante set nombre =?, usuario =?,contrasena=? where id =?",nombre, usuario,contrasena,id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var dabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(dabasePath);
                Rupdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var dabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(dabasePath);
                Rdelete = Delete(db, idSeleccionado);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}