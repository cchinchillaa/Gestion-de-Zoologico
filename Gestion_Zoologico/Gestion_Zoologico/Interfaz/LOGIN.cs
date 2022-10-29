using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Zoologico.Interfaz
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private Gestion_Zoologico.Clases.ConexionBD Conexion = new Gestion_Zoologico.Clases.ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private string Emp_puesto;

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string Emp_user = txtuser.Text;
            string Emp_pass = txtpass.Text;
           
            try
            {
                Comando.Connection = Conexion.AbrirConexion();
                Comando.CommandText = "[verificar_login]";
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("@User", Emp_user);
                Comando.Parameters.AddWithValue("@Pass", Emp_pass);
                SqlDataReader rdr2 = Comando.ExecuteReader();
                while (rdr2.Read())
                {
                    Emp_puesto = rdr2["AREA"].ToString();
                   
                }
                Comando.Connection = Conexion.CerrarConexion();
                //MessageBox.Show("satisfecho");

                if (Emp_puesto.Contains("ADMINISTRACION"))
                {
                    new Interfaz.Inicio().Show();
                    this.Hide();
                }

                if (Emp_puesto.Contains("ALIMENTACION"))
                {
                    new MENU_ALIMENTACION().Show();
                    this.Hide();
                }
                if (Emp_puesto.Contains("CLINICA"))
                {
                    new CLINICA().Show();
                    this.Hide();
                }
                if (Emp_puesto.Contains("LIMPIEZA"))
                {
                    new LIMPIEZA().Show();
                    this.Hide();
                }
                if (Emp_puesto.Contains("ENTRADA"))
                {
                    new ENTRADAS().Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                Comando.Connection = Conexion.CerrarConexion();
                MessageBox.Show(ex.Message);
                txtpass.Text = "";
                txtuser.Text = "";
                txtuser.Focus();
            }
        }

        private void ver_Click(object sender, EventArgs e)
        {
            if (txtpass.UseSystemPasswordChar == true)
            {
                txtpass.UseSystemPasswordChar = false;
                ver.Visible = false;
                dejardever.Visible = true;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
                dejardever.Visible = false;
                ver.Visible = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
