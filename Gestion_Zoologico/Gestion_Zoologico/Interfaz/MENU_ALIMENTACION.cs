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
    public partial class MENU_ALIMENTACION : Form
    {
        public MENU_ALIMENTACION()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ALIMENTOS f3 = new ALIMENTOS(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ANIMALES f3 = new ANIMALES(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
        }

        private void MENU_ALIMENTACION_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
