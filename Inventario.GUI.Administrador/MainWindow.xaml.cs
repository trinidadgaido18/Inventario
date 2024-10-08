﻿ using System;
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
            manejadorEmpleados = new ManejadorEmpleados(new RepositorioEmpleados()); 
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

    internal class RepositorioEmpleados
    {
        public RepositorioEmpleados()
        {
        }
    }

    internal class ManejadorEmpleados : IManejadorEmpleados
    {
        private RepositorioEmpleados repositorioEmpleados;

        public ManejadorEmpleados(RepositorioEmpleados repositorioEmpleados)
        {
            this.repositorioEmpleados = repositorioEmpleados;
        }
    }

    internal interface IManejadorEmpleados
    {
    }
}
