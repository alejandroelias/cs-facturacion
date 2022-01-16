using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion.Forms
{
    public partial class FacturaForm : Form
    {
        public FacturaForm()
        {
            InitializeComponent();
        }

        #region Helpers
        private static List<Model.ViewModel.ClienteViewModel> getClientes()
        {
            List<Model.ViewModel.ClienteViewModel> listClientes = new List<Model.ViewModel.ClienteViewModel>();
            using (Model.DemoDB data = new Model.DemoDB())
            {
                listClientes = (from tbl in data.CLIENTES
                                select new Model.ViewModel.ClienteViewModel
                                {
                                    ClienteID = tbl.id_cliente,
                                    ClienteNombre = tbl.nombre,
                                    ClienteDireccion = tbl.direccion,
                                    ClienteDepartamento = tbl.departamento,
                                    ClienteCondicionPago = tbl.condicion_pago,
                                    ClienteDiasCredito = tbl.dias_credito.Value,
                                    ClienteNumRegistro = tbl.num_registro,
                                    ClienteNumNit = tbl.num_nit,
                                    ClienteGiro = tbl.giro
                                }).ToList();
            }
            return listClientes;
        }
        private static List<Model.ViewModel.ArticuloViewModel> getArticulos()
        {
            List<Model.ViewModel.ArticuloViewModel> listArticulos = new List<Model.ViewModel.ArticuloViewModel>();
            using (Model.DemoDB data = new Model.DemoDB())
            {
                listArticulos = (from tbl in data.ARTICULOS
                                select new Model.ViewModel.ArticuloViewModel
                                {
                                    ArticuloID = tbl.id_articulo,
                                    ArticuloExistencia = tbl.existencia.Value, 
                                    ArticuloDescripcion = tbl.descripcion
                                }).ToList();
            }
            return listArticulos;
        }
        private static List<Model.ViewModel.ClienteViewModel> getClientesById(int idCliente)
        {
            List<Model.ViewModel.ClienteViewModel> listClientes = new List<Model.ViewModel.ClienteViewModel>();
            using (Model.DemoDB data = new Model.DemoDB())
            {
                listClientes = (from tbl in data.CLIENTES
                                where tbl.id_cliente == idCliente
                                select new Model.ViewModel.ClienteViewModel
                                {
                                    ClienteNombre = tbl.nombre,
                                    ClienteDireccion = tbl.direccion,
                                    ClienteDepartamento = tbl.departamento,
                                    ClienteCondicionPago = tbl.condicion_pago,
                                    ClienteDiasCredito = tbl.dias_credito.Value,
                                    ClienteNumRegistro = tbl.num_registro,
                                    ClienteNumNit = tbl.num_nit,
                                    ClienteGiro = tbl.giro
                                }).ToList();
            }
            return listClientes;
        }
        private static List<Model.ViewModel.ArticuloViewModel> getArticulosById(int idArticulo)
        {
            List<Model.ViewModel.ArticuloViewModel> listArticulos = new List<Model.ViewModel.ArticuloViewModel>();
            using (Model.DemoDB data = new Model.DemoDB())
            {
                listArticulos = (from tbl in data.ARTICULOS
                                where tbl.id_articulo == idArticulo
                                select new Model.ViewModel.ArticuloViewModel
                                {
                                    ArticuloDescripcion = tbl.descripcion,
                                    ArticuloExistencia = tbl.existencia.Value
                                }).ToList();
            }
            return listArticulos;
        }
        #endregion

        #region Handles
        private void FacturaForm_Load(object sender, EventArgs e)
        {
            List<Model.ViewModel.ClienteViewModel> listClientes = getClientes();
            cboCliente.DataSource = listClientes;
            cboCliente.ValueMember = "ClienteID";
            cboCliente.DisplayMember = "ClienteNombre";

            List<Model.ViewModel.ArticuloViewModel> listArticulos = getArticulos();
            cboArticulo.DataSource = listArticulos;
            cboArticulo.ValueMember = "ArticuloID";
            cboArticulo.DisplayMember = "ArticuloDescripcion";
            
        }
        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                int idCliente = (int)cboCliente.SelectedValue;
                List<Model.ViewModel.ClienteViewModel> listClientes = getClientesById(idCliente);
                    foreach (var item in listClientes)
                    {
                        //Console.WriteLine(item.ClienteDireccion);
                        txtDireccion.Text = item.ClienteDireccion;
                    }
            }
            catch (InvalidCastException ex)
            {
                //throw;
            }

        }
        private void cboArticulo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = (int)cboArticulo.SelectedValue;
                List<Model.ViewModel.ArticuloViewModel> listArticulos = getArticulosById(idArticulo);
                    foreach (var item in listArticulos)
                    {
                        txtExistencia.Text = item.ArticuloExistencia.ToString();
                    }
            }
            catch (InvalidCastException ex)
            {
                
                //throw;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
