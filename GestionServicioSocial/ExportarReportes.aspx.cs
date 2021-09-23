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
    public partial class ExportarReportes : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userServicio"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    txtNumeroControl.Text = Session["userServicio"].ToString();
                }
            }


        }
        public void llenarDatosR()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select idPrograma,servicioTec from Programa where idPrograma = '" + txtNumeroControl.Text + "'; ", conn);
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
                String NC = txtNumeroControl.Text;
                Session["userServicio"] = NC;
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[1].Text.Equals("SI"))
                    {
                        String NC = txtNumeroControl.Text;
                        Session["userServicio"] = NC;
                        Response.Write("<script type='text/javascript'>window.open('ReportePresentacionInterno2.aspx');</script>");
                    }
                    else if (row.Cells[1].Text.Equals("NO"))
                    {
                        String NC = txtNumeroControl.Text;
                        Session["userServicio"] = NC;
                        Response.Write("<script type='text/javascript'>window.open('ReportePresentacion2.aspx');</script>");
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }

        protected void BtnCartaPrecentacion_Click(object sender, EventArgs e)
        {
            llenarDatosR();
            validarReporte();
        }

        protected void BtnCartaSolicitud_Click(object sender, EventArgs e)
        {
            String NC = txtNumeroControl.Text;
            Session["userServicio"] = NC;
            Response.Write("<script type='text/javascript'>window.open('ReporteSolicitud2.aspx');</script>");
        }

        protected void BtnConstanciaTerminacion_Click(object sender, EventArgs e)
        {
            String NC = txtNumeroControl.Text;
            Session["userServicio"] = NC;
            Response.Write("<script type='text/javascript'>window.open('ReporteConstanciaTerminacion2.aspx');</script>");
            
        }
    }
}