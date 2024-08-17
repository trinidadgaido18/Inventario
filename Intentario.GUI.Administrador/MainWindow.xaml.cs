using System;
using System.Collections;
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
        private object btnEmpleadosNombre;
        private object btnEmpleadosApellido; 
        private Empleado emp;
        private object btnEmpleadosEliminar;

        internal Empleado Empleado { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            manejadorEmpleados = new ManejadorEmpleados(new RepositorioDeEmpleados()); 

            PonerBotonesEmpleadosEnEdicion(false);
            LimpiarCamposDeEmpleados();
            ActualizarTablaEmpleados(); 
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar; 
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
           
            btnEmpleadosGuardar.IsEnabled = value; 
            btnEmpleadosNuevo.IsEnabled = !value; 
        }

        private void btnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(true);
            accionEmpleados = accion.Nuevo;
        }

        private void btnEmpleadosEditar_Click(object sender, RoutedEventArgs e)  // Código para editar un empleado
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;  
            
            {
                txbEmpleadosId.Text = emp.Id;
                txbEmpleadosApellidos.Text = emp.Apellidos;
                txbEmpleadosArea.Text = emp.Area;
                txbEmpleadosNombre.Text = (string)emp.Nombre;  
                accionEmpleados = accion.Editar;
                PonerBotonesEmpleadosEnEdicion(true); 

            }
        }

        private void btnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionEmpleados == accion.Nuevo)
            {
                Empleado emp = new Empleado()
                {
                    Nombre = txbEmpleadosNombre.Text, 
                    Apellidos = txbEmpleadosApellidos.Text,
                    Area = txbEmpleadosArea.Text
                };
                if (manejadorEmpleados.Agregar(emp.Id))
                {
                    MessageBox.Show("Empleado agregado correctamente ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else 
                {
                    MessageBox.Show("ElEmpleado no se pudo agregar correctamente ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error); 
                }
            }
            else 
            {
               Empleado emp = dtgEmpleados.SelectedItem as Empleado;
               emp.Apellidos = txbEmpleadosApellidos.Text;   
               emp.Nombre = txbEmpleadosNombre.Text;
                if (manejadorEmpleados.Modificar(emp))
                {
                    MessageBox.Show("Empleado modificado  correctamente ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else 
                
                {
                    MessageBox.Show("ElEmpleado no se pudo actualizar correctamente ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            
        }


        private void btnEmpledosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(false);

        }

        private Empleado GetEmp()
        {
            return emp;
        }

        private void BtnEmpleadosEliminar_Click(object sender, RoutedEventArgs e, Empleado emp) //Logica para eliminar Empleado 

        {
            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            Empleado  = (Empleado)dtgEmpleados.SelectedItem;  
            if (emp == null)
            {
               if (MessageBox.Show("Realmente desea eliminar este empleado?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleados.Equals(emp.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleados();
                    }
                    else 
                    {
                        MessageBox.Show("No se pudo eliminar al Empleado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleados();
                    }
                }
            }
           
        }

        private void btnEmpleadosEliminar_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    internal class RepositorioDeEmpleados
    {
        public RepositorioDeEmpleados()
        {
        }
    }

    internal class ManejadorEmpleados : IManejadorEmpleados
    {
        public ManejadorEmpleados(RepositorioDeEmpleados repositorioDeEmpleados)
        {
        }

        public IEnumerable Listar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Agregar(string id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Empleado emp)
        {
            throw new NotImplementedException();
        }
    }

    internal class Empleado
    {
        public string Id { get; internal set; }
        public string Apellidos { get; internal set; }
        public string Area { get; internal set; }
        public object Nombre { get; internal set; }

        public static implicit operator Empleados(Empleado v) 
        {
            throw new NotImplementedException();
        }
    }

    internal class Empleados
    {
    }
}

