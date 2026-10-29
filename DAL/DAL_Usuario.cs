using Microsoft.Data.SqlClient;
using Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DAL_Usuario
    {
        private readonly string _connectionString = DAL_ConexionDB.ObtenerCadena();
        public DAL_Usuario(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DAL_Usuario()
        {
            
        }

        public bool HayUsuariosRegistrados()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                
                string sql = "SELECT COUNT(*) AS Cantidad FROM Usuario";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable tabla = new DataTable();

                // El adaptador abre y cierra la conexión automáticamente
                adapter.Fill(tabla);

                // Accedemos al valor dentro del DataTable
                int cantidad = Convert.ToInt32(tabla.Rows[0]["Cantidad"]);

                return cantidad > 0;
            }
        }
        public Servicio_Usuario AutenticarUsuario(string login, string hash)
        {
            const string sql ="SELECT Nombre, Apellido, DNI, email, Login, Password, " +
                
                "       Activo, Bloqueo, IdRol " +
                "FROM Usuario " +
                "WHERE Login = @Login " +
                "AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.NVarChar, 100) { Value = login });
                cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 256) { Value = hash });

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
            
                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count != 1)
                    return null;

                DataRow row = ds.Tables["Usuario"].Rows[0];

                return new Servicio_Usuario
                {
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    DNI = row["DNI"].ToString(),
                    email = row["email"].ToString(),
                    Login = row["Login"].ToString(),
                    Password = row["Password"].ToString(),
                    Activo = Convert.ToInt32(row["Activo"]),
                    Bloqueo = Convert.ToInt32(row["Bloqueo"]),
                    IdRol = row.Table.Columns.Contains("IdRol") && row["IdRol"] != DBNull.Value ? row["IdRol"].ToString() : null,
                    
                };
            }
        }

        public int ObtenerIntentos(string login)
        {
            using (SqlConnection conn =
                new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =
                    new SqlDataAdapter("SELECT * FROM Usuario WHERE Login = @Login",conn);
                        
                        

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Login",SqlDbType.NVarChar, 100){
                        Value = login});
                    
  
                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables["Usuario"].Rows[0]["Bloqueo"]);
                        
                        
                }

                return 0;
            }
        }

        public void IncrementarIntentos(string login)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario WHERE Login = @Login",conn);


                adapter.SelectCommand.Parameters.Add( new SqlParameter("@Login", SqlDbType.NVarChar, 100){
                        Value = login});
 
                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count > 0)
                {
                    DataRow fila = ds.Tables["Usuario"].Rows[0];

                    fila["Bloqueo"] =Convert.ToInt32(fila["Bloqueo"]) + 1;
                        

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    adapter.Update(ds, "Usuario");
                }
            }
        }
        public bool CrearUsuario(Servicio_Usuario usuario)
        {
            using (SqlConnection conn =
                new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Usuario",conn);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                DataRow fila = ds.Tables["Usuario"].NewRow();
                   

                fila["Nombre"] = usuario.Nombre;
                fila["Apellido"] = usuario.Apellido;
                fila["DNI"] = usuario.DNI;
                fila["email"] = usuario.email;
                fila["Login"] = usuario.Login;
                fila["Password"] = usuario.Password;
                fila["Activo"] = usuario.Activo;
                fila["Bloqueo"] = usuario.Bloqueo;
                fila["IdRol"] = usuario.IdRol;
                fila["Id_Idioma"] = usuario.Id_Idioma;
                ds.Tables["Usuario"].Rows.Add(fila);

                SqlCommandBuilder builder =new SqlCommandBuilder(adapter);
                    

                adapter.Update(ds, "Usuario");

                return true;
            }
        }
        public void CambiarEstadoUsuario(string login, int activo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario WHERE DNI = @DNI",conn);
                    
                adapter.SelectCommand.Parameters.Add( new SqlParameter("@DNI", login));
                DataSet ds = new DataSet();   
                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count == 0) ;
                    

                DataRow fila = ds.Tables["Usuario"].Rows[0];

                fila["Activo"] = activo;

                SqlCommandBuilder builder =new SqlCommandBuilder(adapter);

                adapter.Update(ds, "Usuario");

            
            }
        }

        public void ModificarUsuario(Servicio_Usuario usuario)
    
        {
            using (SqlConnection conn =new SqlConnection(_connectionString))
                
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario",conn);
   
                DataSet ds =new DataSet();
   
                adapter.Fill(ds, "Usuario");

                DataRow fila =ds.Tables["Usuario"].Select($"DNI = '{usuario.DNI}'")[0];


                fila["Nombre"] =usuario.Nombre;
  
                fila["Apellido"] = usuario.Apellido;

                fila["email"] = usuario.email;

                fila["IdRol"] = usuario.IdRol;

                fila["Login"] = usuario.Login;

                SqlCommandBuilder builder =new SqlCommandBuilder(adapter);
                 
                adapter.Update(ds, "Usuario");

                
            }
        }

        public DataTable ListarUsuariosActivos()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
               
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario WHERE Activo = 1",conn);

                DataTable tabla =new DataTable();

                adapter.Fill(tabla);

                return tabla;
            }
        }


        public bool ExisteUsuario(string login)
        {
            using (SqlConnection conn =
                new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario",  conn);
                               

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                foreach (DataRow fila in ds.Tables["Usuario"].Rows)
                {
                    if (fila["Login"].ToString() == login)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        public List<Servicio_Usuario> ListarUsuarios()
        {
            List<Servicio_Usuario> lista = new List<Servicio_Usuario>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Usuario", conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Servicio_Usuario u = new Servicio_Usuario();

                    u.Nombre = row["Nombre"].ToString();
                    u.Apellido = row["Apellido"].ToString();
                    u.DNI = row["DNI"].ToString();
                    u.email = row["Email"].ToString();
                    u.Login = row["Login"].ToString();
                    u.Password = row["Password"].ToString();

                    u.Activo = Convert.ToInt32(row["Activo"]);
                    u.Bloqueo = Convert.ToInt32(row["Bloqueo"]);

                    u.IdRol = row["IdRol"].ToString();

                    if (row["Id_Idioma"] != DBNull.Value)
                        u.Id_Idioma = row["Id_Idioma"].ToString();

                    lista.Add(u);
                }
            }

            return lista;
        }
        public void ReiniciarIntentos(string login)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario WHERE Login = @Login",conn);
   
                adapter.SelectCommand.Parameters.Add( new SqlParameter("@Login", SqlDbType.NVarChar, 100){
                        Value = login    });

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count > 0)
                {
                    DataRow fila = ds.Tables["Usuario"].Rows[0];

                    fila["Bloqueo"] = 0;

                    SqlCommandBuilder builder =new SqlCommandBuilder(adapter);
                        

                    adapter.Update(ds, "Usuario");
                }
            }
        }

        public Servicio_Usuario ObtenerUsuario(string dni)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =new SqlDataAdapter("SELECT * FROM Usuario WHERE DNI = @DNI",conn);

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@DNI",SqlDbType.NVarChar, 50){Value = dni});

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count == 0) return null;

                DataRow fila = ds.Tables["Usuario"].Rows[0];

                Servicio_Usuario usuario = new Servicio_Usuario();

                usuario.Nombre = fila["Nombre"].ToString();
                 usuario.Apellido = fila["Apellido"].ToString();
                usuario.DNI = fila["DNI"].ToString();
                usuario.email = fila["email"].ToString();
                usuario.Login = fila["Login"].ToString();
                usuario.Password = fila["Password"].ToString();
                usuario.Activo = Convert.ToInt32(fila["Activo"]);
                usuario.Bloqueo = Convert.ToInt32(fila["Bloqueo"]);
                usuario.IdRol = fila["IdRol"].ToString();
                usuario.Id_Idioma =fila["Id_Idioma"] == DBNull.Value? null: fila["Id_Idioma"].ToString();
                return usuario;
            }
        }

        public Servicio_Usuario ObtenerUsuarioPorLogin(string login)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =
                    new SqlDataAdapter("SELECT * FROM Usuario WHERE Login = @Login", conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Login", login);

                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                if (tabla.Rows.Count == 0) return null;

                DataRow row = tabla.Rows[0];

                return new Servicio_Usuario
                {
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    DNI = row["DNI"].ToString(),
                    email = row["email"].ToString(),
                    Login = row["Login"].ToString(),
                    Activo = Convert.ToInt32(row["Activo"]),
                    Bloqueo = Convert.ToInt32(row["Bloqueo"]),
                    IdRol = row["IdRol"].ToString(),
                    Password = row["Password"].ToString(),
                    Id_Idioma = row["Id_Idioma"] == DBNull.Value ? null: row["Id_Idioma"].ToString()
   
                };
            }
        }

        public DataTable ListarLogins()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =
                    new SqlDataAdapter("SELECT DISTINCT Login FROM Usuario", conn);

                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                return tabla;
            }
        }
    

        public bool ActualizarClave(string login, string nuevoHash)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                
                string query = "SELECT * FROM Usuario WHERE Login = @Login";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@Login", login));

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Usuario");

                if (ds.Tables["Usuario"].Rows.Count == 0) return false;

                DataRow fila = ds.Tables["Usuario"].Rows[0];
                fila["Password"] = nuevoHash; 

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.Update(ds, "Usuario");

                return true;
            }
        }

        public void ActualizarIdiomaUsuario(string login, string id_Idioma)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter =
                    new SqlDataAdapter(
                        "SELECT * FROM Usuario WHERE Login = @Login",
                        conn);

                adapter.SelectCommand.Parameters.AddWithValue("@Login", login);

                DataSet ds = new DataSet();

                adapter.Fill(ds, "Usuario");

                DataRow fila = ds.Tables["Usuario"].Rows[0];

                fila["Id_Idioma"] = id_Idioma;

                SqlCommandBuilder builder =
                    new SqlCommandBuilder(adapter);

                adapter.Update(ds, "Usuario");

            }
        }

        public bool ExisteEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Usuario", conn);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Usuario");

                foreach (DataRow fila in ds.Tables["Usuario"].Rows)
                {
                    if (fila["email"].ToString().Equals(email, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool ExisteEmail(string email, string dni)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Usuario", conn);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Usuario");

                foreach (DataRow fila in ds.Tables["Usuario"].Rows)
                {
                    if (fila["email"].ToString().Equals(email, StringComparison.OrdinalIgnoreCase)
                        && fila["DNI"].ToString() != dni)
                    {
                        return true;
                    }
                }

                return false;
            }
        }


    }
}