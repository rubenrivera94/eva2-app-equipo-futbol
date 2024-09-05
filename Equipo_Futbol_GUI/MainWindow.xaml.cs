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
    public partial class MainWindow : Window
    {
        Equipo_Futbol_Negocio.EquipoCollection equipoCollection;
        Equipo_Futbol_Negocio.EquipoReportes equipoReportes;

        public MainWindow()
        {
            InitializeComponent();
            equipoCollection = new Equipo_Futbol_Negocio.EquipoCollection();
            equipoReportes = new Equipo_Futbol_Negocio.EquipoReportes();
        }

        // Método para manejar la navegación al hacer clic en "Agregar Equipo"
        private void menuAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AgregarEquipoPage());
        }

        // Método para manejar la navegación al hacer clic en "Listar Equipos"
        private void menuListarEquipos_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ListarEquipoPage());
        }

        // Método para manejar la navegación al hacer clic en "Acerca De"
        private void menuAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AcercaDePage());
        }

        // Método para revisar la cantidad de equipos femeninos y masculinos
        private void menuRevisarCantidadEquipos_Click(object sender, RoutedEventArgs e)
        {
            int cantidadFemeninos = ObtenerCantidadEquiposFemeninos();
            int cantidadMasculinos = ObtenerCantidadEquiposMasculinos();

            // Mostrar la información en un MessageBox
            MessageBox.Show($"Cantidad de equipos femeninos: {cantidadFemeninos}\nCantidad de equipos masculinos: {cantidadMasculinos}",
                "Cantidad de Equipos",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // Métodos para obtener la cantidad de equipos desde EquipoReportes
        private int ObtenerCantidadEquiposFemeninos()
        {
            return equipoReportes.ReporteCantidadEquiposFemeninos();
        }

        private int ObtenerCantidadEquiposMasculinos()
        {
            return equipoReportes.ReporteCantidadEquiposMasculinos();
        }

        // Método para cargar los equipos en la grilla
        private void CargarGrilla()
        {
            dgListarEquipos.ItemsSource = equipoCollection.ReadAll();
        }
    }
}
