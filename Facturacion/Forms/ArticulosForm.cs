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
    public partial class ArticulosForm : Form
    {
        public ArticulosForm()
        {
            InitializeComponent();
        }

        //Helpers
        private void CrudArticulos()
        {
            using (Model.DemoDB context = new Model.DemoDB())
            {
                var query = from tbl in context.ARTICULOS
                            select new
                            {
                                Codigo = tbl.id_articulo,
                                Descripcion = tbl.descripcion,
                                Existencia = tbl.existencia
                            };
                dgvArticulos.DataSource = query.ToList();
                //Console.WriteLine(query);
            }
        }
        private void CrudArticulos(string descripcionT, int existenciaT)
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                Model.ARTICULOS articulos = new Model.ARTICULOS
                {
                    //id_articulo
                    descripcion = descripcionT,
                    existencia = existenciaT
                };
                data.ARTICULOS.Add(articulos);
                data.SaveChanges();
                CrudArticulos();
            }
        }
        private void CrudArticulos(int idArticulo, string descripcionT, int existenciaT)
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                Model.ARTICULOS articulos = data.ARTICULOS.FirstOrDefault(tbl => tbl.id_articulo == idArticulo);
                articulos.descripcion = descripcionT;
                articulos.existencia = existenciaT;
                data.SaveChanges();
                CrudArticulos();
            }
        }
        private void CrudArticulos(int idArticulo)
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                Model.ARTICULOS articulos = data.ARTICULOS.FirstOrDefault(tbl => tbl.id_articulo == idArticulo);
                data.ARTICULOS.Remove(articulos);
                data.SaveChanges();
                CrudArticulos();
            }
        }


        //Handles
        private void ArticulosForm_Load(object sender, EventArgs e)
        {
            CrudArticulos();
        }
        private void dgvArticulos_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Text = dgvArticulos.SelectedRows[0].Cells[0].Value.ToString();
            this.txtDescripcion.Text = dgvArticulos.SelectedRows[0].Cells[1].Value.ToString();
            this.txtNExistencia.Text = dgvArticulos.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string descripcionT = txtDescripcion.Text.Trim();
            int existenciaT = int.Parse(txtNExistencia.Text.ToString());

            CrudArticulos(descripcionT, existenciaT);
            MessageBox.Show("Registro agregado", "ARTICULOS", MessageBoxButtons.OK);

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(dgvArticulos.SelectedRows[0].Cells[0].Value.ToString());
            string descripcionT = txtDescripcion.Text.Trim();
            int existenciaT = int.Parse(txtNExistencia.Text.ToString());

            CrudArticulos(idArticulo, descripcionT, existenciaT);

            MessageBox.Show("Registro modificado", "ARTICULOS", MessageBoxButtons.OK);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idArticulo = int.Parse(dgvArticulos.SelectedRows[0].Cells[0].Value.ToString());

            DialogResult dResult = MessageBox.Show("Confirmar si de desea eliminar registro", "ARTICULOS", MessageBoxButtons.OKCancel);
            if (dResult == DialogResult.OK)
            {
                CrudArticulos(idArticulo);
                MessageBox.Show("Registro eliminado", "ARTICULOS", MessageBoxButtons.OK);
            }
            if (dResult == DialogResult.Cancel)
            {
                return;
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
