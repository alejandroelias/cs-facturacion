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
    public partial class ClientesForm : Form
    {
        private string condicionPagoValue = "Contado";

        public ClientesForm()
        {
            InitializeComponent();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = false;
            txtCodigo.Enabled = false;

            List<Model.ViewModel.DepartamentoViewModel> listDepartamentos = new List<Model.ViewModel.DepartamentoViewModel>();
            using (Model.DemoDB data = new Model.DemoDB())
            {
                listDepartamentos = (from tbl in data.DEPARTAMENTOS
                                     select new Model.ViewModel.DepartamentoViewModel
                                     {
                                         ID = tbl.id_depart,
                                         Codigo = tbl.codigo,
                                         Descripcion = tbl.descripcion
                                     }).ToList();
            }
            cboDepartamento.DataSource = listDepartamentos;
            cboDepartamento.ValueMember = "ID";
            cboDepartamento.DisplayMember = "Descripcion";
        }
         
        private void rbContado_CheckedChanged(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = false;
            condicionPagoValue = "Contado";
            //diasCreditoValue = 0;
        }
       
        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = true;
            condicionPagoValue = "Credito";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
     
            string nombreT = txtNombre.Text.Trim();
            string direccionT = txtDireccion.Text.Trim();
            string departamentoT = cboDepartamento.Text;
            string numRegistroT = txtMRegistro.Text.Trim();
            string numNitT = txtMNit.Text.Trim();
            string giroT = txtGiro.Text.Trim();
            string condicionPagoT = condicionPagoValue;
            int fk_id_departT = (int)cboDepartamento.SelectedValue;

            int diasCreditoValue = 0;
            if (rbCredito.Checked)
            {
                diasCreditoValue = int.Parse(txtDiasCredito.Text.Trim());
            }
            if (rbContado.Checked)
            {
                diasCreditoValue = 0;
            }

            using (Model.DemoDB context = new Model.DemoDB())
            {
                Model.CLIENTES clientes = new Model.CLIENTES
                {
                    fk_id_depart = fk_id_departT,
                    nombre = nombreT,
                    direccion = direccionT,
                    departamento = departamentoT,
                    num_registro = numRegistroT,
                    num_nit = numNitT,
                    giro = giroT,
                    condicion_pago = condicionPagoT,
                    dias_credito = diasCreditoValue
                };
                context.CLIENTES.Add(clientes);
                context.SaveChanges();
                // TODO: loadData();
            }
        }
    }
}
