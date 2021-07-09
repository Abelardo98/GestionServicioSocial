using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class ExportarReportesReci : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userResidencia"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    txtNumeroControl.Text = Session["userResidencia"].ToString();
                }
            }
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaRecidencia.aspx");
        }

        protected void BtnCartaPrecentacion_Click(object sender, EventArgs e)
        {
            llenarDatos();
            validarReporte();


        }

        protected void BtnCartaSolicitud_Click(object sender, EventArgs e)
        {   
            String NC = txtNumeroControl.Text;
            Session["userResidencia"] = NC;
            Response.Write("<script type='text/javascript'>window.open('ReporteSolicitudRecidencia2.aspx?parametro=" + NC + "');</script>");
        }

        public void llenarDatos()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select idPrograma,recidenciaTec from ProgramaReci where idPrograma = '" + txtNumeroControl.Text + "'; ", conn);


                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }

        public void validarReporte()
        {
            if (GridView1.Rows.Count == 0)
            {


            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {

                    if (row.Cells[1].Text.Equals("SI"))
                    {

                        String NC = txtNumeroControl.Text;
                        Session["userResidencia"] = NC;
                        Response.Write("<script type='text/javascript'>window.open('ReportePrecentacionResidenciaInterno2.aspx?parametro=" + NC + "');</script>");


                    }
                    else if (row.Cells[1].Text.Equals("NO"))
                    {
                        String NC = txtNumeroControl.Text;
                        Session["userResidencia"] = NC;
                        Response.Write("<script type='text/javascript'>window.open('ReportePrecentacionResidencia2.aspx?parametro=" + NC + "');</script>");
                    }
                    else
                    {




                    }

                }
            }

        }

        protected void BtnCostanciaTerminacion_Click(object sender, EventArgs e)
        {
            String NC = txtNumeroControl.Text;
            Session["userResidencia"] = NC;
            Response.Write("<script type='text/javascript'>window.open('ReporteConstanciaTerminacion2.aspx?parametro=" + NC + "');</script>");
            
        }
    }
}