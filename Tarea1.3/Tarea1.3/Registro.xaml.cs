using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Tarea1._3.Model;

namespace Tarea1._3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        Personas itemPersonas = new Personas();
        public Registro()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB);
            conexion.CreateTable<Personas>();
            var listpersonas = conexion.Table<Personas>().ToList();
            ListaPersonas.ItemsSource = listpersonas;
            conexion.Close();
        }

        //Informacion obtenida de la seleccion
        private void listviewSelect(object sender, ItemTappedEventArgs e)
        {
            itemPersonas = (Personas)e.Item;


        }

        //P BOTON BORRAR 
        private void botonBorrar(object sender, EventArgs e)
        {
            
            SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB);
            conexion.Table<Personas>().Delete(x => x.id == itemPersonas.id);


            conexion.CreateTable<Personas>();
            var listlocaciones = conexion.Table<Personas>().ToList();
            ListaPersonas.ItemsSource = listlocaciones;
            conexion.Close();
        }

        //TRIGGER EDITAR 
        private void botonEditar(object sender, EventArgs e)
        {
            SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB);






            if (String.IsNullOrWhiteSpace(txtnombres.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para realizar la edicion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtapellidos.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para realizar la edicion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtEdad.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para realizar la edicion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtEmail.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para realizar la edicion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para realizar la edicion", "¡Listo!");

            }


            else
            {



                conexion.Update(new Personas
                {

                    id = itemPersonas.id,
                    nombres = this.txtnombres.Text,
                    apellidos = this.txtapellidos.Text,
                    edad = Convert.ToInt32(this.txtEdad.Text),
                    correo = this.txtEmail.Text,
                    direccion = this.txtDireccion.Text

                });


                conexion.CreateTable<Personas>();
                var listlocaciones = conexion.Table<Personas>().ToList();
                ListaPersonas.ItemsSource = listlocaciones;
                conexion.Close();
            }
        }
    }
}