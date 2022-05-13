using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inmobapp_web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString());

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                SqlCommand sqlCommand;
                //SqlDataReader sqlDataReader;

                string sql = "Select * FROM tb_usuarios_sistema WHERE usr_usuario = @usuario AND usr_contrasenia = @password AND usr_activo = 1 ";


                sqlCommand = new SqlCommand(sql, _connection);

                sqlCommand.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@password", txtPassword.Text);


                //sqlDataReader = sqlCommand.ExecuteReader();

                //Si existe un usuario con los datos retorna true, caso contrario false
                bool correcto = Convert.ToInt32(sqlCommand.ExecuteScalar()) > 0;


                if (correcto)
                {
                    //Si existe, Bienvenido...
                    Response.Redirect("Default.aspx");

                }
                else
                {
                   

                }


            }
            catch
            {
              
            }
            finally {
                _connection.Close();
            }
        }
    }
}
