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
    public partial class CLINICA : Form
    {
        public CLINICA()
        {
            InitializeComponent();
            ListarMedicamentos();
            FListarTipoAnimal();
            FListarClasificacionM();
            FListarAnimalesAplicables();
        }

        string Operacion = "Insertar";
        string idMedicamento;


        private void FListarTipoAnimal()
        {
            Clases.ClsMedicamentos objProd = new ClsMedicamentos();
            CmbTipo.DataSource = objProd.ListarTipoMedicamentos();
            CmbTipo.DisplayMember = "TIPO_MEDICAMENTO";
            CmbTipo.ValueMember = "IDTIPO_MEDICAMENTO";
        }
        private void FListarClasificacionM()
        {
            ClsMedicamentos objProd = new ClsMedicamentos();
            CmbClasificacionM.DataSource = objProd.ListarClasificacionMedicamentos();
            CmbClasificacionM.DisplayMember = "CLASIFICACION_MEDICAMENTO";
            CmbClasificacionM.ValueMember = "IDCLASIFICACION_MEDICAMENTO";
        }
        private void FListarAnimalesAplicables()
        {
            ClsMedicamentos objProd = new ClsMedicamentos();
            CmbClasificacionAnimales.DataSource = objProd.ListarAnimalesAplicables();
            CmbClasificacionAnimales.DisplayMember = "ANIMALES_APLICABLE";
            CmbClasificacionAnimales.ValueMember = "IDANIMALES_APLICABLE";
        }

        private void ListarMedicamentos()
        {
            ClsMedicamentos objProd = new ClsMedicamentos();
            dataGridViewClinica.DataSource = objProd.ListarMedicamentos();
        }


        ClsMedicamentos objproducto = new ClsMedicamentos();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime cnDateIngreso = DateTime.Parse(txtFechaIngreso.Text);
            DateTime cnDateVencimiento = DateTime.Parse(txtFechaVence.Text);

            if (Operacion == "Insertar")
            {
                objproducto._Idanimales_aplicables = Convert.ToInt32(CmbClasificacionAnimales.SelectedValue);
                objproducto._Idclasificacion_medicamento = Convert.ToInt32(CmbClasificacionM.SelectedValue);
                objproducto._Id_tipomedicamento = Convert.ToInt32(CmbTipo.SelectedValue);
                objproducto._Medicamento = txtMedicamento.Text;
                objproducto._Fecha_ingreso = txtFechaIngreso.Text;
                objproducto._Feha_vencimiento = txtFechaVence.Text;
                objproducto.InsertarMedicamentos();

                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto._Idanimales_aplicables = Convert.ToInt32(CmbClasificacionAnimales.SelectedValue);
                objproducto._Idclasificacion_medicamento = Convert.ToInt32(CmbClasificacionM.SelectedValue);
                objproducto._Id_tipomedicamento = Convert.ToInt32(CmbTipo.SelectedValue);
                objproducto._Medicamento = txtMedicamento.Text;
                objproducto._Fecha_ingreso = txtFechaIngreso.Text;
                objproducto._Feha_vencimiento = txtFechaVence.Text;
                objproducto._Idmedicamento = Convert.ToInt32(idMedicamento);
                objproducto.EditarMedicamentos();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");


            }
            ListarMedicamentos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClinica.SelectedRows.Count > 0)
            {
                objproducto._Idmedicamento = Convert.ToInt32(dataGridViewClinica.CurrentRow.Cells[0].Value);
                objproducto.EliminarMedicamento();
                MessageBox.Show("Se elimino satisfactoriamente");
                ListarMedicamentos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClinica.SelectedRows.Count > 0)
            {
                Operacion = "Editar";

                CmbClasificacionAnimales.Text = dataGridViewClinica.CurrentRow.Cells["ANIMALES_APLICABLE"].Value.ToString();
                CmbClasificacionM.Text = dataGridViewClinica.CurrentRow.Cells["CLASIFICACION_MEDICAMENTO"].Value.ToString();
                CmbTipo.Text = dataGridViewClinica.CurrentRow.Cells["TIPO_MEDICAMENTO"].Value.ToString();
                txtMedicamento.Text = dataGridViewClinica.CurrentRow.Cells["MEDICAMENTO"].Value.ToString();
                txtFechaIngreso.Text = dataGridViewClinica.CurrentRow.Cells["FECHA_INGRESO"].Value.ToString();
                txtFechaVence.Text = dataGridViewClinica.CurrentRow.Cells["FECHA_VENCIMIENTO"].Value.ToString();
                idMedicamento = dataGridViewClinica.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();


        }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void CLINICA_Load(object sender, EventArgs e)
        {}

        private void label2_Click(object sender, EventArgs e)
        { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewClinica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
