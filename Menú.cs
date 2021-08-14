using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Proyecto_Consulturio_Médico
{
    public partial class Menú : Form
    {
        public Menú()
        {
            InitializeComponent();
        }

        private void Menú_Load(object sender, EventArgs e)
        {
            
        }
                
        private void btnconsultas_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Citas_Click(object sender, EventArgs e)
        {
            CITAS cic = new CITAS();
            cic.Show();
        }

        private void Btn_Medicos_Click(object sender, EventArgs e)
        {
            Medico med = new Medico();
            med.Show();
        }

        private void Btn_Pacientes_Click(object sender, EventArgs e)
        {
            Pacientes pac = new Pacientes();
            pac.Show();
        }
    }
}
