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
    public partial class UsuariosSistema : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            formulario.Visible = false;

            if (!Page.IsPostBack)
            {
                BindData();
                getTipoIdentificacion();
                getUsuarioRol();

            }

        }

        private void BindData()
        {


            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString());

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();


                string sql = "select * from tb_usuarios_inmobapp where usr_activo = 1";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);

                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);
                gvDatos.DataSource = table;
                gvDatos.DataBind();

            }
            catch
            {

            }
            finally
            {
                _connection.Close();
                gvDatos.Visible = true;
            }
        }

        private void getTipoIdentificacion()
        {// Establece la consulta SQL a ejecutar

            string consulta = "select clitipide_id, clitipide_descripcion from tb_tipo_identificacion";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "TipoIdentificacion");
            ddl_usr_tipo_identificacion.DataSource = ds.Tables["TipoIdentificacion"].DefaultView;
            ddl_usr_tipo_identificacion.DataTextField = "clitipide_descripcion";
            ddl_usr_tipo_identificacion.DataValueField = "clitipide_id";
            ddl_usr_tipo_identificacion.DataBind();

        }

        private void getUsuarioRol()
        {// Establece la consulta SQL a ejecutar

            string consulta = "select usrrol_id, usrrol_descripcion from tb_usuarios_sistema_roles";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "UsuarioRol");
            ddl_usr_tipo_identificacion.DataSource = ds.Tables["UsuarioRol"].DefaultView;
            ddl_usr_tipo_identificacion.DataTextField = "usrrol_descripcion";
            ddl_usr_tipo_identificacion.DataValueField = "usrrol_id";
            ddl_usr_tipo_identificacion.DataBind();

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            string usr_nombres_apellidos = txt_usr_nombres_apellidos.Text;
            string usr_tipo_identificacion = ddl_usr_tipo_identificacion.SelectedValue;
            string usr_numero_identificacion = txt_usr_numero_identificacion.Text;
            string usr_correo = txt_usr_correo.Text;
            string usr_clave = txt_usr_clave.Text;
            string usr_rol = ddl_usr_rol.SelectedValue;
            string usr_fecha_creacion = DateTime.Now.ToString("hh:mm:ss tt");
            string usr_activo = ddl_usr_activo.SelectedValue;

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    //
                    cmd.CommandText = @"INSERT INTO [dbo].[tb_usuarios_inmobapp]
                                                   ([usr_nombres_apellidos]
                                                   ,[usr_tipo_identificacion]
                                                   ,[usr_numero_identificacion]
                                                   ,[usr_correo]
                                                   ,[usr_clave]
                                                   ,[usr_rol]
                                                   ,[usr_fecha_creacion]
                                                   ,[usr_activo])
                                             VALUES
                                                   (@usr_nombres_apellidos
                                                   ,@usr_tipo_identificacion
                                                   ,@usr_numero_identificacion
                                                   ,@usr_correo
                                                   ,@usr_clave
                                                   ,@usr_rol
                                                   ,@usr_fecha_creacion
                                                   ,@usr_activo)";

                    cmd.Parameters.AddWithValue("@usr_nombres_apellidos", SqlDbType.NVarChar).Value = usr_nombres_apellidos;
                    cmd.Parameters.AddWithValue("@usr_tipo_identificacion", SqlDbType.Int).Value = usr_tipo_identificacion;
                    cmd.Parameters.AddWithValue("@usr_numero_identificacion", SqlDbType.Int).Value = usr_numero_identificacion;
                    cmd.Parameters.AddWithValue("@usr_correo", SqlDbType.NVarChar).Value = usr_correo;
                    cmd.Parameters.AddWithValue("@usr_clave", SqlDbType.NVarChar).Value = usr_clave;
                    cmd.Parameters.AddWithValue("@usr_rol", SqlDbType.Int).Value = usr_rol;
                    cmd.Parameters.AddWithValue("@usr_fecha_creacion", SqlDbType.DateTime).Value = usr_fecha_creacion;
                    cmd.Parameters.AddWithValue("@usr_activo", SqlDbType.Bit).Value = usr_activo;

                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {
                lblMsg.Text = "'" + usr_nombres_apellidos + "' subject details added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + usr_nombres_apellidos + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            ResetAll(); //to reset all form controls

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_usr_id.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            int usr_id = Convert.ToInt32(txt_usr_id.Text);
            string usr_nombres_apellidos = txt_usr_nombres_apellidos.Text;
            string usr_tipo_identificacion = ddl_usr_tipo_identificacion.SelectedValue;
            string usr_numero_identificacion = txt_usr_numero_identificacion.Text;
            string usr_correo = txt_usr_correo.Text;
            string usr_clave = txt_usr_clave.Text;
            string usr_rol = ddl_usr_rol.SelectedValue;
            string usr_fecha_creacion = DateTime.Now.ToString("hh:mm:ss tt");
            string usr_activo = ddl_usr_activo.SelectedValue;

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    cmd.CommandText = @"UPDATE [dbo].[tb_usuarios_inmobapp]
                                           SET [usr_nombres_apellidos] = @usr_nombres_apellidos
                                              ,[usr_tipo_identificacion] = @usr_tipo_identificacion
                                              ,[usr_numero_identificacion] = @usr_numero_identificacion
                                              ,[usr_correo] = @usr_correo
                                              ,[usr_clave] = @usr_clave
                                              ,[usr_rol] = @usr_rol
                                              ,[usr_fecha_creacion] = @usr_fecha_creacion
                                              ,[usr_activo] = @usr_activo
                                         WHERE usr_id = @usr_id";

                    cmd.Parameters.AddWithValue("@usr_id", SqlDbType.Int).Value = usr_id;
                    cmd.Parameters.AddWithValue("@usr_nombres_apellidos", SqlDbType.NVarChar).Value = usr_nombres_apellidos;
                    cmd.Parameters.AddWithValue("@usr_tipo_identificacion", SqlDbType.Int).Value = usr_tipo_identificacion;
                    cmd.Parameters.AddWithValue("@usr_numero_identificacion", SqlDbType.Int).Value = usr_numero_identificacion;
                    cmd.Parameters.AddWithValue("@usr_correo", SqlDbType.NVarChar).Value = usr_correo;
                    cmd.Parameters.AddWithValue("@usr_clave", SqlDbType.NVarChar).Value = usr_clave;
                    cmd.Parameters.AddWithValue("@usr_rol", SqlDbType.Int).Value = usr_rol;
                    cmd.Parameters.AddWithValue("@usr_fecha_creacion", SqlDbType.DateTime).Value = usr_fecha_creacion;
                    cmd.Parameters.AddWithValue("@usr_activo", SqlDbType.Bit).Value = usr_activo;


                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + usr_nombres_apellidos + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + usr_nombres_apellidos + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvDatos.EditIndex = -1;
            BindData();
            ResetAll(); //to reset all form controls


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_usr_id.Text))
            {
                lblMsg.Text = "Selecciona un valor para actualizar";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            int usr_id = Convert.ToInt32(txt_usr_id.Text);
            string usr_nombres_apellidos = txt_usr_nombres_apellidos.Text;
            string usr_activo = ddl_usr_activo.SelectedValue;

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    cmd.CommandText = @"UPDATE [dbo].[tb_usuarios_inmobapp]
                                           SET [usr_activo] = 0
                                         WHERE usr_id = @usr_id";

                    cmd.Parameters.AddWithValue("@usr_id", SqlDbType.Int).Value = usr_id;
                    cmd.Parameters.AddWithValue("@usr_activo", SqlDbType.Bit).Value = usr_activo;


                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + usr_nombres_apellidos + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + usr_nombres_apellidos + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvDatos.EditIndex = -1;
            BindData();
            ResetAll(); //to reset all form controls


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll();
            Response.Redirect("UsuariosSistema.aspx");

        }

        private void ResetAll()
        {
            btnInsert.Visible = true;
            gvDatos.Visible = true;
            btnNuevo.Visible = true;

            txt_usr_nombres_apellidos.Text = string.Empty;
            ddl_usr_tipo_identificacion.SelectedIndex = 0;
            txt_usr_numero_identificacion.Text = string.Empty;
            txt_usr_correo.Text = string.Empty;
            txt_usr_clave.Text = string.Empty;
            ddl_usr_rol.SelectedIndex = 0;

            BindData();
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_usr_id.Text = gvDatos.DataKeys[gvDatos.SelectedRow.RowIndex].Value.ToString();

            txt_usr_nombres_apellidos.Text = (gvDatos.SelectedRow.FindControl("txt_usr_nombres_apellidos") as Label).Text;
            ddl_usr_tipo_identificacion.SelectedValue = (gvDatos.SelectedRow.FindControl("ddl_usr_tipo_identificacion") as Label).Text;
            txt_usr_numero_identificacion.Text = (gvDatos.SelectedRow.FindControl("txt_usr_numero_identificacion") as Label).Text;
            txt_usr_correo.Text = (gvDatos.SelectedRow.FindControl("txt_usr_correo") as Label).Text;
            txt_usr_clave.Text = (gvDatos.SelectedRow.FindControl("txt_usr_clave") as Label).Text;
            ddl_usr_rol.SelectedValue = (gvDatos.SelectedRow.FindControl("ddl_usr_rol") as Label).Text;
            txt_usr_fecha_creacion.Text = (gvDatos.SelectedRow.FindControl("txt_usr_fecha_creacion") as Label).Text;
            ddl_usr_activo.SelectedValue = (gvDatos.SelectedRow.FindControl("ddl_usr_activo") as Label).Text;

            //make invisible Insert button during update/delete
            btnInsert.Visible = false;
            formulario.Visible = true;
            gvDatos.Visible = false;
            btnNuevo.Visible = false;


        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formulario.Visible = true;
            gvDatos.Visible = false;
            this.btnNuevo.Visible = false;

        }
    }
}