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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null)
            {

                txtNumeroControl.Text = Request.Params["parametro"];

            }

            llenarReporte();
        }

        public void llenarReporte()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    string id = txtNumeroControl.Text;
                    conn.Open();
                    string cadena = "select pd.CONTADOR,nombreInstitucion,visitaPractica,alumnosProgramados,semestre,grupo,carrera,docenteResponsable,materia,objetivo,fechaVisita,horaPropuesta from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso WHERE pd.CONTADOR='" + id+"';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        CartaPrecentacionPermisos reporte = new CartaPrecentacionPermisos();
                        reporte.SetParameterValue("@contador", registro["CONTADOR"].ToString());
                        reporte.SetParameterValue("@nombreInstitucion", registro["nombreInstitucion"].ToString());
                        reporte.SetParameterValue("@visitaPractica", registro["visitaPractica"].ToString());
                        reporte.SetParameterValue("@alumnosProgramados", registro["alumnosProgramados"].ToString());
                        reporte.SetParameterValue("@semestre", registro["semestre"].ToString());
                        reporte.SetParameterValue("@grupo", registro["grupo"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@docenteResponsable", registro["docenteResponsable"].ToString());
                        reporte.SetParameterValue("@materia", registro["materia"].ToString());
                        reporte.SetParameterValue("@objetivo", registro["objetivo"].ToString());
                        reporte.SetParameterValue("@horaPropuesta", registro["horaPropuesta"].ToString());
                        reporte.SetParameterValue("@fechaVisita", registro["fechaVisita"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MMM/yyyy"));
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