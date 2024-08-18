using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Media3D;

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
        IManejadorMateriales manejadorMateriales;

        accion accionEmpleados;
        accion accionMateriales;
        private Material m;

        public object txbMaterialesDescripcion { get; private set; }
        public object txbMaterialesCategoria { get; private set; }
        public bool btnEmpleadosCancelar { get; private set; }
        internal Empleado emp { get; private set; }
        internal Empleado Empleado { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            manejadorEmpleados = new ManejadorEmpleados(new RepositorioDeEmpleados()); 
            manejadorMateriales = new ManejadorMateriales(new RepositorioDeEmpleados ());  

            PonerBotonesEmpleadosEnEdicion(false);
            LimpiarCamposDeEmpleados();
            ActualizarTablaEmpleados();

            PonerBotonesMaterialesEnEdicion(false);  
            LimpiarCamposDeMateriales ();
            ActualizarTablaMateriales(); 

        }

        private void ActualizarTablaMateriales()
        {
            dtgMateriales.ItemsSource = null;
            dtgMateriales.SelectedIndex = manejadorMateriales.listar(); 
        }

        private void LimpiarCamposDeMateriales()
        {
            txbMaterialesCategoria.GetHashCode();
            txbMaterialesDescripcion.GetHashCode();
            txbMaterialesId.Text = "";
            txbMaterialesNombre.GetHashCode();
        }

        private void PonerBotonesMaterialesEnEdicion(bool value)
        {
            btnMaterialesCancelar.IsEnabled = value; 
            btnMaterialesEditar.IsEnabled = !value;

            btnMaterialesGuardar.IsEnabled = value;
            btnMaterialesNuevo.IsEnabled = !value;
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar; 
        }

        private void LimpiarCamposDeEmpleados()
        {
            
            txbEmpleadosApellidos.GetHashCode();    
            txbEmpleadosArea.GetHashCode();   
            txbEmpleadosId.Text = ""; 
            txbEmpleadosId.GetHashCode(); 
        }

        private void PonerBotonesEmpleadosEnEdicion(bool value)
        {
            btnEmpleadosCancelar = value; 
            
            
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

            Empleado  = (Empleado)dtgEmpleados.SelectedItem;  
            if (emp == null)
            {
               if (MessageBox.Show("Realmente desea eliminar este empleado?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleados.Eliminar(emp.Id))
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


        private void btnMaterialesNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeMateriales();
            accionMateriales = accion.Nuevo;
            PonerBotonesMaterialesEnEdicion(true); 
        }

        private void btnMaterialesEditar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeMateriales();
            accionMateriales = accion.Editar;
            PonerBotonesMaterialesEnEdicion(true);
            Material m = dtgMateriales.SelectedItem as Material;
            if (m == null) 
            {
                txbMaterialesCategoria.Text = m.Categoria; 
                txbMaterialesDescripcion.Text = m.Descripcion;  
                txbMaterialesId.Text = m.Id;
                txbMaterialesNombre.Text = m.Nombre;
               

            }       
        }

        private void btnMaterialesGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionMateriales == accion.Nuevo)
            {
                if (accionMateriales == accion.Nuevo)
                {
                    if (manejadorMateriales.Agregar(m))
                    {
                        MessageBox.Show("Material correctamente agregado ", "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCamposDeMateriales();
                        ActualizarTablaMateriales();
                        PonerBotonesMaterialesEnEdicion(false);
                    }
                    else
                    {
                        MessageBox.Show("Algo salio mal ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                        m.Categoria = txbMaterialesCategoria.Text;
                        m.Descripcion = txbMaterialesDescripcion.Text;
                        m.Nombre = txbMaterialesNombre.Text;
                        if (manejadorMateriales.Modificar(m))
                        {
                            MessageBox.Show("Material modificado  correctamente ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDeMateriales();
                            ActualizarTablaMateriales();
                            PonerBotonesMaterialesEnEdicion(false);
                        }
                        else 
                        {
                         MessageBox.Show("Algo salio mal","Inventario", MessageBoxButton.OK, MessageBoxImage.Error);    
                        }
                    }
                }
            }
            else 
            {
              Material m = dtgMateriales.SelectedItem as Material; 

            }
        }

        private void btnMaterialesCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeMateriales();
            PonerBotonesMaterialesEnEdicion(false);
        }

        private void btnMaterialesEliminar_Click(object sender, RoutedEventArgs e)
        {
            Material m= dtgMateriales.SelectedItem as Material;
            if (m != null) 
            {
              if (MessageBox.Show("Realmente deseas eliminar este material ?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes) 
                {
                    if (manejadorMateriales.Eliminar(m))
                    {
                        MessageBox.Show("Material eliminado correctamente ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaMateriales();
                    }
                    else 
                    {
                        MessageBox.Show("Algo salio mal ", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error); 
                        ActualizarTablaEmpleados();
                    }
                } 
            }
        }

        private void btnEmpleadosEditar_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    internal class ManejadorMateriales : IManejadorMateriales 
    {
        public ManejadorMateriales(RepositorioDeEmpleados repositorioDeEmpleados)
        {
            RepositorioDeEmpleados = repositorioDeEmpleados;
        }

        public RepositorioDeEmpleados RepositorioDeEmpleados { get; }

        public bool Eliminar(object id)
        {
            throw new NotImplementedException();
        }

        public int listar()
        {
            throw new NotImplementedException();
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
        public ManejadorEmpleados()
        {
        }

        public ManejadorEmpleados(RepositorioDeEmpleados repositorioDeEmpleados)
        {
        }

        IEnumerable IManejadorEmpleados.Listar { get ; set; } 

        public bool Agregar(string id)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string id)
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

