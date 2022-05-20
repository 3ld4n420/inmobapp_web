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
    public partial class Propietarios : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();


        protected void Page_Load(object sender, EventArgs e)
        {
            formulario.Visible = false;

            if (!Page.IsPostBack)
            {
                BindData();
                getTipoCuenta();
                getTipos();
                getEntidades();
              
            }
        }

        private void BindData()
        {


            SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString());

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();


                string sql = "select * from tb_propietario";
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

        private void getTipoCuenta()
        {

            // Establece la consulta SQL a ejecutar
            string consulta = "SELECT codigo ,Descripcion FROM tb_tipo_cuenta";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tipos");
            ddlTipoCuenta.DataSource = ds.Tables["Tipos"].DefaultView;
            ddlTipoCuenta.DataTextField = "Descripcion";
            ddlTipoCuenta.DataValueField = "Codigo";
            ddlTipoCuenta.DataBind();
        }
        private void getEntidades()
        {

            //// Establece la consulta SQL a ejecutar
            string consulta = "SELECT codigo ,Descripcion FROM tb_entidades";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Entidades");
            ddlEntidad.DataSource = ds.Tables["Entidades"].DefaultView;
            ddlEntidad.DataTextField = "Descripcion";
            ddlEntidad.DataValueField = "Codigo";
            ddlEntidad.DataBind();
        }
     
        private void getTipos()
        {

            // Establece la consulta SQL a ejecutar
            string consulta = "select clitipide_id ,clitipide_descripcion from tb_tipo_identificacion";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tipos");
            ddlTipo.DataSource = ds.Tables["Tipos"].DefaultView;
            ddlTipo.DataTextField = "clitipide_descripcion";
            ddlTipo.DataValueField = "clitipide_id";
            ddlTipo.DataBind();
        }
       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            string tipoId = ddlTipo.SelectedValue;
            string identificacion = txtIdentificacion.Text;
            string nombres = txtNombres.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtFijo.Text;
            string celular = txtCelular.Text;
            string email = txtMail.Text;
            string tipoCuenta = ddlTipoCuenta.SelectedValue;
            string numeroCuenta = txtNumeroCuenta.Text;
            string entidad = ddlEntidad.SelectedValue;

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    //
                    cmd.CommandText = @"INSERT INTO [dbo].[tb_propietario] ([TipoId]
                                                                           ,[NumeroId]
                                                                           ,[Nombres]
                                                                           ,[Direccion]
                                                                           ,[Telefono]
                                                                           ,[Celular]
                                                                           ,[Email]
                                                                           ,[TipoCuenta]
                                                                           ,[NumeroCuenta]
                                                                           ,[Entidad])
                                                                     VALUES 
                                                                            (@TipoId
                                                                            ,@Identificacion
                                                                            ,@Nombres
                                                                            ,@Direccion
                                                                            ,@Telefono
                                                                            ,@Celular
                                                                            ,@Email
                                                                            ,@TipoCuenta
                                                                            ,@NumeroCuenta
                                                                            ,@Entidad)";

                    cmd.Parameters.AddWithValue("@TipoId", SqlDbType.Int).Value = tipoId;
                    cmd.Parameters.AddWithValue("@Identificacion", SqlDbType.NVarChar).Value = identificacion;
                    cmd.Parameters.AddWithValue("@Nombres", SqlDbType.NVarChar).Value = nombres;
                    cmd.Parameters.AddWithValue("@Direccion", SqlDbType.NVarChar).Value =  direccion;
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NVarChar).Value = telefono;
                    cmd.Parameters.AddWithValue("@Celular", SqlDbType.NVarChar).Value = celular;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.AddWithValue("@TipoCuenta", SqlDbType.Int).Value = tipoCuenta;
                    cmd.Parameters.AddWithValue("@NumeroCuenta", SqlDbType.NVarChar).Value = numeroCuenta;
                    cmd.Parameters.AddWithValue("@Entidad", SqlDbType.NVarChar).Value = entidad;

                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {
                lblMsg.Text = "'" + nombres + "' subject details added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + nombres + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            ResetAll(); //to reset all form controls
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string tipoId = ddlTipo.SelectedValue;
            string identificacion = txtIdentificacion.Text;
            string nombres = txtNombres.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtFijo.Text;
            string celular = txtCelular.Text;
            string email = txtMail.Text;
            string tipoCuenta = ddlTipoCuenta.SelectedValue;
            string numeroCuenta = txtNumeroCuenta.Text;
            string entidad = ddlEntidad.SelectedValue;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    cmd.CommandText = @"UPDATE [dbo].[tb_propietario] SET [TipoId] = @TipoId
                                                                           ,[NumeroId] = @Identificacion
                                                                           ,[Nombres]  = @Nombres
                                                                           ,[Direccion] = @Direccion
                                                                           ,[Telefono] = @Telefono
                                                                           ,[Celular] =  @Celular
                                                                           ,[Email] = @Email
                                                                           ,[TipoCuenta] = @TipoCuenta
                                                                           ,[NumeroCuenta] = @NumeroCuenta
                                                                           ,[Entidad] = @Entidad
                                                                      WHERE Codigo = @Codigo";
                   
                    cmd.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;
                    cmd.Parameters.Add("@TipoId", SqlDbType.Int).Value = tipoId;
                    cmd.Parameters.Add("@Identificacion", SqlDbType.NVarChar).Value = identificacion;
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar).Value = nombres;
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = direccion;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = telefono;
                    cmd.Parameters.Add("@Celular", SqlDbType.NVarChar).Value = celular;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                    cmd.Parameters.Add("@TipoCuenta", SqlDbType.Int).Value = tipoCuenta;
                    cmd.Parameters.Add("@NumeroCuenta", SqlDbType.NVarChar).Value = numeroCuenta;
                    cmd.Parameters.Add("@Entidad", SqlDbType.NVarChar).Value = entidad;

                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + nombres + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + nombres + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvDatos.EditIndex = -1;
            BindData();
            ResetAll(); //to reset all form controls
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsDeleted = false;
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombres = txtNombres.Text;
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
                lblMsg.Text = "Se han actualizado correctamente los datos de: " + "'" + nombres + "'";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error actualizando los datos de: '" + nombres + "'";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll(); //to reset all form controls
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll(); //to reset all form controls
            Response.Redirect("UsuariosSistema.aspx");


        }

        //call to reset all form controls
        private void ResetAll()
        {
            btnInsert.Visible = true;           
            gvDatos.Visible = true;
            btnNuevo.Visible = true;

            ddlTipo.SelectedIndex = 0;
            txtIdentificacion.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtFijo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtMail.Text = string.Empty;
            ddlTipoCuenta.SelectedIndex = 0;
            txtNumeroCuenta.Text = string.Empty;
            ddlEntidad.SelectedIndex = 0;

            BindData();
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = gvDatos.DataKeys[gvDatos.SelectedRow.RowIndex].Value.ToString();    

            ddlTipo.SelectedValue = (gvDatos.SelectedRow.FindControl("lblTipoId") as Label).Text; 
            txtIdentificacion.Text = (gvDatos.SelectedRow.FindControl("lblNumeroId") as Label).Text;
            txtNombres.Text = (gvDatos.SelectedRow.FindControl("lblNombres") as Label).Text;
            txtDireccion.Text = (gvDatos.SelectedRow.FindControl("lblDireccion") as Label).Text;
            txtFijo.Text = (gvDatos.SelectedRow.FindControl("lblTelefono") as Label).Text;
            txtCelular.Text = (gvDatos.SelectedRow.FindControl("lblCelular") as Label).Text;
            txtMail.Text = (gvDatos.SelectedRow.FindControl("lblEmail") as Label).Text;
            ddlTipoCuenta.SelectedValue = (gvDatos.SelectedRow.FindControl("lblTipoCuenta") as Label).Text;
            txtNumeroCuenta.Text = (gvDatos.SelectedRow.FindControl("lblNumeroCuenta") as Label).Text;
            ddlEntidad.SelectedValue = (gvDatos.SelectedRow.FindControl("lblEntidad") as Label).Text;

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