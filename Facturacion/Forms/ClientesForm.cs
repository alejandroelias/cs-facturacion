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
        public ClientesForm()
        {
            InitializeComponent();
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = false;

            List<Model.ViewModel.DepartamentoViewModel> listDepartamentos = new List<Model.ViewModel.DepartamentoViewModel>();
            using (Model.DemoDB data = new Model.DemoDB())
            {
                listDepartamentos = (from tbl in data.DEPARTAMENTOS
                                     select new Model.ViewModel.DepartamentoViewModel
                                     {
                                         Codigo = tbl.codigo,
                                         Descripcion = tbl.descripcion
                                     }).ToList();
            }
            cboDepartamento.DataSource = listDepartamentos;
            cboDepartamento.ValueMember = "Descripcion";
            cboDepartamento.DisplayMember = "Descripcion";
        }

        private void rbContado_CheckedChanged(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = false;
        }

        private void rbCredito_CheckedChanged(object sender, EventArgs e)
        {
            txtDiasCredito.Enabled = true;
        }
    }
}
