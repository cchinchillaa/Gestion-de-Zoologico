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
    public partial class LIMPIEZA : Form
    {

        //ClsEmpleados objProd = new ClsEmpleados();
        public LIMPIEZA()
        {
            InitializeComponent();
            ListarEmpleadosL();
            FListarLugarArea();
            FListarHora();
        }

        string Operacion = "Insertar";
        string idEmpleado;

        private void ListarEmpleadosL()
        {
            Clases.ClsEmpleados objprod = new ClsEmpleados();
            dataGridViewLimpieza.DataSource = objprod.ListarLimpieza();
        }


        private void FListarLugarArea()
        {
            ClsEmpleados objProd = new ClsEmpleados();
            CmbLugarAreaL.DataSource = objProd.ListarLugarArea();
            CmbLugarAreaL.DisplayMember = "LUGAR_AREA";
            CmbLugarAreaL.ValueMember = "IDLUGAR_AREA";
        }
        private void FListarHora()
        {
            ClsEmpleados objProd = new ClsEmpleados();
            comboHoraL.DataSource = objProd.ListarHora();
            comboHoraL.DisplayMember = "HORA";
            comboHoraL.ValueMember = "IDHORA";
        }


        private void LIMPIEZA_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEmpleados objproducto = new ClsEmpleados();
              if (Operacion == "Editar")
            {
               
                objproducto._IdLugarArea = Convert.ToInt32(CmbLugarAreaL.SelectedValue);
                objproducto._Idhora = Convert.ToInt32(comboHoraL.SelectedValue);
          
                objproducto._Idempleado = Convert.ToInt32(idEmpleado);
                objproducto.EditarEmpleadosLimpieza();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");


            }
            ListarEmpleadosL();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewLimpieza.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                CmbLugarAreaL.Text = dataGridViewLimpieza.CurrentRow.Cells["lUGAR_AREA"].Value.ToString();
                comboHoraL.Text = dataGridViewLimpieza.CurrentRow.Cells["HORA"].Value.ToString();
                idEmpleado = dataGridViewLimpieza.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe seleccionar una fila");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridViewLimpieza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
