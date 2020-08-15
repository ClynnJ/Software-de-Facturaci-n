using Facturacion.BIZ;
using Facturacion.COMMON.Entidades;
using Facturacion.COMMON.Interfaces;
using Facturacion.DAL;
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

namespace Facturacion.GUI.Administrador
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

        IManejadorClientes manejadorClientes;

        accion accionClientes;
        public MainWindow()
        {
            InitializeComponent();
            PonerBotonesClientesEnEdicion(false);
            LimpiarCamposDeClientes();
            manejadorClientes = new ManejadorCliente(new RepositorioDeClientes());
            ActualizarTablaClientes();
        }

        private void ActualizarTablaClientes()
        {
            dtgClientes.ItemsSource = null;
            dtgClientes.ItemsSource = manejadorClientes.Listar;
        }

        private void LimpiarCamposDeClientes()
        {
            txbClientesCedula.Clear();
            txbClientesDireccionIP.Clear();
            txbClientesDireccionMAC.Clear();
            txbClientesId.Text = "";
            txbClientesNombre.Clear();
            txbClientesPagado.Text = "";
            txbClientesTarifa.Clear();
            txbClientesTelefono.Clear();
            txbClientesVelocidad.Clear();
        }

        private void PonerBotonesClientesEnEdicion(bool value)
        {
            btnClientesCancelar.IsEnabled = value;
            btnClientesEditar.IsEnabled = !value;
            btnClientesEliminar.IsEnabled = !value;
            btnClientesGuardar.IsEnabled = value;
            btnClientesNuevo.IsEnabled = !value;
        }

        private void btnClientesNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeClientes();
            PonerBotonesClientesEnEdicion(true);
            accionClientes = accion.Nuevo;
        }


        private void btnClientesEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente clnt = dtgClientes.SelectedItem as Cliente;
            if (clnt != null)
            {
                txbClientesId.Text = clnt.Id;
                txbClientesCedula.Text = clnt.Cedula.ToString();
                txbClientesDireccionIP.Text = clnt.DireccionIP;
                txbClientesDireccionMAC.Text = clnt.DireccionMAC;
                txbClientesNombre.Text = clnt.Nombre;
                txbClientesTarifa.Text = clnt.Tarifa.ToString();
                txbClientesTelefono.Text = clnt.NumeroTelefono;
                txbClientesVelocidad.Text = clnt.CantidadMegas.ToString();
                txbClientesPagado.Text = clnt.Pagado;

                accionClientes = accion.Editar;
                PonerBotonesClientesEnEdicion(true);
            }
           
        }

        private void btnClientesGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(accionClientes == accion.Nuevo)
            {
                Cliente clnt = new Cliente()
                {
                    Nombre = txbClientesNombre.Text,
                    Cedula = txbClientesCedula.Text,
                    CantidadMegas = Int32.Parse(txbClientesVelocidad.Text),
                    Tarifa = Int32.Parse(txbClientesTarifa.Text),
                    DireccionIP = txbClientesDireccionIP.Text,
                    DireccionMAC = txbClientesDireccionMAC.Text,
                    NumeroTelefono = txbClientesTelefono.Text,
                    Pagado = txbClientesPagado.Text
                };
                if (manejadorClientes.Agregar(clnt))
                {
                    MessageBox.Show("Cliente agregado correctamente", "Facturacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeClientes();
                    ActualizarTablaClientes();
                    PonerBotonesClientesEnEdicion(false);
                } else
                {
                    MessageBox.Show("Cliente no se pudo agregar", "Facturacion", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente clnt = dtgClientes.SelectedItem as Cliente;
                clnt.Nombre = txbClientesNombre.Text;
                clnt.Cedula = txbClientesCedula.Text;
                clnt.CantidadMegas = Int32.Parse(txbClientesVelocidad.Text);
                clnt.Tarifa = Int32.Parse(txbClientesTarifa.Text);
                clnt.DireccionIP = txbClientesDireccionIP.Text;
                clnt.DireccionMAC = txbClientesDireccionMAC.Text;
                clnt.NumeroTelefono = txbClientesTelefono.Text;
                clnt.Pagado = txbClientesPagado.Text;

                if (manejadorClientes.Modificar(clnt))
                {
                    MessageBox.Show("Cliente actualizado correctamente", "Facturacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeClientes();
                    ActualizarTablaClientes();
                    PonerBotonesClientesEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo actualizar", "Facturacion", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnClientesCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeClientes();
            PonerBotonesClientesEnEdicion(false);
        }

        private void btnClientesEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente clnt = dtgClientes.SelectedItem as Cliente;

            if(clnt != null)
            {
                if(MessageBox.Show("Realmente deseas eliminar este cliente?", "Facturacion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorClientes.Eliminar(clnt.Id))
                    {
                        MessageBox.Show("Cliente eliminado", "Facturacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaClientes();
                    } 
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el cliente.", "Facturacion", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
    }
}
