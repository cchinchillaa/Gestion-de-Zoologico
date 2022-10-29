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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            PRODUCTOS f1 = new PRODUCTOS(); // Instantiate a Form3 object.
            f1.Show(); // Show Form3 and
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            LIMPIEZA f2 = new LIMPIEZA(); // Instantiate a Form3 object.
            f2.Show(); // Show Form3 and
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLINICA f3 = new CLINICA(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ANIMALES f3 = new ANIMALES(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MENU_ALIMENTACION f3 = new MENU_ALIMENTACION(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ENTRADAS f3 = new ENTRADAS(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Hide();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
