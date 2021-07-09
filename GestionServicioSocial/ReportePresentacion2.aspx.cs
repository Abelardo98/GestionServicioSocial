using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class ReportePrecentacion2 : System.Web.UI.Page
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
            llenarReporte(); 
        }

        public void llenarReporte()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString)) 
            {
                try 
                {
                    conn.Open();
                    string cadena = "SELECT alu.numerocontrol,nombre, contador,apellidoP,apellidoM,carrera,nombreTitular,puestoTitular,nombreDependencia,nombreAcesor,puestoAcesor from infoEscolar inf join Alumno alu on inf.idescolar = alu.numerocontrol join Programa pro on alu.numerocontrol=pro.idPrograma where alu.numerocontrol='"+txtNumeroControl.Text+"';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if(registro.Read()) 
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        informePrecentacion2 reporte = new informePrecentacion2();
                        reporte.SetParameterValue("@nombreTitular", registro["nombreTitular"].ToString());
                        reporte.SetParameterValue("@puestoTitular", registro["puestoTitular"].ToString());
                        reporte.SetParameterValue("@nombreDependencia", registro["nombreDependencia"].ToString());
                        reporte.SetParameterValue("@nombreAl", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoPal", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoMal", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@carrea", registro["carrera"].ToString());
                        reporte.SetParameterValue("@contador", registro["contador"].ToString());
                        reporte.SetParameterValue("@nc", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MM/yyyy"));  
                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e) 
                {
                    //mensaje.Text = e.Message;
                }
            }
        }
    }
}