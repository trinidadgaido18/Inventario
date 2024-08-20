using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace Inventario.GUI.Administrar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Accion  
        {
         Nuevo,
         Editar,
        }
       
       


        Accion accionEmpleados;   
        public MainWindow()
        {
            InitializeComponent();
            PonerBotonesEnEdicion(false);
            LimpiarCamposDeEmpleados();
            ActualizarTablaEmpleados();
           
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
          
        }

        private void LimpiarCamposDeEmpleados()
        {
            txbEmpleadosApellidos.Text = string.Empty;  
            txbEmpleadosArea.Text = string.Empty;
            txbEmpleadosId.Text = string.Empty;
            txbEmpleadosNombre.Text = string.Empty;

        }

        private void PonerBotonesEnEdicion(bool value)
        {
            BtnEmpledosCancelar.IsEnabled = value; 
            BtnMaterialesEditar.IsEnabled = !value;
            BtnEmpleadosEliminar.IsEnabled = !value;
            BtnEmpleadosGuardar.IsEnabled = value; 
            BtnEmpleadosNuevoNuevo.IsEnabled = !value; 

        }

        private void BtnEmpleadosNuevoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEnEdicion(true);
            accionEmpleados = Accion.Nuevo; 
        }

        private void BtnEmpleadosEditarNuevo_Click(object sender, RoutedEventArgs e)
        {
             dtgEmpleados.SelectedItem = accionEmpleados;
            if (dtgEmpleados == null) 
            {
              txbEmpleadosId.Text = string.Empty;
                txbEmpleadosApellidos.Text = string.Empty;
                txbEmpleadosArea.Text = string.Empty;
                txbEmpleadosNombre.Text = string.Empty;
                accionEmpleados = Accion.Editar;
                PonerBotonesEnEdicion(true);
            }
             
        }

        private void BtnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmpledosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados(); 
            PonerBotonesEnEdicion(false);
        }

        private void BtnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void BtnMaterialesNuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMaterialesEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMaterialesGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMaterialesCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMaterialesEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }

   

  
}
