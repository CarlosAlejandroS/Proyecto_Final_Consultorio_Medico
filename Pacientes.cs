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
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
        }

        private string operation = string.Empty;
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            operation = "Nuevo";
            listapacientes();
            habilitarcontroles();
            limpiar();
        }

        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            operation = "Modificar";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Txt_Id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                Txt_Nombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                Txt_Direccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
                Txt_FechaNac.Text = dataGridView1.CurrentRow.Cells["FECHA_NACIMIENTO"].Value.ToString();
                Cmb_Estadocivil.Text = dataGridView1.CurrentRow.Cells["ESTADOCIVIL"].Value.ToString();
                Cmb_Sexo.Text = dataGridView1.CurrentRow.Cells["SEXO"].Value.ToString();
                Txt_Ocupacion.Text = dataGridView1.CurrentRow.Cells["OCUPACION"].Value.ToString();
                Txt_Telefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
                Txt_Tratamiento.Text = dataGridView1.CurrentRow.Cells["TRATAMIENTO"].Value.ToString();

                habilitarcontroles();
                Btn_Nuevo.Enabled = false;
                Btn_Modificar.Enabled = false;
                Btn_Guardar.Enabled = true;
                button2.Enabled = true;
                Btn_Eliminar.Enabled = false;

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para modificar");
            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Nombre.Text))
            {
                errorProvider1.SetError(Txt_Nombre, "Ingrese el nombre");
                Txt_Nombre.Focus();
                return;
            }
            errorProvider1.SetError(Txt_Nombre, "");

            if (string.IsNullOrEmpty(Txt_Direccion.Text))
            {
                errorProvider1.SetError(Txt_Direccion, "Ingrese la dirección");
                Txt_Direccion.Focus();
                return;
            }
            errorProvider1.SetError(Txt_Direccion, "");

            if (string.IsNullOrEmpty(Txt_FechaNac.Text))
            {
                errorProvider1.SetError(Txt_FechaNac, "Ingrese la fecha de nacimiento");
                Txt_FechaNac.Focus();
                return;
            }
            errorProvider1.SetError(Txt_FechaNac, "");

            if (string.IsNullOrEmpty(Cmb_Estadocivil.Text))
            {
                errorProvider1.SetError(Cmb_Estadocivil, "Ingrese el estado civil");
                Cmb_Estadocivil.Focus();
                return;
            }
            errorProvider1.SetError(Cmb_Estadocivil, "");

            if (string.IsNullOrEmpty(Cmb_Sexo.Text))
            {
                errorProvider1.SetError(Cmb_Sexo, "Ingrese el sexo");
                Cmb_Sexo.Focus();
                return;
            }
            errorProvider1.SetError(Cmb_Sexo, "");

            if (string.IsNullOrEmpty(Txt_Ocupacion.Text))
            {
                errorProvider1.SetError(Txt_Ocupacion, "Ingrese el nombre");
                Txt_Ocupacion.Focus();
                return;
            }
            errorProvider1.SetError(Txt_Ocupacion, "");

            if (string.IsNullOrEmpty(Txt_Telefono.Text))
            {
                errorProvider1.SetError(Txt_Telefono, "Ingrese el nombre");
                Txt_Telefono.Focus();
                return;
            }
            errorProvider1.SetError(Txt_Telefono, "");

            if (string.IsNullOrEmpty(Txt_Tratamiento.Text))
            {
                errorProvider1.SetError(Txt_Tratamiento, "Ingrese el nombre");
                Txt_Tratamiento.Focus();
                return;
            }
            errorProvider1.SetError(Txt_Tratamiento, "");

            if (string.IsNullOrEmpty(Txt_Id.Text))
            {
                errorProvider1.SetError(Txt_Id, "Ingrese el nombre");
                Txt_Id.Focus();
                return;
            }
            errorProvider1.SetError(Txt_Id, "");

            Base_de_datos bd = new Base_de_datos();
            if (operation == "Nuevo")
            {
                bd.Insertarpaciente(Txt_Id.Text, Txt_Nombre.Text, Txt_Direccion.Text, Txt_FechaNac.Text, Cmb_Estadocivil.Text, Cmb_Sexo.Text, Txt_Ocupacion.Text, Txt_Telefono.Text, Txt_Tratamiento.Text);
                listapacientes();
                inhabilitar();
                limpiar();
                Btn_Modificar.Enabled = true;
                Btn_Nuevo.Enabled = true;
                Btn_Eliminar.Enabled = true;

            }
            else if (operation == "Modificar")
            {
                bool modifico = bd.Modificar(Txt_Id.Text, Txt_Nombre.Text, Txt_Direccion.Text, Txt_FechaNac.Text, Cmb_Estadocivil.Text, Cmb_Sexo.Text, Txt_Ocupacion.Text, Txt_Telefono.Text, Txt_Tratamiento.Text);
                listapacientes();
                limpiar();
                inhabilitar();
                Btn_Nuevo.Enabled = true;
                Btn_Eliminar.Enabled = false;
                Btn_Modificar.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            inhabilitar();

            Btn_Modificar.Enabled = true;
            Btn_Nuevo.Enabled = true;
            Btn_Guardar.Enabled = false;
            Btn_Eliminar.Enabled = true;
        }

        private void limpiar()
        {
            Txt_Id.Text = "";
            Txt_Nombre.Text = "";
            Txt_Direccion.Text = "";
            Txt_FechaNac.Text = "";
            Txt_Ocupacion.Text = "";
            Txt_Telefono.Text = "";
            Txt_Tratamiento.Text = "";
            Cmb_Estadocivil.Text = "";
            Cmb_Sexo.Text = "";
        }

        private void inhabilitar()
        {
            Txt_Id.Enabled = false;
            Txt_Nombre.Enabled = false;
            Txt_Direccion.Enabled = false;
            Txt_FechaNac.Enabled = false;
            Txt_Ocupacion.Enabled = false;
            Txt_Telefono.Enabled = false;
            Txt_Tratamiento.Enabled = false;
            Cmb_Estadocivil.Enabled = false;
            Cmb_Sexo.Enabled = false;

            Btn_Guardar.Enabled = false;
            button2.Enabled = false;
        }

        private void habilitarcontroles()
        {
            Txt_Id.Enabled = true;
            Txt_Nombre.Enabled = true;
            Txt_Direccion.Enabled = true;
            Txt_FechaNac.Enabled = true;
            Txt_Ocupacion.Enabled = true;
            Txt_Telefono.Enabled = true;
            Txt_Tratamiento.Enabled = true;
            Cmb_Estadocivil.Enabled = true;
            Cmb_Sexo.Enabled = true;

        }

        private void listapacientes()
        {
            Base_de_datos bd = new Base_de_datos();
            dataGridView1.DataSource = bd.CargarCategorías();
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            Base_de_datos bd = new Base_de_datos();
            listapacientes();
        }

        private void Btn_Nuevo_Click_1(object sender, EventArgs e)
        {
            operation = "Nuevo";
            listapacientes();
            habilitarcontroles();
            limpiar();

            Btn_Guardar.Enabled = true;
            button2.Enabled = true;
            Btn_Eliminar.Enabled = false;
            Btn_Modificar.Enabled = false;

        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            operation = "Eliminar";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Txt_Id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                Txt_Nombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                Txt_Direccion.Text = dataGridView1.CurrentRow.Cells["DIRECCION"].Value.ToString();
                Txt_FechaNac.Text = dataGridView1.CurrentRow.Cells["FECHA_NACIMIENTO"].Value.ToString();
                Cmb_Estadocivil.Text = dataGridView1.CurrentRow.Cells["ESTADOCIVIL"].Value.ToString();
                Cmb_Sexo.Text = dataGridView1.CurrentRow.Cells["SEXO"].Value.ToString();
                Txt_Ocupacion.Text = dataGridView1.CurrentRow.Cells["OCUPACION"].Value.ToString();
                Txt_Telefono.Text = dataGridView1.CurrentRow.Cells["TELEFONO"].Value.ToString();
                Txt_Tratamiento.Text = dataGridView1.CurrentRow.Cells["TRATAMIENTO"].Value.ToString();

                inhabilitar();
                Btn_Nuevo.Enabled = true;
                Btn_Modificar.Enabled = true;
                Btn_Guardar.Enabled = false;
                button2.Enabled = false;

                Base_de_datos bd = new Base_de_datos();
                if (operation == "Eliminar")
                {
                    DialogResult r = MessageBox.Show("Está Seguro que desea eliminar la fila?", "Confirmar", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        bd.Eliminar(Txt_Id.Text, Txt_Nombre.Text, Txt_Direccion.Text, Txt_FechaNac.Text, Cmb_Estadocivil.Text, Cmb_Sexo.Text, Txt_Ocupacion.Text, Txt_Telefono.Text, Txt_Tratamiento.Text);
                    }
                }
                listapacientes();
                limpiar();

            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar");
            }
           

        }
    }
}
