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
    public partial class Main : Form
    {
        private Forms.ArticulosForm formArticulos;
        private Forms.ClientesForm formClientes;
        private Forms.FacturaForm formFacturas;
        public Main()
        {
            InitializeComponent();
        }
        void closeForms(object sender, FormClosedEventArgs e)
        {
            //this.Activate();
            //formArticulos.Activate();
            //formClientes.Activate();
            //formFacturas.Activate();
        }
        private void btnIrClientes_Click(object sender, EventArgs e)
        {

                formClientes = new Forms.ClientesForm();
                formClientes.MdiParent = this;
                formClientes.Show();
        }

        private void btnIrArticulos_Click(object sender, EventArgs e)
        {

                formArticulos = new Forms.ArticulosForm();
                formArticulos.MdiParent = this;
                //formArticulos.FormClosed += new FormClosedEventHandler(closeForms);
                formArticulos.Show();
       
        }

        private void btnIrFacturacion_Click(object sender, EventArgs e)
        {

                formFacturas = new Forms.FacturaForm();
                formFacturas.MdiParent = this;
                //formFacturas.FormClosed += new FormClosedEventHandler(closeForms);
                formFacturas.Show();

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
