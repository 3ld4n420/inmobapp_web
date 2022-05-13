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
    public partial class Agenda : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();


        protected void Page_Load(object sender, EventArgs e)
        {
            formulario.Visible = false;

            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {


            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString());

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();


                string sql = "select * from tb_agenda";
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


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            string titulo = txtNombreCita.Text;
            string descripcion = txtDescripcion.Text;
            string cliente = txtNombreCliente.Text;
            string correo = txtCorreoCliente.Text;
            string fechaRegistro = txtFechaRegistro.Text;
            string fechaFin = txtFechaFin.Text;

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    //
                    cmd.CommandText = @"INSERT INTO [dbo].[tb_agenda] ( nombre_cita
                                                                            , descripcion_cita
                                                                            , cliente_cita
                                                                            , cliente_correo_cita   
                                                                            , fecha_registro_cita
                                                                            , fecha_fin_cita)
                                                                     VALUES 
                                                                            (@nombre_cita
                                                                            ,@descripcion_cita
                                                                            ,@cliente_cita
                                                                            ,@cliente_correo_cita
                                                                            ,@fecha_registro_cita
                                                                            ,@fecha_fin_cita)";
                    cmd.Parameters.AddWithValue("@nombre_cita", SqlDbType.NVarChar).Value = titulo;
                    cmd.Parameters.AddWithValue("@descripcion_cita", SqlDbType.NVarChar).Value = descripcion;
                    cmd.Parameters.AddWithValue("@cliente_cita", SqlDbType.NVarChar).Value =  cliente;
                    cmd.Parameters.AddWithValue("@cliente_correo_cita", SqlDbType.NVarChar).Value = correo;
                    cmd.Parameters.AddWithValue("@fecha_registro_cita", SqlDbType.DateTime).Value = fechaRegistro;
                    cmd.Parameters.AddWithValue("@fecha_fin_cita", SqlDbType.DateTime).Value = fechaFin;

                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {
                lblMsg.Text = "'" + titulo + "' subject details added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + titulo + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            ResetAll(); //to reset all form controls
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCita.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            string titulo = txtNombreCita.Text;
            string descripcion = txtDescripcion.Text;
            string cliente = txtNombreCliente.Text;
            string correo = txtCorreoCliente.Text;
            string fechaRegistro = txtFechaRegistro.Text;
            string fechaFin = txtFechaFin.Text;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    cmd.CommandText = @"UPDATE  [dbo].[tb_agenda] ( nombre_cita
                                                                            , descripcion_cita
                                                                            , cliente_cita
                                                                            , cliente_correo_cita   
                                                                            , fecha_registro_cita
                                                                            , fecha_fin_cita)";
                    cmd.Parameters.AddWithValue("@descripcion_cita", SqlDbType.NVarChar).Value = descripcion;
                    cmd.Parameters.AddWithValue("@cliente_cita", SqlDbType.NVarChar).Value = cliente;
                    cmd.Parameters.AddWithValue("@cliente_correo_cita", SqlDbType.NVarChar).Value = correo;
                    cmd.Parameters.AddWithValue("@fecha_registro_cita", SqlDbType.DateTime).Value = fechaRegistro;
                    cmd.Parameters.AddWithValue("@fecha_fin_cita", SqlDbType.DateTime).Value = fechaFin;

                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + titulo + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + titulo + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvDatos.EditIndex = -1;
            BindData();
            ResetAll(); //to reset all form controls
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCita.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsDeleted = false;
            int codigo = Convert.ToInt32(txtNombreCita.Text);
            string nombres = txtNombreCita.Text;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM tb_propietario WHERE Codigo=@Codigo";
                    cmd.Parameters.AddWithValue("@Codigo", SqlDbType.Int).Value = codigo;
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsDeleted = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsDeleted)
            {
                lblMsg.Text = "'" + nombres + "' subject details deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error while deleting '" + nombres + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll(); //to reset all form controls
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll(); //to reset all form controls

        }

        //call to reset all form controls
        private void ResetAll()
        {
            btnInsert.Visible = true;
            gvDatos.Visible = true;
            btnNuevo.Visible = true;

            txtNombreCita.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombreCita.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtCorreoCliente.Text = string.Empty;
            txtFechaRegistro.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            BindData();
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = gvDatos.DataKeys[gvDatos.SelectedRow.RowIndex].Value.ToString();

            txtNombreCita.Text = (gvDatos.SelectedRow.FindControl("lblNombre") as Label).Text;
            txtDescripcion.Text = (gvDatos.SelectedRow.FindControl("lblDescripcion") as Label).Text;
            txtNombreCliente.Text = (gvDatos.SelectedRow.FindControl("lblCliente") as Label).Text;
            txtCorreoCliente.Text = (gvDatos.SelectedRow.FindControl("lblCorreo") as Label).Text;
            txtFechaRegistro.Text = (gvDatos.SelectedRow.FindControl("lblFechaRegistro") as Label).Text;
            txtFechaFin.Text = (gvDatos.SelectedRow.FindControl("lblFechaFin") as Label).Text;

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

        protected void ddlFechaRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}