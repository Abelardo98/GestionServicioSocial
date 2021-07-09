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
    public partial class ReportePermisos2 : System.Web.UI.Page
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
                    conn.Open();
                    string cadena = "select pd.idPermisoAcademico,pd.CONTADOR,visitaPractica,visitaIndustrial,practica,docenteResponsable,numCelularDocente,CorreoElectronicoDocente,materia,semestre,grupo,alumnosProgramados,especialidad,carrera,objetivo,practicaDescripcion,nombreInstitucion,representante,puestoOcargo,direccion,municipioEstado,telefonoOrganizacion,fax,email,paginaWeb,fechaVisita,horaPropuesta,recomendaciones from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso where pd.idPermisoAcademico='" + txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        permisoIndustrial reporte = new permisoIndustrial();
                        reporte.SetParameterValue("@visitaPractica", registro["visitaPractica"].ToString());
                        reporte.SetParameterValue("@visitaIndustrial", registro["visitaIndustrial"].ToString());
                        reporte.SetParameterValue("@practica", registro["practica"].ToString());
                        reporte.SetParameterValue("@docenteResponsable", registro["docenteResponsable"].ToString());
                        reporte.SetParameterValue("@numCelularDocente", registro["numCelularDocente"].ToString());
                        reporte.SetParameterValue("@CorrElectDoc", registro["CorreoElectronicoDocente"].ToString());
                        reporte.SetParameterValue("@materia", registro["materia"].ToString());
                        reporte.SetParameterValue("@semestre", registro["semestre"].ToString());
                        reporte.SetParameterValue("@grupo", registro["grupo"].ToString());
                        reporte.SetParameterValue("@alumProg", registro["alumnosProgramados"].ToString());
                        reporte.SetParameterValue("@especialidad", registro["especialidad"].ToString());
                        reporte.SetParameterValue("@objetivo", registro["objetivo"].ToString());
                        reporte.SetParameterValue("@pracDescr", registro["practicaDescripcion"].ToString());
                        reporte.SetParameterValue("@nombreInstitucion", registro["nombreInstitucion"].ToString());
                        reporte.SetParameterValue("@representante", registro["representante"].ToString());
                        reporte.SetParameterValue("@puestocargo", registro["puestoOcargo"].ToString());
                        reporte.SetParameterValue("@direccion", registro["direccion"].ToString());
                        reporte.SetParameterValue("@municipioEstado", registro["municipioEstado"].ToString());
                        reporte.SetParameterValue("@telefonoOrganizacion", registro["telefonoOrganizacion"].ToString());
                        reporte.SetParameterValue("@fax", registro["fax"].ToString());
                        reporte.SetParameterValue("@email", registro["email"].ToString());
                        reporte.SetParameterValue("@paginaWeb", registro["paginaWeb"].ToString());
                        reporte.SetParameterValue("@fechaVisita", registro["fechaVisita"].ToString());
                        reporte.SetParameterValue("@horaPropuesta", registro["horaPropuesta"].ToString());
                        reporte.SetParameterValue("@recomendaciones", registro["recomendaciones"].ToString());
                        reporte.SetParameterValue("@idPermisoAc", registro["idPermisoAcademico"].ToString());
                        reporte.SetParameterValue("@contador", registro["CONTADOR"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MM/yyyy"));
                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}