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
    public partial class Medico : Form
    {
        public Medico()
        {
            InitializeComponent();
        }
        private string operation = string.Empty;
        private void listamedico()
        {
            Base_de_datos bd = new Base_de_datos();
            medicosdataGridView.DataSource = bd.Cargarmedico();
        }
        private void limpiar()
        {
            idtextBox.Text = "";
            NombretextBox.Text = "";
            dirreciontextBox.Text = "";
            emailtextBox.Text = "";
            especialidadtextBox.Text = "";
            TelefonotextBox.Text = "";
        }
        private void inhabilitar()
        {
            idtextBox.Enabled = false;
            NombretextBox.Enabled = false;
            dirreciontextBox.Enabled = false;
            emailtextBox.Enabled = false;
            especialidadtextBox.Enabled = false;
            TelefonotextBox.Enabled = false;

            
        }
        private void habilitarcontroles()
        {
            idtextBox.Enabled = true;
            NombretextBox.Enabled = true;
            dirreciontextBox.Enabled = true;
            emailtextBox.Enabled = true;
            especialidadtextBox.Enabled = true;
            TelefonotextBox.Enabled = true;
        }
        private void Registrarbutton_Click(object sender, EventArgs e)
        {
            operation = "Nuevo";
            listamedico();
            habilitarcontroles();
            limpiar();
            Cancelarbutton.Enabled = true;
            Eliminarbutton.Enabled = false;


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

            if (string.IsNullOrEmpty(dirreciontextBox.Text))
            {
                errorProvider1.SetError(dirreciontextBox, "Ingrese la dirección");
                dirreciontextBox.Focus();
                return;
            }
            errorProvider1.SetError(dirreciontextBox, "");

            if (string.IsNullOrEmpty(emailtextBox.Text))
            {
                errorProvider1.SetError(emailtextBox, "Ingrese el email");
                emailtextBox.Focus();
                return;
            }
            errorProvider1.SetError(emailtextBox, "");

            if (string.IsNullOrEmpty(especialidadtextBox.Text))
            {
                errorProvider1.SetError(especialidadtextBox, "Ingrese la especialidad");
                especialidadtextBox.Focus();
                return;
            }
            errorProvider1.SetError(especialidadtextBox, "");

            if (string.IsNullOrEmpty(TelefonotextBox.Text))
            {
                errorProvider1.SetError(TelefonotextBox, "Ingrese el telefono");
                TelefonotextBox.Focus();
                return;
            }
            errorProvider1.SetError(TelefonotextBox, "");

            Base_de_datos bd = new Base_de_datos();
            if (operation == "Nuevo")
            {
                bd.Insertarmedico(idtextBox.Text,NombretextBox.Text, emailtextBox.Text, dirreciontextBox.Text, especialidadtextBox.Text,TelefonotextBox.Text);
                listamedico();
                inhabilitar();
                limpiar();
                Modificarbutton.Enabled = true;
                Registrarbutton.Enabled = true;
                Eliminarbutton.Enabled = true;

            }
            else if (operation == "Modificar")
            {
                bool modifico = bd.Modificarmedico(idtextBox.Text, NombretextBox.Text, emailtextBox.Text, dirreciontextBox.Text, especialidadtextBox.Text, TelefonotextBox.Text);
                listamedico(); 
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
            if (medicosdataGridView.SelectedRows.Count > 0)
            {
                idtextBox.Text = medicosdataGridView.CurrentRow.Cells["ID"].Value.ToString();
                NombretextBox.Text = medicosdataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                emailtextBox.Text = medicosdataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                dirreciontextBox.Text = medicosdataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
                especialidadtextBox.Text = medicosdataGridView.CurrentRow.Cells["ESPECIALIDAD"].Value.ToString();
                TelefonotextBox.Text = medicosdataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();
                

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
            if (medicosdataGridView.SelectedRows.Count > 0)
            {
                idtextBox.Text = medicosdataGridView.CurrentRow.Cells["ID"].Value.ToString();
                NombretextBox.Text = medicosdataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                dirreciontextBox.Text = medicosdataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();
                emailtextBox.Text = medicosdataGridView.CurrentRow.Cells["EMAIL"].Value.ToString();
                especialidadtextBox.Text = medicosdataGridView.CurrentRow.Cells["ESPECIALIDAD"].Value.ToString();
                TelefonotextBox.Text = medicosdataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();

                inhabilitar();
                Registrarbutton.Enabled = true;
                Modificarbutton.Enabled = true;
                guardarbutton.Enabled = false;
                Eliminarbutton.Enabled = false;

                Base_de_datos bd = new Base_de_datos();
                if (operation == "Eliminar")
                {
                    DialogResult r = MessageBox.Show("Está Seguro que desea eliminar la fila?", "Confirmar", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        bd.Eliminarmedico(idtextBox.Text, NombretextBox.Text, dirreciontextBox.Text, emailtextBox.Text, especialidadtextBox.Text, TelefonotextBox.Text);
                    }
                }
                listamedico();
                limpiar();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar");
            }
        }
        private void Medico_Load(object sender, EventArgs e)
        {
            
                Base_de_datos bd = new Base_de_datos();
                listamedico();
        }
        private void Registrarbutton_Click_1(object sender, EventArgs e)
        {
            operation = "Nuevo";
            listamedico();
            habilitarcontroles();
            limpiar();

            guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
            Eliminarbutton.Enabled = false;
            Modificarbutton.Enabled = false;

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