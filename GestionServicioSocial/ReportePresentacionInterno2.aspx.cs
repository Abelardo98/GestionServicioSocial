using System;
using System.Configuration;
using System.Data.SqlClient;
namespace GestionServicioSocial
{
    public partial class ReportePrecentacionInterno2 : System.Web.UI.Page
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
                    string cadena = "SELECT alu.numerocontrol,nombre, contadorIngresado,apellidoP,apellidoM,carrera,nombreTitular," +
                        "puestoTitular,nombreDependencia,nombreAcesor,puestoAcesor from infoEscolar inf join Alumno alu on " +
                        "inf.idescolar = alu.numerocontrol join Programa pro on alu.numerocontrol=pro.idPrograma where " +
                        "alu.numerocontrol='" + txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        informePrecentacionInterno2 reporte = new informePrecentacionInterno2();
                        reporte.SetParameterValue("@nombreAsesor", registro["nombreAcesor"].ToString());
                        reporte.SetParameterValue("@puestoAsesor", registro["puestoAcesor"].ToString());
                        reporte.SetParameterValue("@nc", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@nombreAlu", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoPalu", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoMalu", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@contadorIngresado", registro["contadorIngresado"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MM/yyyy"));
                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e)
                {
                    mensaje.Text = e.Message;
                }
            }
        }
    }
}