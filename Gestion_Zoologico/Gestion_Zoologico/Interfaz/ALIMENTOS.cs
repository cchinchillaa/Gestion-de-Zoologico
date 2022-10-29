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
    public partial class ALIMENTOS : Form
    {
        public ALIMENTOS()
        {
           
            InitializeComponent();
            FlistarAlimentos();
           
            FListarPesoyMedidas();
        }


        string Operacion = "Insertar";
        string idAlimento;







       
        private void FListarPesoyMedidas()
        {
            ClsAlimentos objProd = new ClsAlimentos();
            CmbPesoyMedida.DataSource = objProd.ListarPesoyMedidas();
            CmbPesoyMedida.DisplayMember = "PESO_Y_MEDIDA";
            CmbPesoyMedida.ValueMember = "IDPESO_Y_MEDIDA";
        }

        private void FlistarAlimentos()
        {
            ClsAlimentos objProd = new ClsAlimentos();
            dataGridViewAlimentos.DataSource = objProd.ListarAlimentos();
        }


        ClsAlimentos objproducto = new ClsAlimentos();



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto._Idpesoymedida = Convert.ToInt32(CmbPesoyMedida.SelectedValue);
                objproducto._Cantidad = Convert.ToInt64(txtCantidad.Text);
                objproducto._Alimento = txtAlimento.Text;
                objproducto._Fecha_ingreso = txtFechaIngreso.Text;
                objproducto._Feha_vencimiento = txtFechaVence.Text;
                objproducto.InsertarAlimento();

                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto._Idpesoymedida = Convert.ToInt32(CmbPesoyMedida.SelectedValue);
                objproducto._Cantidad = Convert.ToInt64(txtCantidad.Text);
                objproducto._Alimento = txtAlimento.Text;
                objproducto._Fecha_ingreso = txtFechaIngreso.Text;
                objproducto._Feha_vencimiento = txtFechaVence.Text;
                objproducto._Idalimento = Convert.ToInt32(idAlimento);
                objproducto.EditarAlimento();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");


            }
            FlistarAlimentos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAlimentos.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                CmbPesoyMedida.Text = dataGridViewAlimentos.CurrentRow.Cells["PESO_Y_MEDIDA"].Value.ToString();
                txtAlimento.Text = dataGridViewAlimentos.CurrentRow.Cells["ALIMENTO"].Value.ToString();
                txtCantidad.Text = dataGridViewAlimentos.CurrentRow.Cells["CANTIDAD"].Value.ToString();
                txtFechaIngreso.Text = dataGridViewAlimentos.CurrentRow.Cells["FECHA_INGRESO"].Value.ToString();
                txtFechaVence.Text = dataGridViewAlimentos.CurrentRow.Cells["FECHA_VENCIMIENTO"].Value.ToString();
                idAlimento = dataGridViewAlimentos.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAlimentos.SelectedRows.Count > 0)
            {
                objproducto._Idalimento = Convert.ToInt32(dataGridViewAlimentos.CurrentRow.Cells[0].Value);
                objproducto.EliminarAlimento();
                MessageBox.Show("Se elimino satisfactoriamente");
                FlistarAlimentos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ALIMENTOS_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
