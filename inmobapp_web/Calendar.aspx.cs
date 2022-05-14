using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inmobapp_web
{
    public partial class Calendar : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        int idEvento = 0;
        int idHora = 0;
        DateTime date;

        protected void Page_Load(object sender, EventArgs e)
        {

            Calendar1.Caption = "Calendario";
            Calendar1.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            Calendar1.NextPrevFormat = NextPrevFormat.ShortMonth;
            Calendar1.TitleFormat = TitleFormat.MonthYear;
            Calendar1.ShowGridLines = true;
            Calendar1.DayStyle.HorizontalAlign = HorizontalAlign.Left;
            Calendar1.DayStyle.VerticalAlign = VerticalAlign.Top;
            Calendar1.Height = new Unit(75);
            Calendar1.Width = new Unit(100);
            Calendar1.OtherMonthDayStyle.BackColor = System.Drawing.Color.Cornsilk;
            date = DateTime.Now;
            ViewState["date"] = date;

            lblFecha.Text = date.ToString("D");

            if (!IsPostBack)
                getData(date);
        }

        public void getData(DateTime date)
        {

            string filtro = string.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day);
            SqlConnection _connection = new SqlConnection(conn);

            try

            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();


                string sql = $@"  SELECT isnull(e. id, 0) as idEvento, 
                                           h.idhora,
                                           h.hora,
                                           Isnull(e.descripcion, '') AS descripcion
                                    FROM   tb_horas h
                                           INNER JOIN tb_events e
                                                   ON e.idhora = h.idhora
                                    WHERE  e.fechainicio = '{filtro}'
                                    UNION
                                    SELECT isnull(e. id, 0) as id,
                                           h.idhora,
                                           h.hora,
                                           Isnull(e.descripcion, '') AS descripcion
                                    FROM   tb_horas h
                                           LEFT JOIN tb_events e
                                                  ON e.idhora = h.idhora
                                                     AND e.idhora IS NULL
                                    WHERE  h.idhora NOT IN (SELECT h.idhora
                                                            FROM   tb_horas h
                                                                   INNER JOIN tb_events e
                                                                           ON e.idhora = h.idhora
                                                            WHERE  e.fechainicio = '{filtro}')
                                    ORDER  BY h.idhora";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, _connection);

                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);

                gvData.DataSource = table;
                gvData.DataBind();



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

        public void getEvento(int id)
        {

            SqlConnection _connection = new SqlConnection(conn);

            try

            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();


                string sql = $@"  SELECT isnull(e. id, 0) as idEvento, 
                                           h.idhora,
                                           h.hora,
                                           Isnull(e.descripcion, '') AS descripcion
                                    FROM   tb_horas h
                                     INNER JOIN tb_events e
                                                   ON e.idhora = h.idhora
                                    WHERE  e.id = '{id}'";


                SqlCommand cmdd = new SqlCommand(sql, _connection);
                SqlDataReader drr;

                drr = cmdd.ExecuteReader();
                while (drr.Read())
                {
                    ViewState["idHora"] = drr["idHora"].ToString();
                    ViewState["Hora"] = drr["hora"].ToString();
                    ViewState["Descripcion"] = drr["descripcion"].ToString();
                }

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

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            date = Calendar1.SelectedDate;
            ViewState["date"] = date;

            lblFecha.Text = date.ToString("D");
            getData(date);

            if (ViewState["date"] != null && ViewState["idHora"] != null)
                btnAceptar.Enabled = true;
            else
                btnAceptar.Enabled = false;

        }



        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                idEvento = Convert.ToInt16(this.gvData.SelectedDataKey.Values[0]);
                idHora = Convert.ToInt16(this.gvData.SelectedDataKey.Values[1]);
                string  hora = this.gvData.SelectedDataKey.Values[2].ToString();


                if (idEvento != 0)
                {
                    ViewState["IdEvento"] = idEvento;

                    getEvento(idEvento);

                    lblHora.Text = ViewState["Hora"].ToString();
                    lblFecha.Text = Convert.ToDateTime(ViewState["date"]).ToString("D");
                    txtDescripcion.InnerText = ViewState["Descripcion"].ToString();
                }
                else
                {
                    ViewState["IdEvento"] = idEvento;
                    ViewState["idHora"] = idHora;

                    lblHora.Text = hora;
                    lblFecha.Text = date.ToString("D");
                    txtDescripcion.InnerText = String.Empty;

                }

                if (ViewState["date"] != null && ViewState["idHora"] != null)
                    btnAceptar.Enabled = true;
                else
                    btnAceptar.Enabled = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ViewState["IdEvento"] == null || Convert.ToInt32(ViewState["IdEvento"]) == 0)
                Guardar();
            else           
                Actualizar();
            
        }


        void Guardar() {
            bool IsAdded = false;
         

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new                   

                    cmd.CommandText = @"INSERT INTO [dbo].[tb_events]
			                                                   ([descripcion]
			                                                   ,[fechaInicio]
			                                                   ,[fechaFin]
			                                                   ,[activo]
			                                                   ,[idhora])
                                                   VALUES
                                                                           (@desc
                                                                           ,@date
                                                                           ,@date 
                                                                           ,1
                                                                           ,@idHora)";



                    cmd.Parameters.AddWithValue("@date", ViewState["date"]);
                    cmd.Parameters.AddWithValue("@idHora", ViewState["idHora"]);
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.InnerText);


                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    sqlCon.Close();
                }
            }
            if (IsAdded)
            {


                lblMsg.Text = "Evento creado satisfactoriamente!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                getData(Convert.ToDateTime(ViewState["date"]));

                lblHora.Text = string.Empty;
                txtDescripcion.InnerText = String.Empty;
            }
            else
            {
                lblMsg.Text = "Error mientras se agregaba el evento";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        void Actualizar() {

            bool IsUpdated = false;

            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //here added "@" to write continuous string in new line
                    cmd.CommandText = @"UPDATE [dbo].[tb_events] SET  Descripcion = @Descipcion WHERE Id = @Id";
                    cmd.Parameters.Add("@Descipcion", SqlDbType.NVarChar).Value = txtDescripcion.InnerText;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ViewState["IdEvento"];
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    IsUpdated = true;
                }
            }


            if (IsUpdated)
            {
                lblMsg.Text = "Evento modificado satisfactoriamente!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                getData(Convert.ToDateTime(ViewState["date"]));

                lblHora.Text = string.Empty;
                txtDescripcion.InnerText = String.Empty;
            }
            else
            {
                lblMsg.Text = "Error mientras se modificaba el evento";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}