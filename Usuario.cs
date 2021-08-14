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

namespace Login_Proyecto_Consulturio_Médico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos de los usuarios \n\n Usuario: NCASCO \n Contraseña: 1234");
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Ingrese el usuario");
                textBox1.Focus();
                return;
            }
            errorProvider1.SetError(textBox1, "");
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Ingrese la contraseña");
                textBox2.Focus();
                return;
            }
            errorProvider1.SetError(textBox2, "");

            Base_de_datos _base = new Base_de_datos();

            if (_base.ValidarUsuario(textBox1.Text, textBox2.Text))
            {
                Menú menu = new Menú();
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña invalidos\n\n Revise la opcion ¿Olvidó sus Datos?", "ERROR  ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
