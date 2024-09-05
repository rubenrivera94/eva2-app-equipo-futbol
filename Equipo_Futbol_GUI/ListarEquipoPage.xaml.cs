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
    /// Lógica de interacción para ListarEquiposPage.xaml
    /// </summary>
    public partial class ListarEquipoPage : Page
    {
        Equipo_Futbol_Negocio.EquipoCollection equipoCollection;
        public ListarEquipoPage()
        {
            InitializeComponent();
            CargarEquipos(); // Llama al método para cargar los equipos guardados
        }

        private void CargarEquipos()
        {
            // Asignar la lista de equipos guardados al DataGrid
            equipoCollection = new Equipo_Futbol_Negocio.EquipoCollection();
            dataGridEquipos.ItemsSource = equipoCollection.ReadAll(); // Asignar la lista actual de equipos
        }

        // Método para manejar la eliminación de un equipo
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
                // Eliminar el equipo de la lista estática
               EliminarRegistroSeleccionado();
        }

        // Método para manejar la actualización de un equipo
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            var filaSeleccionada = (Equipo_Futbol_Negocio.Equipo)dataGridEquipos.SelectedItem;
            if (filaSeleccionada != null)
            {
                // Crear una nueva instancia de la página de actualización y navegar a ella
                ActualizarEquipoPage actualizarEquipo = new ActualizarEquipoPage(filaSeleccionada.EquipoId);
                NavigationService?.Navigate(actualizarEquipo);
            }
            else
            {
                MessageBox.Show("Selecciona un equipo para actualizar.");
            }
        }


        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (Equipo_Futbol_Negocio.Equipo)dataGridEquipos.SelectedItem;
            int equipoId = filaSeleccionada.EquipoId;
            string title = "Eliminar Equipo";
            string message = string.Format("Estas seguro de eliminar el Equipo", equipoId);

            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(title, message, buttons);
            if(result == MessageBoxResult.Yes)

            {
                var res = filaSeleccionada.Delete(equipoId) ?
                    MessageBox.Show(string.Format("Equipo eliminado", equipoId)) :
                MessageBox.Show("Equipo no pudo ser eliminado");
            }
        }
    }
}

