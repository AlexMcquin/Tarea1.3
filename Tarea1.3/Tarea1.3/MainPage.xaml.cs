using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Tarea1._3.Model;

namespace Tarea1._3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {

            Int32 resultado = 0;
            var persona = new Personas()
            {
                nombres = this.txtnombre.Text,
                apellidos = this.txtapellido.Text,
                edad = Convert.ToInt32(this.txtedad.Text),
                correo = this.txtcorreo.Text,
                direccion = this.txtdireccion.Text
            };

            if (String.IsNullOrWhiteSpace(txtnombre.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para salvar la informacion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtapellido.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para salvar la informacion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtedad.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para salvar la informacion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para salvar la informacion", "¡Listo!");

            }
            else if (String.IsNullOrWhiteSpace(txtdireccion.Text))
            {
                DisplayAlert("¡Cuidado!", "Llene los campos vacios para salvar la informacion", "¡Listo!");

            }
            else
            {


                using (SQLiteConnection conexion = new SQLiteConnection(App.ubicacionDB))
                {
                    conexion.CreateTable<Personas>();
                    resultado = conexion.Insert(persona);

                    if (resultado > 0)
                        DisplayAlert("¡Atención!", "Información Salvada Satisfactoriamente", "¡Lo tengo!");
                    else
                        DisplayAlert("UPS", "Hubo un error al salvas la informacion", "Ok");
                }


            }
        }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

    }
}
