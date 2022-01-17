using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuarioT = txtNombre.Text.Trim();
            string contrasenaT = txtContrasena.Text.Trim();


            using (Model.DemoDB data = new Model.DemoDB())
            {
                var listUsuarios = from tbl in data.USUARIOS
                                   where tbl.nombre == usuarioT
                                   && tbl.contrasena == contrasenaT
                                   select tbl;
                if (listUsuarios.Count() >0)
                {
                    this.Hide();
                    Forms.Main mainForm = new Forms.Main();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                }
                else
	            {
                    MessageBox.Show("Usuario no registrado");
	            }
            }
        }
    }
}
