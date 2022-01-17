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

        //Helpers
        private void getClientes()
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                var query = from tbl in data.CLIENTES
                            select new
                            {
                                Codigo = tbl.id_cliente,
                                Nombre = tbl.nombre,
                                Direccion = tbl.direccion,
                                Departamento = tbl.departamento,
                                Registro = tbl.num_registro,
                                NIT = tbl.num_nit,
                                Giro = tbl.giro,
                                Pago = tbl.condicion_pago,
                                DiasCredito = tbl.dias_credito
                            };
                dgvClientes.DataSource = query.ToList();
                //Console.WriteLine(query);
            }
        }
        private static List<Model.ViewModel.DepartamentoViewModel> getDepartamentos()
        {
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
            return listDepartamentos;
        }
        private void insertClientes(string nombreT, string direccionT, string departamentoT, string numRegistroT, string numNitT, string giroT, string condicionPagoT, int fk_id_departT, int diasCreditoValue)
        {
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
                getClientes();
            }
        }
        private void updateClientes(int idCliente, string nombreT, string direccionT, string departamentoT, string numRegistroT, string numNitT, string giroT, string condicionPagoT, int fk_id_departT, int diasCreditoValue)
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                Model.CLIENTES clientes = data.CLIENTES.FirstOrDefault(tbl => tbl.id_cliente == idCliente);
                clientes.fk_id_depart = fk_id_departT;
                clientes.nombre = nombreT;
                clientes.direccion = direccionT;
                clientes.departamento = departamentoT;
                clientes.condicion_pago = condicionPagoT;
                clientes.dias_credito = diasCreditoValue;
                clientes.num_registro = numRegistroT;
                clientes.num_nit = numNitT;
                clientes.giro = giroT;

                data.SaveChanges();
                getClientes();
            }
        }
        private void deleteClientes(int idCliente)
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                Model.CLIENTES clientes = data.CLIENTES.FirstOrDefault(tbl => tbl.id_cliente == idCliente);
                data.CLIENTES.Remove(clientes);
                data.SaveChanges();
                getClientes();
            }
        }
         
        //Handles
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = false;
            txtCodigo.Enabled = false;

            getClientes();

            List<Model.ViewModel.DepartamentoViewModel> listDepartamentos = getDepartamentos();
            cboDepartamento.DataSource = listDepartamentos;
            cboDepartamento.ValueMember = "ID";
            cboDepartamento.DisplayMember = "Descripcion";
        }
        private void dgvClientes_Click(object sender, EventArgs e)
        {

            this.txtCodigo.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            this.txtNombre.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
            this.txtDireccion.Text = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
            this.cboDepartamento.Text = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();
            this.txtMRegistro.Text = dgvClientes.SelectedRows[0].Cells[4].Value.ToString();
            this.txtMNit.Text = dgvClientes.SelectedRows[0].Cells[5].Value.ToString();
            this.txtGiro.Text = dgvClientes.SelectedRows[0].Cells[6].Value.ToString();
            this.txtDiasCredito.Text = dgvClientes.SelectedRows[0].Cells[8].Value.ToString();

            string condicionPago = dgvClientes.SelectedRows[0].Cells[7].Value.ToString();
            if (condicionPago == "Contado")
            {
                rbContado.Checked = true;
            }
            if (condicionPago == "Credito")
            {
                rbCredito.Checked = true;
            }
        }
        private void rbContado_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDiasCredito.Enabled = false;
            condicionPagoValue = "Contado";
            //diasCreditoValue = 0;
        }
        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDiasCredito.Enabled = true;
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

            insertClientes(nombreT, direccionT, departamentoT, numRegistroT, numNitT, giroT, condicionPagoT, fk_id_departT, diasCreditoValue);

            MessageBox.Show("Registro agregado", "CLIENTES", MessageBoxButtons.OK);

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(dgvClientes.SelectedRows[0].Cells[0].Value.ToString());
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

            updateClientes(idCliente, nombreT, direccionT, departamentoT, numRegistroT, numNitT, giroT, condicionPagoT, fk_id_departT, diasCreditoValue);

            MessageBox.Show("Registro modificado", "CLIENTES", MessageBoxButtons.OK);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(dgvClientes.SelectedRows[0].Cells[0].Value.ToString());

            DialogResult dResult = MessageBox.Show("Confirmar si de desea eliminar registro", "CLIENTES", MessageBoxButtons.OKCancel);
            if (dResult == DialogResult.OK)
            {
                deleteClientes(idCliente);
                MessageBox.Show("Registro eliminado", "CLIENTES", MessageBoxButtons.OK);
            }
            if (dResult == DialogResult.Cancel)
            {
                return;
            }
            
        }

        private void tbnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
