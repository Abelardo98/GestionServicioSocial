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
    public partial class ReportePrecentacionResidensia2 : System.Web.UI.Page
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
                llenarTabla();
                validarReporte();
            }

            llenarReporte();
            
        }

        public void llenarReporte()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "SELECT alu.numerocontrol,nombre,apellidoP,apellidoM,carrera, seguroFacultativo,nombreTitular,puestoTitular,razonSocial,nombreAcesor,puestoAcesor,contador,copiaNombrePersona,copiaPuestoPersona from infoEscolarReci inf join AlumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol=pro.idPrograma where alu.numerocontrol='" + txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        InformePrecentacionRecidencia reporte = new InformePrecentacionRecidencia();
                        reporte.SetParameterValue("@nombreTitular", registro["nombreTitular"].ToString());
                        reporte.SetParameterValue("@puestoTitular", registro["puestoTitular"].ToString());
                        reporte.SetParameterValue("@nombreDependencia", registro["razonSocial"].ToString());
                        reporte.SetParameterValue("@nombreAlumno", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoP", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoM", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@numeroControl", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@imss", registro["seguroFacultativo"].ToString());
                        reporte.SetParameterValue("@contador", registro["contador"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MMMM/yyyy"));

                        if (validarReporte()== true) {
                            reporte.SetParameterValue("@ANT", "AT´N");
                            reporte.SetParameterValue("@copiaNombre", registro["copiaNombrePersona"]);
                            reporte.SetParameterValue("@copiaPuesto", registro["copiaPuestoPersona"]);
                        }
                        //mensaje.Text = registro["nombre"].ToString(); AT´N:
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e)
                {
                    Mensaje.Text = e.Message;
                }
            }
        }


        public void llenarTabla()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select copiaNombrePersona,copiaPuestoPersona from ProgramaReci where numerocontrol = '" + txtNumeroControl.Text + "'; ", conn);
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


        public Boolean validarReporte()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                
                string palabra = row.Cells[0].Text.ToString().Trim();

                

                if (palabra.Length <=6) {
                    return false;
                }
                else {
                    return true;
                }


            }
            return false;
        }
    }
}