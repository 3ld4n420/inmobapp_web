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
    public partial class Inmuebles : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        DataTable tableElements = new DataTable();
        DataTable tableInventario= new DataTable();
        string idInmueble;

        protected void Page_Load(object sender, EventArgs e)
        {
            formulario.Visible = false;

            if (!Page.IsPostBack)
            {
                BindData();
                getBarrios();
                getTipos();
                getEstrato();
                getModalidades();
                getMpio();
                getPropietarios();
                getLugares();
                inventario.Visible = false;

            }
        }

        private void BindData()
        {
           

            SqlConnection _connection = new SqlConnection(conn);

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();


                string sql = @"SELECT I.[INM_ID]
                                      ,I.[INM_CLI_Propietario]
                                      ,I.[INM_MatriculaInmobiliaria]
                                      ,I.[INM_Direccion]
                                      ,I.[INM_BARR_Barrio]
                                      ,I.[INM_MUN_Municipio]
                                      ,I.[INM_LUGRES_LugarResidencia]
                                      ,I.[INM_INMMOD_Modalidad] 
                                      ,I.[INM_INMTIPO_Tipo]
                                      ,I.[INM_EST_Estrato]
                                      ,I.[INM_Area]
                                      ,I.[INM_Disponible]
                                      ,I.[INM_ValorVenta]
                                      ,I.[INM_ValorArriendo]
                                      ,I.[INM_ValorAdministracion]
                                      ,I.[INM_ValorImpuestoPredial]
	                                  ,B.BARR_Nombre AS Barrio
	                                  ,IT.inmtip_descripcion AS Tipo
	                                  ,E.est_estrato_descripcion as Estrato
	                                  ,M.INMMOD_Descripcion as Modalidad
                                  FROM [inmobapp].[dbo].[tb_inmuebles] I
                                  inner JOIN tb_barrios B ON B.BARR_ID = I.INM_BARR_Barrio 
                                  inner JOIN tb_inmuebles_tipo IT ON IT.inmtip_id = I.INM_INMTIPO_Tipo  
                                  inner JOIN tb_estrato E ON E.EST_ID = I.INM_EST_Estrato
                                  inner JOIN tb_inmuebles_modalidades M ON M.INMMOD_ID = I.INM_INMMOD_Modalidad";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);

                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);

                gvDatos.DataSource = table;
                gvDatos.DataBind();     

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
        }
        private void getBarrios()
        {
            
            // Establece la consulta SQL a ejecutar
            string consulta = "SELECT BARR_ID, BARR_Nombre FROM tb_barrios";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Barrios");
            ddlBarrio.DataSource = ds.Tables["Barrios"].DefaultView;
            ddlBarrio.DataTextField = "BARR_Nombre";
            ddlBarrio.DataValueField = "BARR_ID";
            ddlBarrio.DataBind();


        }

        private void getLugares()
        {

            // Establece la consulta SQL a ejecutar
            string consulta = "SELECT [lugres_id] ,[lugres_descripcion] ,[lugres_observacion] FROM[inmobapp].[dbo].[tb_lugar_residencia]";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Lugares");
            ddlLugares.DataSource = ds.Tables["Lugares"].DefaultView;
            ddlLugares.DataTextField = "lugres_descripcion";
            ddlLugares.DataValueField = "lugres_id";
            ddlLugares.DataBind();


        }

        private void getModalidades()
        {

            //Establece la consulta SQL a ejecutar
            string consulta = "SELECT INMMOD_ID ,INMMOD_Descripcion FROM tb_inmuebles_modalidades";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Modalidades");
            ddlModalidad.DataSource = ds.Tables["Modalidades"].DefaultView;
            ddlModalidad.DataTextField = "INMMOD_Descripcion";
            ddlModalidad.DataValueField = "INMMOD_ID";
            ddlModalidad.DataBind();
        }
           
        private void getEstrato()
        {

            // Establece la consulta SQL a ejecutar
            string consulta = "SELECT EST_ID ,est_estrato_descripcion FROM tb_estrato";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Estratos");
            ddlEstrato.DataSource = ds.Tables["Estratos"].DefaultView;
            ddlEstrato.DataTextField = "est_estrato_descripcion";
            ddlEstrato.DataValueField = "EST_ID";
            ddlEstrato.DataBind();
        }
        private void getTipos()
        {

            // Establece la consulta SQL a ejecutar
            string consulta = "SELECT inmtip_id ,inmtip_descripcion FROM tb_inmuebles_tipo";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Tipos");
            ddlTipo.DataSource = ds.Tables["Tipos"].DefaultView;
            ddlTipo.DataTextField = "inmtip_descripcion";
            ddlTipo.DataValueField = "inmtip_id";
            ddlTipo.DataBind();
        }
        private void getMpio()
        {

            // Establece la consulta SQL a ejecutar
            string consulta = "SELECT MUN_ID ,MUN_Descripcion FROM tb_municipios";
            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Mpios");
            ddlMpio.DataSource = ds.Tables["Mpios"].DefaultView;
            ddlMpio.DataTextField = "MUN_Descripcion";
            ddlMpio.DataValueField = "MUN_ID";
            ddlMpio.DataBind();

        }
        private void getPropietarios()
        {

            // Establece la consulta SQL a ejecutar
            string sql = "Select Codigo ,[NumeroId]+ ' - ' +[Nombres]  as Nombres FROM tb_propietario";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            DataSet ds = new DataSet();
            da.Fill(ds, "Propietarios");
            ddlPropietario.DataSource = ds.Tables["Propietarios"].DefaultView;
            ddlPropietario.DataTextField = $"Nombres" ;
            ddlPropietario.DataValueField = "Codigo";
            ddlPropietario.DataBind();

           
        }
        private void getElementos()
        {

            // Establece la consulta SQL a ejecutar
            SqlConnection _connection = new SqlConnection(conn);

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            string sql = "SELECT [Codigo] ,[Descripcion] ,[IdUbicacion] FROM[inmobapp].[dbo].[tb_elementos]";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);
            sqlDataAdapter.Fill(tableElements);
        }
        private void getInventario(string idInmueble)
        {
            try
            {
                // Establece la consulta SQL a ejecutar
                SqlConnection _connection = new SqlConnection(conn);

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                string sql = @"SELECT I.Id
                                      ,I.IdInmueble
                                      ,E.Codigo as IdElemento
	                                  ,E.Descripcion as Elemento
                                      ,I.Cantidad
                                      ,M.Codigo as IdMaterial
	                                  ,M.Descripcion as Material
                                      ,S.Codigo as IdEstado
                                      ,S.Descripcion as Estado
                                      ,I.Observaciones
	                                  ,U.Codigo as IdUbicacion
	                                  ,U.Descripcion as Ubicacion
                                  FROM tb_inventario I
                                  INNER JOIN tb_elementos E ON E.codigo = I.IdElemento
                                  INNER JOIN tb_ubicacion U on U.codigo = E.IdUbicacion
                                  INNER JOIN tb_material  M on M.codigo = I.IdMaterial
                                  INNER JOIN tb_estado  S on S.codigo = I.IdEstado
                                WHERE I.IdInmueble = " + idInmueble;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);
                sqlDataAdapter.Fill(tableInventario);
                ViewState["tableInventario"] = tableInventario;


                if (tableInventario.Rows.Count > 0)
                {
                    getInventarioEntrada();
                    getInventarioSala();
                    getInventarioComedor();
                    inventario.Visible = true;
                }
                else
                {
                    inventario.Visible = false;
                }

               


            }
            catch (Exception ex )
            {

                throw ex;
            }
         
        } 
        void getInventarioEntrada() {

            DataTable data = (DataTable)ViewState["tableInventario"];

            DataView entradaFilter = data.DefaultView;
            entradaFilter.RowFilter = "IdUbicacion = 1";
            gvEntrada.DataSource = entradaFilter;
            gvEntrada.DataBind();
        }
        void getInventarioSala() {
            DataTable data = (DataTable)ViewState["tableInventario"];


            DataView salaFilter = data.DefaultView;
            salaFilter.RowFilter = "IdUbicacion = 2";
            gvSala.DataSource = salaFilter;
            gvSala.DataBind();
        }
        void getInventarioComedor() {

            DataTable data = (DataTable)ViewState["tableInventario"];

            DataView comedorFilter = data.DefaultView;
            comedorFilter.RowFilter = "IdUbicacion = 3";
            gvComedor.DataSource = comedorFilter;
            gvComedor.DataBind();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            bool IsAdded = false;
            int propietario = Convert.ToInt32(ddlPropietario.SelectedValue);
            string direccion = txtDireccion.Text;
            string barrio = ddlBarrio.SelectedValue;

            string matricula = txtMatricula.Text;
            string mpio = ddlMpio.SelectedValue;
            string lugarResidencia = ddlBarrio.SelectedValue;
            string modalidad = ddlModalidad.SelectedValue;
            string tipo = ddlTipo.SelectedValue;
            string estrato = ddlEstrato.SelectedValue;
            string area = txtArea.Text;
            bool disponible = true;
            decimal valorVenta = Convert.ToDecimal(txtValorVenta.Text.Trim());
            decimal valorArriendo = Convert.ToInt32(txtValorArriendo.Text.Trim());
            decimal valorAdministracion = Convert.ToInt32(txtValorAdmon.Text.Trim());
            decimal valorImpuestoPredial = Convert.ToInt32(txtValorImpuesto.Text.Trim());

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new                   

                    cmd.CommandText = @"INSERT INTO [dbo].[tb_inmuebles]   ([INM_CLI_Propietario]
                                                                           ,[INM_MatriculaInmobiliaria]
                                                                           ,[INM_Direccion]
                                                                           ,[INM_BARR_Barrio]
                                                                           ,[INM_MUN_Municipio]
                                                                           ,[INM_LUGRES_LugarResidencia]
                                                                           ,[INM_INMMOD_Modalidad]
                                                                           ,[INM_INMTIPO_Tipo]
                                                                           ,[INM_EST_Estrato]
                                                                           ,[INM_Area]
                                                                           ,[INM_Disponible]
                                                                           ,[INM_ValorVenta]
                                                                           ,[INM_ValorArriendo]
                                                                           ,[INM_ValorAdministracion]
                                                                           ,[INM_ValorImpuestoPredial])
                                                                     VALUES
                                                                           (@propietario
                                                                           ,@matricula
                                                                           ,@direccion
                                                                           ,@barrio
                                                                           ,@mpio
                                                                           ,@lugarResidencia
                                                                           ,@modalidad
                                                                           ,@tipo
                                                                           ,@estrato
                                                                           ,@area
                                                                           ,@disponible
                                                                           ,@valorVenta
                                                                           ,@valorArriendo
                                                                           ,@valorAdministracion
                                                                           ,@valorImpuestoPredial)";


                    cmd.Parameters.AddWithValue("@propietario", propietario);
                    cmd.Parameters.AddWithValue("@matricula", matricula);
                    cmd.Parameters.AddWithValue("@direccion", direccion);

                    cmd.Parameters.AddWithValue("@barrio", barrio);
                    cmd.Parameters.AddWithValue("@mpio", mpio);
                    cmd.Parameters.AddWithValue("@lugarResidencia", lugarResidencia);

                    cmd.Parameters.AddWithValue("@modalidad", modalidad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@estrato", estrato);

                    cmd.Parameters.AddWithValue("@area", area);
                    cmd.Parameters.AddWithValue("@disponible", disponible);
                    cmd.Parameters.AddWithValue("@valorVenta", valorVenta);

                    cmd.Parameters.AddWithValue("@valorArriendo", valorArriendo);
                    cmd.Parameters.AddWithValue("@valorAdministracion", valorAdministracion);
                    cmd.Parameters.AddWithValue("@valorImpuestoPredial", valorImpuestoPredial);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {
                
                InventarioDefault();

                lblMsg.Text = "'" + propietario + "' subject details added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + propietario + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            
            ResetAll(); //to reset all form controls
        }

        void InventarioDefault()
        {
            try
            {

                getElementos();

                foreach (DataRow row in tableElements.Rows)
                {
                    using (SqlConnection sqlCon = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            //here added "@" to write continuous string in new                   

                            cmd.CommandText = @"INSERT INTO [dbo].[tb_inventario]
                                                                               ([IdInmueble]
                                                                               ,[IdElemento]
                                                                               ,[Cantidad]
                                                                               ,[IdMaterial]
                                                                               ,[IdEstado]
                                                                               ,[Observaciones])
                                                                         VALUES
                                                                           ((select max(INM_ID) from tb_inmuebles)
                                                                           ,@IdElemento
                                                                           ,@Cantidad
                                                                           ,@IdMaterial
                                                                           ,@IdEstado
                                                                           ,@Observaciones)";


                            cmd.Parameters.AddWithValue("@IdElemento", row.ItemArray[0]);
                            cmd.Parameters.AddWithValue("@Cantidad", 0);
                            cmd.Parameters.AddWithValue("@IdMaterial", 1);
                            cmd.Parameters.AddWithValue("@IdEstado", 1);
                            cmd.Parameters.AddWithValue("@Observaciones", string.Empty);

                            cmd.Connection = sqlCon;
                            sqlCon.Open();
                            cmd.ExecuteNonQuery();
                            sqlCon.Close();

                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlPropietario.SelectedValue))
            {
                lblMsg.Text = "Please select record to update";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsUpdated = false;
            int ID = Convert.ToInt32(txtINM_ID.Text);
            string propietario = ddlPropietario.SelectedValue;
            string direccion = txtDireccion.Text;
            string barrio = ddlBarrio.SelectedValue;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    cmd.CommandText = @"UPDATE tb_inmuebles SET INM_CLI_Propietario = @propietario, INM_Direccion = @direccion, INM_BARR_Barrio = @barrio  WHERE INM_ID = @INM_ID";
                    cmd.Parameters.Add("@propietario", SqlDbType.NVarChar).Value = propietario;
                    cmd.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion;
                    cmd.Parameters.Add("@barrio", SqlDbType.NVarChar).Value = barrio;
                    cmd.Parameters.Add("@INM_ID", SqlDbType.Int).Value = ID;
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsUpdated = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsUpdated)
            {
                lblMsg.Text = "'" + propietario + "' subject details updated successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Error while updating '" + propietario + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            gvDatos.EditIndex = -1;
            BindData();
            ResetAll(); //to reset all form controls
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtINM_ID  .Text))
            {
                lblMsg.Text = "Please select record to delete";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            bool IsDeleted = false;
            int ID = Convert.ToInt32(txtINM_ID.Text);
            string propietario = ddlPropietario.SelectedValue;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM tb_inmuebles WHERE INM_ID=@INM_ID";
                    cmd.Parameters.AddWithValue("@INM_ID", ID);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsDeleted = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsDeleted)
            {
                lblMsg.Text = "'" + propietario + "' subject details deleted successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                BindData();
            }
            else
            {
                lblMsg.Text = "Error while deleting '" + propietario + "' subject details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            ResetAll(); //to reset all form controls
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll(); //to reset all form controls
            Response.Redirect("Inmuebles.aspx");
        }

        //call to reset all form controls
        private void ResetAll()
        {
            btnInsert.Visible = true;
            txtINM_ID.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            ddlPropietario.SelectedIndex = 0;
            txtDireccion.Text = string.Empty;
            ddlBarrio.SelectedIndex= 0;
            gvDatos.Visible = true;
            btnNuevo.Visible = true;
        }

        protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtINM_ID.Text = gvDatos.DataKeys[gvDatos.SelectedRow.RowIndex].Value.ToString();
            ddlPropietario.SelectedValue = (gvDatos.SelectedRow.FindControl("lblPropietario") as Label).Text;
            txtDireccion.Text = (gvDatos.SelectedRow.FindControl("lblDireccion") as Label).Text;
            ddlBarrio.SelectedValue = (gvDatos.SelectedRow.FindControl("lblBarrio") as Label).Text;

            ddlMpio.SelectedValue = (gvDatos.SelectedRow.FindControl("lblMpio") as Label).Text;
            ddlBarrio.SelectedValue = (gvDatos.SelectedRow.FindControl("lblLugar") as Label).Text;
            ddlModalidad.SelectedValue = (gvDatos.SelectedRow.FindControl("lblModalidad") as Label).Text;
            ddlTipo.SelectedValue = (gvDatos.SelectedRow.FindControl("lblTipo") as Label).Text;
            ddlEstrato.SelectedValue = (gvDatos.SelectedRow.FindControl("lblEstrato") as Label).Text;
            txtArea.Text = (gvDatos.SelectedRow.FindControl("lblArea") as Label).Text;

            txtValorVenta.Text = (gvDatos.SelectedRow.FindControl("lblValorVenta") as Label).Text;
            txtValorArriendo.Text = (gvDatos.SelectedRow.FindControl("lblValorArriendo") as Label).Text;
            txtValorAdmon.Text = (gvDatos.SelectedRow.FindControl("lblValorAdmon") as Label).Text;
            txtValorImpuesto.Text = (gvDatos.SelectedRow.FindControl("lblValorImpuesto") as Label).Text;
            txtMatricula.Text = (gvDatos.SelectedRow.FindControl("lblMatricula") as Label).Text;

            //make invisible Insert button during update/delete
            btnInsert.Visible = false;
            formulario.Visible = true;
            gvDatos.Visible = false;
            btnNuevo.Visible = false;
            inventario.Visible = false;



        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            formulario.Visible = true;
            gvDatos.Visible = false;
            this.btnNuevo.Visible = false;
        }

        protected void gvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            ViewState["idInmueble"] = gvDatos.Rows[gvr.RowIndex].Cells[1].Text;

            if (e.CommandName == "Inventario")
            {
                try
                {
                    getInventario(ViewState["idInmueble"].ToString());

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected void gvDatos_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void gvEntrada_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvEntrada.EditIndex = e.NewEditIndex;
            getInventarioEntrada();
        }

        protected void gvEntrada_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEntrada.EditIndex = -1;
            getInventarioEntrada();
        }

        protected void gvEntrada_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = (gvEntrada.Rows[e.RowIndex].FindControl("lblId") as Label).Text;
            string Observaciones = (gvEntrada.Rows[e.RowIndex].FindControl("txtObservaciones") as TextBox).Text;
            DropDownList ddlCantidad = gvEntrada.Rows[e.RowIndex].FindControl("ddlCantidad") as DropDownList;
            DropDownList ddlMaterial = gvEntrada.Rows[e.RowIndex].FindControl("ddlMaterial") as DropDownList;
            DropDownList ddlEstado   = gvEntrada.Rows[e.RowIndex].FindControl("ddlEstado") as DropDownList;

            UpdateInventarrio(Convert.ToInt32(id), Observaciones, ddlMaterial.SelectedValue, ddlCantidad.SelectedValue, ddlEstado.SelectedValue);

            gvEntrada.EditIndex = -1;
            getInventario(ViewState["idInmueble"].ToString());
            getInventarioEntrada();
        }

        protected void gvComedor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvComedor.EditIndex = e.NewEditIndex;
            getInventarioComedor();
        }

        protected void gvComedor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = (gvComedor.Rows[e.RowIndex].FindControl("lblId") as Label).Text;
            string Observaciones = (gvComedor.Rows[e.RowIndex].FindControl("txtObservaciones") as TextBox).Text;
            DropDownList ddlCantidad = gvComedor.Rows[e.RowIndex].FindControl("ddlCantidad") as DropDownList;
            DropDownList ddlMaterial = gvComedor.Rows[e.RowIndex].FindControl("ddlMaterial") as DropDownList;
            DropDownList ddlEstado = gvComedor.Rows[e.RowIndex].FindControl("ddlEstado") as DropDownList;

            UpdateInventarrio(Convert.ToInt32(id), Observaciones, ddlMaterial.SelectedValue, ddlCantidad.SelectedValue, ddlEstado.SelectedValue);

            gvComedor.EditIndex = -1;
            getInventario(ViewState["idInmueble"].ToString());
            getInventarioComedor();
        }

        protected void gvComedor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvComedor.EditIndex = -1;
            getInventarioComedor();
        }

        protected void gvSala_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = (gvSala.Rows[e.RowIndex].FindControl("lblId") as Label).Text;
            string Observaciones = (gvSala.Rows[e.RowIndex].FindControl("txtObservaciones") as TextBox).Text;
            DropDownList ddlCantidad = gvSala.Rows[e.RowIndex].FindControl("ddlCantidad") as DropDownList;
            DropDownList ddlMaterial = gvSala.Rows[e.RowIndex].FindControl("ddlMaterial") as DropDownList;
            DropDownList ddlEstado = gvSala.Rows[e.RowIndex].FindControl("ddlEstado") as DropDownList;

            UpdateInventarrio(Convert.ToInt32(id), Observaciones, ddlMaterial.SelectedValue, ddlCantidad.SelectedValue, ddlEstado.SelectedValue);

            gvSala.EditIndex = -1;
            getInventario(ViewState["idInmueble"].ToString());
            getInventarioSala();
        }

        protected void gvSala_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSala.EditIndex = e.NewEditIndex;
            getInventarioSala();
        }

        protected void gvSala_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSala.EditIndex = -1;
            getInventarioSala();
        }

        void UpdateInventarrio(int id, string obs, string IdMaterial, string Cantidad, string IdEstado)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //here added "@" to write continuous string in new line
                        cmd.CommandText = @"UPDATE [dbo].[tb_inventario] SET  Cantidad = @Cantidad, IdMaterial = @IdMaterial, IdEstado = @IdEstado , Observaciones = @Observaciones  WHERE Id = @Id";
                        cmd.Parameters.Add("@Cantidad", SqlDbType.NVarChar).Value = Cantidad;
                        cmd.Parameters.Add("@IdMaterial", SqlDbType.NVarChar).Value = IdMaterial;
                        cmd.Parameters.Add("@IdEstado", SqlDbType.NVarChar).Value = IdEstado;
                        cmd.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = obs;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
    }
}