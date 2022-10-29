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
    public partial class ANIMALES : Form
    {
        public ANIMALES()
        {
            
            InitializeComponent();
            ListarAnimales();
            FListarAlimentos();
            FListarDietas();
            FListarPesoyMedidas();
        }


        string Operacion = "Insertar";
        string idAnimal;


        private void FListarAlimentos()
        {
            ClsAnimales objProd = new ClsAnimales();
            CmbAlimento.DataSource = objProd.ListarAlimentos();
            CmbAlimento.DisplayMember = "ALIMENTO";
            CmbAlimento.ValueMember = "IDALIMENTO";
        }



        private void FListarDietas()
        {
            ClsAnimales objProd = new ClsAnimales();
            CmbDieta.DataSource = objProd.ListarDietas();
            CmbDieta.DisplayMember = "DIETA";
            CmbDieta.ValueMember = "IDDIETA";
        }
        private void FListarPesoyMedidas()
        {
            ClsAnimales objProd = new ClsAnimales();
            CmbPesoyMedida.DataSource = objProd.ListarPesoyMedidas();
            CmbPesoyMedida.DisplayMember = "PESO_Y_MEDIDA";
            CmbPesoyMedida.ValueMember = "IDPESO_Y_MEDIDA";
        }

        private void ListarAnimales()
        {
            ClsAnimales objProd = new ClsAnimales();
            dataGridViewAnimales.DataSource = objProd.ListarAnimales();
        }


        ClsAnimales objproducto = new ClsAnimales();



        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (Operacion == "Insertar")
            {
                objproducto._Idpesoymedida = Convert.ToInt32(CmbPesoyMedida.SelectedValue);
                objproducto._Iddieta = Convert.ToInt32(CmbDieta.SelectedValue);
                objproducto._Idalimento = Convert.ToInt32(CmbAlimento.SelectedValue);
                objproducto._Animal = txtAnimal.Text;            
                objproducto.InsertarAnimal();

                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto._Idpesoymedida = Convert.ToInt32(CmbPesoyMedida.SelectedValue);
                objproducto._Iddieta = Convert.ToInt32(CmbDieta.SelectedValue);
                objproducto._Idalimento = Convert.ToInt32(CmbAlimento.SelectedValue);
                objproducto._Animal = txtAnimal.Text;
                objproducto._Idanimal = Convert.ToInt32(idAnimal);
                objproducto.EditarAnimal();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");


            }
            ListarAnimales();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnimales.SelectedRows.Count > 0)
            {
                objproducto._Idanimal = Convert.ToInt32(dataGridViewAnimales.CurrentRow.Cells[0].Value);
                objproducto.EliminarAnimal();
                MessageBox.Show("Se elimino satisfactoriamente");
                ListarAnimales();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAnimales.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                CmbPesoyMedida.Text = dataGridViewAnimales.CurrentRow.Cells["PESO_Y_MEDIDA"].Value.ToString();
                CmbDieta.Text = dataGridViewAnimales.CurrentRow.Cells["DIETA"].Value.ToString();
                CmbAlimento.Text = dataGridViewAnimales.CurrentRow.Cells["ALIMENTO"].Value.ToString();
                txtAnimal.Text = dataGridViewAnimales.CurrentRow.Cells["ANIMAL"].Value.ToString();
                idAnimal = dataGridViewAnimales.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CmbDieta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CmbPesoyMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewAnimales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaVence_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaIngreso_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CmbAlimento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
