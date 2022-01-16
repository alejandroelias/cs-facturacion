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
        #endregion

        #region Handles

        private void FacturaForm_Load(object sender, EventArgs e)
        {
            List<Model.ViewModel.ClienteViewModel> listClientes = getClientes();
            cboCliente.DataSource = listClientes;
            cboCliente.ValueMember = "ClienteID";
            cboCliente.DisplayMember = "ClienteNombre";
            
        }
        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

            int idCliente = (int)cboCliente.SelectedValue; //parametro
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
        #endregion
    }
}
