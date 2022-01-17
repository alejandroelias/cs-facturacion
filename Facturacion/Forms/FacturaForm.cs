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
        private static List<Model.ViewModel.ClienteViewModel> getClientes(int idCliente)
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
        private static List<Model.ViewModel.ArticuloViewModel> getArticulos(int idArticulo)
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
        private void totales()
        {
            int sumCantidad = 0;
            decimal sumas = 0;
            decimal iva = 0;
            Clases.ConvertirNumerosLetras numLetras = new Clases.ConvertirNumerosLetras();
            string letras;

            foreach (DataGridViewRow gr in dgvFactura.Rows)
            {
                int cantidad = int.Parse(gr.Cells[0].Value.ToString());
                sumCantidad += cantidad;

                decimal ventasGravadas = decimal.Parse(gr.Cells[3].Value.ToString());
                sumas += decimal.Round(ventasGravadas,2);

            }
            lblSumCantidad.Text = sumCantidad.ToString();
            lblSumas.Text = sumas.ToString();
            iva = decimal.Round(sumas * (decimal)0.13,2);
            lblIVA.Text = iva.ToString();
            lblTotal.Text = decimal.Round((iva + sumas), 2).ToString();
            letras = numLetras.Convertir(lblTotal.Text.ToString(), true, "DOLARES");
            lblNumeroLetras.Text = letras;
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

            txtFecha.Text = DateTime.Now.ToString();

            cboCliente.TabIndex = 0;
            cboArticulo.TabIndex = 1;
            txtCantidad.TabIndex = 2;
            txtPrecio.TabIndex = 3;
            btnAgregar.TabIndex = 4;

        }
        private void cboCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                int idCliente = (int)cboCliente.SelectedValue;
                List<Model.ViewModel.ClienteViewModel> listClientes = getClientes(idCliente);
                    foreach (var item in listClientes)
                    {
                        //Console.WriteLine(item.ClienteDireccion);
                        txtDireccion.Text = item.ClienteDireccion;
                        txtDepartamento.Text = item.ClienteDepartamento;
                        txtRegistro.Text = item.ClienteNumRegistro;
                        txtNit.Text = item.ClienteNumNit;
                        txtGiro.Text = item.ClienteGiro;
                    }
            }
            catch (InvalidCastException ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        private void cboArticulo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = (int)cboArticulo.SelectedValue;
                List<Model.ViewModel.ArticuloViewModel> listArticulos = getArticulos(idArticulo);
                    foreach (var item in listArticulos)
                    {
                        txtExistencia.Text = item.ArticuloExistencia.ToString();
                    }
            }
            catch (InvalidCastException ex)
            {

                //MessageBox.Show(ex.Message);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Value.Equals(0)|| txtPrecio.Value.Equals(0) || txtPrecio.Value.Equals(0.00) )
            {
                MessageBox.Show("Cantidad o precio vacio", "FACTURACION", MessageBoxButtons.OK);
            }
            else
            {
                string descripcion = cboArticulo.Text;
                string cantidad = txtCantidad.Text.Trim();
                string precio = txtPrecio.Text.Trim();
                string ventasGravadas = (decimal.Parse(cantidad) * decimal.Parse(precio)).ToString();
                string idArticulo = cboArticulo.SelectedValue.ToString();

                dgvFactura.Rows.Add(new object[] { cantidad, descripcion, precio, ventasGravadas, "Eliminar", idArticulo });
                txtCantidad.Text = "";
                txtPrecio.Text = "";
                cboArticulo.Focus();

                totales();
            }

            
        }
        private void dgvFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvFactura.Columns["Accion"].Index)
                return;
            dgvFactura.Rows.RemoveAt(e.RowIndex);

            totales();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (Model.DemoDB data = new Model.DemoDB())
            {
                using (var dataContextTrans = data.Database.BeginTransaction())
                {
                    try
                    {
                        //FACTURAS
                        Model.FACTURAS facturas = new Model.FACTURAS();
                        //id_factura identity(1,1)
                        facturas.fk_id_cliente = (int)cboCliente.SelectedValue;
                        facturas.clientes_nombre = cboCliente.Text;
                        facturas.clientes_direccion = txtDireccion.Text;
                        facturas.clientes_departamento = txtDepartamento.Text;
                        facturas.clientes_registro = txtRegistro.Text;
                        facturas.clientes_num_nit = txtNit.Text;
                        facturas.clientes_giro = txtGiro.Text;
                        facturas.subtotal = decimal.Parse(lblSumas.Text.ToString());
                        facturas.iva = decimal.Parse(lblIVA.Text.ToString());
                        facturas.total = decimal.Parse(lblTotal.Text.ToString());
                        facturas.total_letras = lblNumeroLetras.Text.ToString();

                        data.FACTURAS.Add(facturas);
                        data.SaveChanges();

                        foreach (DataGridViewRow gr in dgvFactura.Rows)
                        {
                            //FACTURAS_DETALLE
                            Model.FACTURAS_DETALLE detFacturas = new Model.FACTURAS_DETALLE();
                            //id_factura_detalle identity(1,1)
                            detFacturas.fk_id_factura = facturas.id_factura;
                            detFacturas.fk_id_articulo = int.Parse(gr.Cells[5].Value.ToString());
                            detFacturas.articulos_descripcion = gr.Cells[1].Value.ToString();
                            detFacturas.cantidad = int.Parse(gr.Cells[0].Value.ToString());
                            detFacturas.precio_unitario = decimal.Parse(gr.Cells[2].Value.ToString());
                            detFacturas.subtotal = decimal.Parse(gr.Cells[3].Value.ToString());

                            data.FACTURAS_DETALLE.Add(detFacturas);
                        }
                        data.SaveChanges();
                        dataContextTrans.Commit();

                        MessageBox.Show("Documento guardado", "FACTURACION", MessageBoxButtons.OK);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message + ex.StackTrace);
                        dataContextTrans.Rollback();
                    }
                }
            }
        }
        #endregion
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
