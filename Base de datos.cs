using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Proyecto_Consulturio_Médico
{
    public class Base_de_datos
    {
        readonly string cadena = "Data Source=DESKTOP-M8C5ACA\\SQLEXPRESS01;Initial Catalog=PROYECTO;Integrated Security=True";
        //conexion usuario
        public bool ValidarUsuario(string codigo, string contraseña)
        {
            bool Usuariovalido = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT 1 FROM USUARIOS WHERE CODIGO = @Codigo AND CONTRASEÑA = @Contraseña; ");

                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 30).Value = codigo;
                        comando.Parameters.Add("@Contraseña", SqlDbType.NVarChar, 30).Value = contraseña;

                        Usuariovalido = Convert.ToBoolean(comando.ExecuteScalar());

                    }
                }
            }
            catch (Exception)
            {

               
            }
            return Usuariovalido;
        }
        //conexion paciente
        public bool Insertarpaciente(string id, string nombre, string direccion, string fechanac, string estadocivil, string sexo, string ocupacion, string telefono, string tratamiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO PACIENTE ");
                sql.Append(" VALUES (@Id, @Nombre, @Direccion, @Fecha_nacimiento, @Estadocivil, @Sexo, @Ocupacion, @Telefono, @Tratamiento); ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Fecha_nacimiento", SqlDbType.NVarChar, 30).Value = fechanac;
                        comando.Parameters.Add("@Estadocivil", SqlDbType.NVarChar, 30).Value = estadocivil;
                        comando.Parameters.Add("@Sexo", SqlDbType.NVarChar, 30).Value = sexo;
                        comando.Parameters.Add("@Ocupacion", SqlDbType.NVarChar, 30).Value = ocupacion;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 30).Value = tratamiento;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable CargarCategorías()
        {

            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT P.ID, P.NOMBRE, P.DIRECCION, FECHA_NACIMIENTO, P.ESTADOCIVIL, P.SEXO, P.OCUPACION, P.TELEFONO,P.TRATAMIENTO ");
                sql.Append(" FROM PACIENTE P ");
                //sql.Append(" INNER JOIN CATEGORIA C ON C.ID = P.IDCATEGORIA ");

                using (SqlConnection _conecxion = new SqlConnection(cadena))
                {
                    _conecxion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conecxion))
                    {
                        comando.CommandType = CommandType.Text;
                        SqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {

            }
            return dt;
        }
        public bool Modificar(string id, string nombre, string direccion, string fechanac, string estadocivil, string sexo, string ocupacion, string telefono, string tratamiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE PACIENTE ");
                sql.Append(" SET NOMBRE = @Nombre, DIRECCION = @Direccion, FECHA_NACIMIENTO = @Fecha_nacimiento, ESTADOCIVIL = @Estadocivil, SEXO = @Sexo, OCUPACION = @Ocupacion, TELEFONO = @Telefono, TRATAMIENTO = @Tratamiento");
                sql.Append(" WHERE ID= @Id ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Fecha_nacimiento", SqlDbType.NVarChar, 30).Value = fechanac;
                        comando.Parameters.Add("@Estadocivil", SqlDbType.NVarChar, 30).Value = estadocivil;
                        comando.Parameters.Add("@Sexo", SqlDbType.NVarChar, 30).Value = sexo;
                        comando.Parameters.Add("@Ocupacion", SqlDbType.NVarChar, 30).Value = ocupacion;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 30).Value = tratamiento;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Eliminar(string id, string nombre, string direccion, string fechanac, string estadocivil, string sexo, string ocupacion, string telefono, string tratamiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM PACIENTE ");
                sql.Append(" WHERE ID= @Id ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Fecha_nacimiento", SqlDbType.NVarChar, 30).Value = fechanac;
                        comando.Parameters.Add("@Estadocivil", SqlDbType.NVarChar, 30).Value = estadocivil;
                        comando.Parameters.Add("@Sexo", SqlDbType.NVarChar, 30).Value = sexo;
                        comando.Parameters.Add("@Ocupacion", SqlDbType.NVarChar, 30).Value = ocupacion;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 30).Value = tratamiento;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        //conexion medico 
        public bool Insertarmedico(string id,string nombre, string email, string direccion, string especialidad,string telefono)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO MEDICO ");
                sql.Append(" VALUES (@Id, @Nombre, @Email, @Direccion, @Especialidad, @Telefono); ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Email", SqlDbType.NVarChar, 30).Value = email;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 30).Value = especialidad;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable Cargarmedico()
        {

            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM MEDICO ");

                using (SqlConnection _conecxion = new SqlConnection(cadena))
                {
                    _conecxion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conecxion))
                    {
                        comando.CommandType = CommandType.Text;
                        SqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {

            }
            return dt;
        }
        public bool Modificarmedico(string id, string nombre, string email, string direccion, string especialidad, string telefono)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE MEDICO ");
                sql.Append(" SET NOMBRE = @Nombre, EMAIL = @Email, DIRECCION = @Direccion, ESPECIALIDAD = @Especialidad, TELEFONO = @Telefono ");
                sql.Append(" WHERE ID= @Id ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Email", SqlDbType.NVarChar, 30).Value = email;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 30).Value = especialidad;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Eliminarmedico(string id, string nombre, string email, string direccion, string especialidad, string telefono)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM MEDICO ");
                sql.Append(" WHERE ID= @Id ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Email", SqlDbType.NVarChar, 30).Value = email;
                        comando.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 30).Value = especialidad;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        //conexion cita
        public bool Insertarcita(string id, string nombre, string direccion, string telefono, string tratamiento, string fechacita, string fechaconsulta, string medico)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CITAS ");
                sql.Append(" VALUES (@Id, @Nombre, @Direccion, @Telefono, @Tratamiento, @Fecha_cita, @Fechaconsulta, @Medico); ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 30).Value = tratamiento;
                        comando.Parameters.Add("@Fecha_cita", SqlDbType.NVarChar, 30).Value = fechacita;
                        comando.Parameters.Add("@Fechaconsulta", SqlDbType.NVarChar, 30).Value = fechaconsulta;
                        comando.Parameters.Add("@Medico", SqlDbType.NVarChar, 30).Value = medico;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        public DataTable CargarCitas()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM CITAS");

                using (SqlConnection _conecxion = new SqlConnection(cadena))
                {
                    _conecxion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conecxion))
                    {
                        comando.CommandType = CommandType.Text;
                        SqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception)
            {

            }
            return dt;
        }
        public bool Modificarcitas(string id, string nombre, string direccion, string telefono, string tratamiento, string fechacita, string fechaconsulta, string medico)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE CITAS ");
                sql.Append(" SET NOMBRE = @Nombre, DIRECCION = @Direccion, TELEFONO = @Telefono, TRATAMIENTO = @Tratamiento, FECHACITA = @Fechacita, FECHACONSUTA = @Fechaconsulta, MEDICO = @Medico");
                sql.Append(" WHERE ID= @Id ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 30).Value = tratamiento;
                        comando.Parameters.Add("@Fecha_cita", SqlDbType.NVarChar, 30).Value = fechacita;    
                        comando.Parameters.Add("@Fechaconsulta", SqlDbType.NVarChar, 30).Value = fechaconsulta;
                        comando.Parameters.Add("@Medico", SqlDbType.NVarChar, 30).Value = medico;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Eliminarcita(string id, string nombre, string direccion, string telefono, string tratamiento, string fechacita, string fechaconsulta, string medico)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM CITAS ");
                sql.Append(" WHERE ID= @Id ");
                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Id", SqlDbType.NVarChar, 30).Value = id;
                        comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 30).Value = nombre;
                        comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 30).Value = direccion;
                        comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 30).Value = telefono;
                        comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 30).Value = tratamiento;
                        comando.Parameters.Add("@Fecha_cita", SqlDbType.NVarChar, 30).Value = fechacita;
                        comando.Parameters.Add("@Fechaconsulta", SqlDbType.NVarChar, 30).Value = fechaconsulta;
                        comando.Parameters.Add("@Medico", SqlDbType.NVarChar, 30).Value = medico;
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
