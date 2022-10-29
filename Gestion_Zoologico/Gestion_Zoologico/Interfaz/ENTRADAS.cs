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
    public partial class ENTRADAS : Form
    {
        public ENTRADAS()
        {
            InitializeComponent();
            FlistarEntradas();
            FListarDias();
            FListarTipoVisita();
            //txtPago_sin_Des.Enabled = false;
            //txtDescuento.Enabled = false;
            //txtTotal.Enabled = false;
            //txtTiket.Enabled = false;
        }

        private void FlistarEntradas()
        {
            ClsEntradas objProd = new ClsEntradas();
            dataGridView1.DataSource = objProd.ListarEntradas();
        }

        string Operacion = "Insertar";

        //private void mostrarPago()
        //{
        //    int valor = Convert.ToInt32(CmbVisitante.SelectedValue);
        //    txtPago_sin_Des.Text = String.Empty;

        //    if (valor == 1)  { txtPago_sin_Des.Text = "100"; } 
        //    if (valor == 2)  {txtPago_sin_Des.Text = "125";} 
        //    if (valor == 3) { txtPago_sin_Des.Text = "95"; } 
        //    if (valor == 4) { txtPago_sin_Des.Text = "85"; } 
        //}

        //private void realizarDescuento()
        //{
        //    int valor = Convert.ToInt32(CmbDias.SelectedValue);

        //    if (valor ==7 || valor==8) 
        //    {
        //        txtDescuento.Text = "10% del Pago";
        //        double dato= Convert.ToDouble(txtPago_sin_Des.Text);
        //        double porcentaje = dato * 0.1;
        //        dato = dato - porcentaje;
        //        txtTotal.Text = Convert.ToString( "Q "+dato);
        //        string cadena1 = txtNombre.Text;
        //        char c = cadena1[0];
        //        txtTiket.Text = "#" + c + txtFechaIngreso.Text + "-" + txtHoraIngreso.Text;

        //    } // valor del Adolescente


        //    else {
        //        txtDescuento.Text = "5% del Pago";
        //        double dato = Convert.ToDouble(txtPago_sin_Des.Text);
        //        double porcentaje = dato * 0.05;
        //        dato = dato - porcentaje;
        //        txtTotal.Text = Convert.ToString("Q " + dato);
        //        string cadena1 = txtNombre.Text;
        //        char c = cadena1[0];
        //        txtTiket.Text ="#"+ c + txtFechaIngreso.Text+"-"+txtHoraIngreso.Text;
            


        //    } // valor Adulto

        //}

        private void FListarDias()
        {
            ClsEntradas objProd = new ClsEntradas();
            CmbDias.DataSource = objProd.ListarDias();
            CmbDias.DisplayMember = "DIA";
            CmbDias.ValueMember = "IDDIA";

        }
        private void FListarTipoVisita()
        {
            ClsEntradas objProd = new ClsEntradas();
            CmbVisitante.DataSource = objProd.ListarTipoVisita();
            CmbVisitante.DisplayMember = "TIPO_VISITANTE";
            CmbVisitante.ValueMember = "IDTIPO_VISITANTE";

            //mostrarPago();
        }

        ClsEntradas objproducto = new ClsEntradas();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto._Idtipovisitante = Convert.ToInt32(CmbVisitante.SelectedValue);
                objproducto._Iddia = Convert.ToInt32(CmbDias.SelectedValue);
                objproducto._Nombre = txtNombre.Text;
                objproducto._Fecha_ingreso = txtFechaIngreso.Text;
                objproducto._Hora_ingreso = txtHoraIngreso.Text;
                objproducto._Pago = txtPago_sin_Des.Text;
                objproducto._Tiket = txtTiket.Text;
                objproducto.InsertarEntrada();

                MessageBox.Show("Se inserto correctamente");
            }

            FlistarEntradas();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objproducto._Identrada = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                objproducto.EliminarEntrada();
                MessageBox.Show("Se elimino satisfactoriamente");
                FlistarEntradas();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void txtFechaIngreso_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //realizarDescuento();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ENTRADAS_Load(object sender, EventArgs e)
        {

        }

        private void txtPago_sin_Des_TextChanged(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void CmbVisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
