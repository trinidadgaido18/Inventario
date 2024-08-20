using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventario.GUI.Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Accion 
        {
          Nuevo,
          Editar
        }

        Accion accionEmpleados; 
        public MainWindow()
        {
            InitializeComponent();
            PonerBotnoesEmpleadosEnEdicion(false);
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

        private void PonerBotnoesEmpleadosEnEdicion(bool value) 
        {
            BtnEmpledosCancelar.IsEnabled = value; 
            BtnEmpleadosEditar.IsEnabled = !value; 
            BtnEmpleadosGuardar.IsEnabled = value;
            BtnEmpleadosEliminar.IsEnabled = !value;
            BtnEmpleadosNuevo.IsEnabled = !value;   
            
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

        private void BtnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados(); 
            PonerBotnoesEmpleadosEnEdicion(true);
            accionEmpleados = Accion.Nuevo; 
        }

        private void BtnEmpleadosEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmpledosCancelar_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}