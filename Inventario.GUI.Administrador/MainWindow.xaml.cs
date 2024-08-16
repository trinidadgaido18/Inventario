using System.Windows;

namespace Inventario.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorEmpleados manejadorEmpleados;
        accion accionEmpleados;
        private object btnEmpleadosCancelar;
        private object txbEmpleadosNombre;

        public MainWindow()
        {
            InitializeComponent();
            PonerBotonesEmpleadosEnEdicion(false);
            LimpiarCamposDeEmpleados();
            ActualizarTablaEmpleados();

        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = null;
        }

        private void LimpiarCamposDeEmpleados()
        {
            txbEmpleadosId.Text = "";
            txbEmpleadosApellidos.Inlines.Clear();
            txbEmpleadosArea.Inlines.Clear();
            txbEmpleadosId.Inlines.Clear();
        }

        private void PonerBotonesEmpleadosEnEdicion(bool value)
        {
            btnEmpleadosCancelar = value;
            btnEmpleadosEditar.IsEnabled = !value;
            btnEmpleadosEliminar.IsEnabled = !value;
            btnEmpleadosGuardar.IsEnabled = value;
            btnEmpleadosNuevo.IsEnabled = !value;
        }

        private void btnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(true);
            accionEmpleados = accion.Nuevo;
        }

        private void btnEmpleadosEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmpledosCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    internal interface IManejadorEmpleados
    {
    }
}
