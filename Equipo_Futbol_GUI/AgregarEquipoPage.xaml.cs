using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Equipo_Futbol_GUI
{
    /// <summary>
    /// Lógica de interacción para AgregarEquipoPage.xaml
    /// </summary>
    public partial class AgregarEquipoPage : Page
    {
        public AgregarEquipoPage()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombreEquipo.Text) ||
                string.IsNullOrWhiteSpace(txtCantidadJugadores.Text) ||
                string.IsNullOrWhiteSpace(txtNombreDt.Text) ||
                string.IsNullOrWhiteSpace(txtTipoEquipo.Text) ||
                string.IsNullOrWhiteSpace(txtCapitanEquipo.Text) ||
                !chkTieneSub21.IsChecked.HasValue)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                // Intentar convertir el valor del TextBox a un entero
                Equipo_Futbol_Negocio.Equipo equipo = new Equipo_Futbol_Negocio.Equipo();
                equipo.NombreEquipo = txtNombreEquipo.Text;
                equipo.CantidadJugadores = Convert.ToInt32(txtCantidadJugadores.Text);
                equipo.NombreDt = txtNombreDt.Text;
                equipo.TipoEquipo = txtTipoEquipo.Text;
                equipo.CapitanEquipo = txtCapitanEquipo.Text;
                equipo.TieneSub21 = (chkTieneSub21.IsChecked.Value) ? true : false;

                bool response = equipo.Create();

                if (response)
                {
                    MessageBox.Show("El Equipo se agrego correctamente");
                    AgregarOtroEquipo();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al agregar el equipo");
                    // Navegar a la página ListarEquipoPage.xaml
                    NavigationService?.Navigate(new ListarEquipoPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AgregarOtroEquipo()
        {
            string title = "Agregar Nuevo Equipo";
            string message = "¿Deseas agregar otro equipo?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(title, message, buttons); 

            if(result == MessageBoxResult.No)
            {
                // Navegar a la página ListarEquipoPage.xaml
                NavigationService?.Navigate(new ListarEquipoPage());
            }
        }

        private void LimpiarCampos()
        {
            txtNombreEquipo.Text = string.Empty;
            txtCantidadJugadores.Text = string.Empty;
            txtNombreDt.Text = string.Empty;
            txtTipoEquipo.Text = string.Empty;
            txtCapitanEquipo.Text = string.Empty;
            chkTieneSub21.IsChecked = false;
        }

    }
}
