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
        string valor;
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
                    string cadena = "SELECT contadorIngresado,alu.numerocontrol,nombre,apellidoP,apellidoM,carrera,horasServicio,nombreDependencia,municipioDependencia,estadoDependencia" +
                        ",nombrePrograma,fechaInicioServ,fechaTerminoServ,diaTerminacion,mesTerminacion,anioTerminacion,LEFT(final, 3) as 'final',nivelDesempenio from Domicilio dom join " +
                        "infoEscolar inf on dom.iddomicilio =inf.idescolar join Alumno alu on inf.idescolar = alu.numerocontrol join Programa " +
                        "pro on alu.numerocontrol=pro.idPrograma join calificaciones cali on alu.numerocontrol=cali.idCalificaciones where" +
                        " alu.numerocontrol='" + txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        ConstanciaTerminacion2 reporte = new ConstanciaTerminacion2();
                        reporte.SetParameterValue("@contadorIngresado", registro["contadorIngresado"].ToString());
                        reporte.SetParameterValue("@numerocontrol", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@nombre", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoP", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoM", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@horasServicio", registro["horasServicio"].ToString());
                        reporte.SetParameterValue("@nombreDependencia", registro["nombreDependencia"].ToString());
                        reporte.SetParameterValue("@municipioDependencia", registro["municipioDependencia"].ToString());
                        reporte.SetParameterValue("@estadoDependencia", registro["estadoDependencia"].ToString());
                        reporte.SetParameterValue("@nombrePrograma", registro["nombrePrograma"].ToString());
                        reporte.SetParameterValue("@fechaInicioServ", registro["fechaInicioServ"].ToString());
                        reporte.SetParameterValue("@fechaTerminoServ", registro["fechaTerminoServ"].ToString());
                        reporte.SetParameterValue("@final", registro["final"].ToString());
                        reporte.SetParameterValue("@nivelDesempeño", registro["nivelDesempenio"].ToString());
                        reporte.SetParameterValue("@diaTerminacion", registro["diaTerminacion"].ToString());
                        reporte.SetParameterValue("@mesTerminacion", registro["mesTerminacion"].ToString());
                        reporte.SetParameterValue("@anioTerminacion", registro["anioTerminacion"].ToString());

                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e)
                {
                    txtNumeroControl.Text = e.Message;
                }
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Session["userAdmin"] = "ADMIN";
            Server.Transfer("vista.aspx");
        }
    }
}