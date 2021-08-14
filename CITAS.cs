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
    public partial class CITAS : Form
    {
        public CITAS()
        {
            InitializeComponent();
        }
        private string operation = string.Empty;
        private void listacita()
        {
            Base_de_datos bd = new Base_de_datos();
            CitadataGridView.DataSource = bd.CargarCitas();
        }
        private void limpiar()
        {
            idtextBox.Text = "";
            NombretextBox.Text = "";
            DirecciontextBox.Text = "";
            medicotextBox1.Text = "";
            tratamietotextBox.Text = "";
            CitatextBox3.Text = "";
            consulatextBox2.Text = "";
            telefonotextBox.Text = "";

        }
        private void inhabilitar()
        {
            idtextBox.Enabled = false;
            NombretextBox.Enabled = false;
            DirecciontextBox.Enabled = false;
            medicotextBox1.Enabled = false;
            tratamietotextBox.Enabled = false;
            CitatextBox3.Enabled = false;
            consulatextBox2.Enabled = false;
            telefonotextBox.Enabled = false;

           
        }
        private void habilitarcontroles()
        {
            idtextBox.Enabled = true;
            NombretextBox.Enabled = true;
            DirecciontextBox.Enabled = true;
            medicotextBox1.Enabled = true;
            tratamietotextBox.Enabled = true;
            CitatextBox3.Enabled = true;
            consulatextBox2.Enabled = true;
            telefonotextBox.Enabled = true;
            Eliminarbutton.Enabled = true;

        }
        private void Registrarbutton_Click(object sender, EventArgs e)
        {
            operation = "Nuevo";
            listacita();
            habilitarcontroles();
            limpiar();
            guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Eliminarbutton.Enabled = false;
        }
        private void CITAS_Load(object sender, EventArgs e)
        {
            Base_de_datos bd = new Base_de_datos();
            listacita();
        }
        private void guardarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "Ingrese el nombre");
                NombretextBox.Focus();
                return;
            }
            errorProvider1.SetError(NombretextBox, "");

            if (string.IsNullOrEmpty(DirecciontextBox.Text))
            {
                errorProvider1.SetError(DirecciontextBox, "Ingrese la dirección");
                DirecciontextBox.Focus();
                return;
            }
            errorProvider1.SetError(DirecciontextBox, "");

            if (string.IsNullOrEmpty(medicotextBox1.Text))
            {
                errorProvider1.SetError(medicotextBox1, "Ingrese el nombre del medico");
                medicotextBox1.Focus();
                return;
            }
            errorProvider1.SetError(medicotextBox1, "");

            if (string.IsNullOrEmpty(tratamietotextBox.Text))
            {
                errorProvider1.SetError(tratamietotextBox, "Ingrese el tipo de tratamiento");
                tratamietotextBox.Focus();
                return;
            }
            errorProvider1.SetError(tratamietotextBox, "");

            if (string.IsNullOrEmpty(CitatextBox3.Text))
            {
                errorProvider1.SetError(CitatextBox3, "Ingrese el telefono");
                CitatextBox3.Focus();
                return;
            }
            errorProvider1.SetError(CitatextBox3, "");

            Base_de_datos bd = new Base_de_datos();
            if (operation == "Nuevo")
            {
                bd.Insertarcita(idtextBox.Text, NombretextBox.Text, DirecciontextBox.Text, telefonotextBox.Text, tratamietotextBox.Text, CitatextBox3.Text, consulatextBox2.Text, medicotextBox1.Text);
                listacita();
                inhabilitar();
                limpiar();
                Registrarbutton.Enabled = true;
                Modificarbutton.Enabled = true;
                Eliminarbutton.Enabled = true;

            }
            else if (operation == "Modificar")
            {
                bool modifico = bd.Modificarcitas(idtextBox.Text, NombretextBox.Text, DirecciontextBox.Text, telefonotextBox.Text, tratamietotextBox.Text, CitatextBox3.Text, consulatextBox2.Text, medicotextBox1.Text);
                listacita();
                limpiar();
                inhabilitar();
                Registrarbutton.Enabled = true;
                Eliminarbutton.Enabled = false;
                Modificarbutton.Enabled = true;
            }
        }
        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            operation = "Modificar";
            if (CitadataGridView.SelectedRows.Count > 0)
            {
                idtextBox.Text = CitadataGridView.CurrentRow.Cells["ID"].Value.ToString();
                NombretextBox.Text = CitadataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                DirecciontextBox.Text = CitadataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
               telefonotextBox.Text = CitadataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();
               tratamietotextBox.Text = CitadataGridView.CurrentRow.Cells["TRATAMIENTO"].Value.ToString();
                CitatextBox3.Text = CitadataGridView.CurrentRow.Cells["FECHACITA"].Value.ToString();
              consulatextBox2.Text = CitadataGridView.CurrentRow.Cells["FECHACONSUTA"].Value.ToString();
             medicotextBox1.Text = CitadataGridView.CurrentRow.Cells["MEDICO"].Value.ToString();

                habilitarcontroles();
                Registrarbutton.Enabled = false;
                Modificarbutton.Enabled = false;
                guardarbutton.Enabled = true;
                Cancelarbutton.Enabled = true;
                Eliminarbutton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para modificar");
            }
        }
        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            operation = "Eliminar";
            if (CitadataGridView.SelectedRows.Count > 0)
            {
                idtextBox.Text = CitadataGridView.CurrentRow.Cells["ID"].Value.ToString();
                NombretextBox.Text = CitadataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                DirecciontextBox.Text = CitadataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
                telefonotextBox.Text = CitadataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();
                tratamietotextBox.Text = CitadataGridView.CurrentRow.Cells["TRATAMIENTO"].Value.ToString();
                CitatextBox3.Text = CitadataGridView.CurrentRow.Cells["FECHACITA"].Value.ToString();
                consulatextBox2.Text = CitadataGridView.CurrentRow.Cells["FECHACONSUTA"].Value.ToString();
                medicotextBox1.Text = CitadataGridView.CurrentRow.Cells["MEDICO"].Value.ToString();

                inhabilitar();
                Registrarbutton.Enabled = true;
                Modificarbutton.Enabled = true;
                guardarbutton.Enabled = false;
                Eliminarbutton.Enabled = true;

                Base_de_datos bd = new Base_de_datos();
                if (operation == "Eliminar")
                {
                    DialogResult r = MessageBox.Show("Está Seguro que desea eliminar la fila?", "Confirmar", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        bd.Eliminarcita(idtextBox.Text, NombretextBox.Text, DirecciontextBox.Text, telefonotextBox.Text, tratamietotextBox.Text, CitatextBox3.Text, consulatextBox2.Text, medicotextBox1.Text);
                    }
                }
                listacita();
                limpiar();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar");
            }
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            limpiar();
            inhabilitar();

            Modificarbutton.Enabled = true;
            Registrarbutton.Enabled = true;
            guardarbutton.Enabled = false;
            Eliminarbutton.Enabled = true;
        }
      

    }
}
