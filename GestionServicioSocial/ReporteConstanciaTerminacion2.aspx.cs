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
    public partial class ReporteConstanciaTerminacion2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userAdmin"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    string valor = Convert.ToString(Request.QueryString["nc"]);
                    txtNumeroControl.Text = valor;
                }
                llenarReporte();
            }
        }

        public void llenarReporte() 
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "SELECT contador,alu.numerocontrol,nombre,apellidoP,apellidoM,carrera,nombreDependencia,municipio,estado,tipoPrograma,fechaInicioServ,fechaTerminoServ,LEFT(final, 3) as 'final',nivelDesempenio from Domicilio dom join infoEscolar inf on dom.iddomicilio =inf.idescolar join Alumno alu on inf.idescolar = alu.numerocontrol join Programa pro on alu.numerocontrol=pro.idPrograma join calificaciones cali on alu.numerocontrol=cali.idCalificaciones where alu.numerocontrol='"+ txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        ConstanciaTerminacion2 reporte = new ConstanciaTerminacion2();
                        reporte.SetParameterValue("@contador", registro["contador"].ToString());
                        reporte.SetParameterValue("@numerocontrol", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@nombre", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoP", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoM", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@nombreDependencia", registro["nombreDependencia"].ToString());
                        reporte.SetParameterValue("@municipio", registro["municipio"].ToString());
                        reporte.SetParameterValue("@estado", registro["estado"].ToString());
                        reporte.SetParameterValue("@tipoPrograma", registro["tipoPrograma"].ToString());
                        reporte.SetParameterValue("@fechaInicioServ", registro["fechaInicioServ"].ToString());
                        reporte.SetParameterValue("@fechaTerminoServ", registro["fechaTerminoServ"].ToString());
                        reporte.SetParameterValue("@final", registro["final"].ToString());
                        reporte.SetParameterValue("@nivelDesempeño", registro["nivelDesempeño"].ToString());
                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e)
                {
                    //Mensaje.Text = e.Message;
                }
            }
        }
    }
}