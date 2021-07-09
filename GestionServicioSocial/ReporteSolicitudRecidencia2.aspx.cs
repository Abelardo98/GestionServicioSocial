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
    public partial class ReporteSolicitudRecidencia2 : System.Web.UI.Page
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
                    numeroControl.Text = Session["userResidencia"].ToString();
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
                    string cadena = "select alu.numerocontrol ,nombre,apellidop ,apellidom ,contraseña,edad,genero,estadocivil,correoelectronico, carrera, semestre, periodo, inscrito, seguroFacultativo ,inf.modalidad Modalidad,creditosAprovados, localidad,calle, codigopostal,municipio, estado, telefono, razonSocial,tipo, nombretitular, puestotitular ,areaalumno, nombreacesor, puestoacesor,correoAcesor, nombreProyecto,recidenciaTec, fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss where inf.idescolar='"+ numeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {   

                        DateTime dateTime = DateTime.UtcNow.Date;                        
                        InformeSolicitudResidencia reporte = new InformeSolicitudResidencia();
                        reporte.SetParameterValue("@nombreAl", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoP", registro["apellidop"].ToString());
                        reporte.SetParameterValue("@apellidoM", registro["apellidom"].ToString());
                        reporte.SetParameterValue("@sexoAl", registro["genero"].ToString());
                        reporte.SetParameterValue("@edadAl", registro["edad"].ToString());
                        reporte.SetParameterValue("@edocivilAl", registro["estadocivil"].ToString());
                        reporte.SetParameterValue("@domicilio", registro["calle"].ToString());
                        reporte.SetParameterValue("@Localidad", registro["localidad"].ToString());
                        reporte.SetParameterValue("@municipio", registro["municipio"].ToString());
                        reporte.SetParameterValue("@estado", registro["estado"].ToString());
                        reporte.SetParameterValue("@cp", registro["codigopostal"].ToString());
                        reporte.SetParameterValue("@telefono", registro["telefono"].ToString());
                        reporte.SetParameterValue("@correo", registro["correoelectronico"].ToString());
                        reporte.SetParameterValue("@noControl", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@periodo", registro["periodo"].ToString());
                        reporte.SetParameterValue("@semestre", registro["semestre"].ToString());
                        reporte.SetParameterValue("@creditosAprov", registro["creditosAprovados"].ToString());
                        reporte.SetParameterValue("@inscrito", registro["inscrito"].ToString());
                        reporte.SetParameterValue("@nimss", registro["seguroFacultativo"].ToString());
                        reporte.SetParameterValue("@razonSocial", registro["razonSocial"].ToString());
                        reporte.SetParameterValue("@tipoDependencia", registro["tipo"].ToString());
                        reporte.SetParameterValue("@nombreTitularDep", registro["nombretitular"].ToString());
                        reporte.SetParameterValue("@puestoTitularDep", registro["puestotitular"].ToString());
                        reporte.SetParameterValue("@areaResidente", registro["areaalumno"].ToString());
                        reporte.SetParameterValue("@nombreAsesorEx", registro["nombreacesor"].ToString());
                        reporte.SetParameterValue("@puestoAsesorExterno", registro["puestoacesor"].ToString());
                        reporte.SetParameterValue("@correoAsesorExterno", registro["correoAcesor"].ToString());
                        reporte.SetParameterValue("@nombreProyecto", registro["nombreProyecto"].ToString());
                        reporte.SetParameterValue("@modalidad", registro["Modalidad"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MM/yyyy"));
                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch(Exception e) 
                {
                    mensajeError.Text = e.StackTrace;
                }
            }
        }
    }
}