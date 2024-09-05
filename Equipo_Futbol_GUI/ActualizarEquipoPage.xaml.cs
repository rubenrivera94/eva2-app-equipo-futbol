﻿using System;
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
    /// Lógica de interacción para ActualizarEquipoPage.xaml
    /// </summary>
    public partial class ActualizarEquipoPage : Page
    {
        // Declarar la variable equipoSeleccionado
        Equipo_Futbol_Negocio.Equipo equipo;

        public ActualizarEquipoPage(int equipoId)
        {
            InitializeComponent();
            this.Title = string.Format("Actualizar Equipo", equipoId);

            equipo = new Equipo_Futbol_Negocio.Equipo();

            CargarFormulario(equipoId);
            
        }

        private void CargarFormulario(int equipoId)
        {
            bool response = equipo.Read(equipoId);
            if(response)
            {
                // Cargar los datos del equipo seleccionado en los campos del formulario
                txtNombreEquipo.Text = equipo.NombreEquipo;
                // Convertimos el valor entero a texto para mostrarlo en el TextBox
                txtCantidadJugadores.Text = equipo.CantidadJugadores.ToString();
                txtNombreDt.Text = equipo.NombreDt;
                txtTipoEquipo.Text = equipo.TipoEquipo;
                txtCapitanEquipo.Text = equipo.CapitanEquipo;
                chkTieneSub21.IsChecked = (equipo.TieneSub21) ? true : false;
            }
            else
            {
                MessageBox.Show(string.Format("El libro no fue encontrado", equipoId));
            }
        }

        // Maneja el clic en el botón de actualizar para guardar los datos del equipo
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtCantidadJugadores.Text, out int cantidadJugadores))
            {
                equipo.NombreEquipo = txtNombreEquipo.Text;
                equipo.CantidadJugadores = cantidadJugadores; // Convertido a int
                equipo.NombreDt = txtNombreDt.Text;
                equipo.TipoEquipo = txtTipoEquipo.Text;
                equipo.CapitanEquipo = txtCapitanEquipo.Text;
                equipo.TieneSub21 = chkTieneSub21.IsChecked.GetValueOrDefault(); // Manejo seguro del Nullable Boolean

                bool response = equipo.Update();
                if (response)
                {
                    MessageBox.Show("Equipo ha sido actualizado exitosamente.");
                    // Navegar a la página ListarEquipoPage.xaml
                    NavigationService?.Navigate(new ListarEquipoPage());
                }
                else
                {
                    MessageBox.Show("No fue posible actualizar el equipo.");
                    // Navegar a la página ListarEquipoPage.xaml
                    NavigationService?.Navigate(new ListarEquipoPage());
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor válido para la cantidad de jugadores.");
            }
        }
        // Maneja el clic en el botón de cancelar
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Navegar de vuelta a la lista de equipos sin realizar cambios
            NavigationService?.GoBack();
        }
    }
}
