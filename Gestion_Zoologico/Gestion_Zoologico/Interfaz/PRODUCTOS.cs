using Gestion_Zoologico.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gestion_Zoologico.Interfaz
{
    public partial class PRODUCTOS : Form
    {

        string Operacion = "Insertar";
        string idEmpleado;

  

        public PRODUCTOS()
        {
            InitializeComponent();
            ListarProductos();
        }
     
        private void PRODUCTOS_Load(object sender, EventArgs e)
        {
            FListarAreas();
            FListarLugarArea();
            FListarHora();
        }
        private void FListarAreas()
        {
            Clases.ClsEmpleados objProd = new ClsEmpleados();
            CmbArea.DataSource = objProd.ListarAreas();
            CmbArea.DisplayMember = "AREA";
            CmbArea.ValueMember = "IDAREA";
        }
        private void FListarLugarArea()
        {
            ClsEmpleados objProd = new ClsEmpleados();
            CmbLugarArea.DataSource = objProd.ListarLugarArea();
            CmbLugarArea.DisplayMember = "LUGAR_AREA";
            CmbLugarArea.ValueMember = "IDLUGAR_AREA";
        }
        private void FListarHora()
        {
            ClsEmpleados objProd = new ClsEmpleados();
            comboHora.DataSource = objProd.ListarHora();
            comboHora.DisplayMember = "HORA";
            comboHora.ValueMember = "IDHORA";
        }



        ClsEmpleados objproducto = new ClsEmpleados();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto._IdArea = Convert.ToInt32(CmbArea.SelectedValue);
                objproducto._IdLugarArea = Convert.ToInt32(CmbLugarArea.SelectedValue);
                objproducto._Idhora = Convert.ToInt32(comboHora.SelectedValue);
                objproducto._Nombre = txtNombre.Text;
                objproducto._Direccion = txtDireccion.Text;
                objproducto._Telefono = Convert.ToInt32(txtNumero.Text);
                objproducto.InsertarEmpleados();

                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto._IdArea = Convert.ToInt32(CmbArea.SelectedValue);
                objproducto._IdLugarArea = Convert.ToInt32(CmbLugarArea.SelectedValue);
                objproducto._Idhora = Convert.ToInt32(comboHora.SelectedValue);
                objproducto._Nombre = txtNombre.Text;
                objproducto._Direccion = txtDireccion.Text;
                objproducto._Telefono = Convert.ToInt32(txtNumero.Text);
                objproducto._Idempleado = Convert.ToInt32(idEmpleado);
                objproducto.EditarProductos();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");


            }
            ListarProductos();

        }
        private void ListarProductos()
        {
            ClsEmpleados objprod = new ClsEmpleados();
            dataGridView1.DataSource = objprod.ListarEmpleados();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                objproducto._Idempleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                objproducto.EliminarProducto();
                MessageBox.Show("Se elimino satisfactoriamente");
                ListarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                CmbArea.Text = dataGridView1.CurrentRow.Cells["AREA"].Value.ToString();
                CmbLugarArea.Text = dataGridView1.CurrentRow.Cells["lUGAR_AREA"].Value.ToString();
                comboHora.Text = dataGridView1.CurrentRow.Cells["HORA"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
                txtNumero.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
                idEmpleado = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
