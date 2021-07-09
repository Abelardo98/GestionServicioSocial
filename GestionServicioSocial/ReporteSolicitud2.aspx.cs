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
    public partial class ReporteSolicitud2 : System.Web.UI.Page
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
                    string cadena = "select nombre,apellidop,apellidom,genero,edad,estadocivil,calle,localidad,municipio,estado,codigopostal,telefono,correoelectronico,alu.numerocontrol,carrera,periodo, semestre,creditosAprovados,inscrito,nombredependencia,nombretitular,puestotitular,areaalumno,nombreacesor,puestoacesor,nombreprograma,programaactividad,tipoprograma,inf.modalidad from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar='" + txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        informeSolicitud reporte = new informeSolicitud();
                        reporte.SetParameterValue("@nombre", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoP", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoM", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@genero", registro["genero"].ToString());
                        reporte.SetParameterValue("@edad", registro["edad"].ToString());
                        reporte.SetParameterValue("@estadocivil", registro["estadocivil"].ToString());
                        reporte.SetParameterValue("@calle", registro["calle"].ToString());
                        reporte.SetParameterValue("@localidad", registro["localidad"].ToString());
                        reporte.SetParameterValue("@municipio", registro["municipio"].ToString());
                        reporte.SetParameterValue("@estado", registro["estado"].ToString());
                        reporte.SetParameterValue("@codigoPostal", registro["codigoPostal"].ToString());
                        reporte.SetParameterValue("@telefono", registro["telefono"].ToString());
                        reporte.SetParameterValue("@correoElectronico", registro["correoElectronico"].ToString());
                        reporte.SetParameterValue("@numeroControl", registro["numeroControl"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@periodo", registro["periodo"].ToString());
                        reporte.SetParameterValue("@semestre", registro["semestre"].ToString());
                        reporte.SetParameterValue("@creditosAprovados", registro["creditosAprovados"].ToString());
                        reporte.SetParameterValue("@inscrito", registro["inscrito"].ToString());
                        reporte.SetParameterValue("@nombredependencia", registro["nombredependencia"].ToString());
                        reporte.SetParameterValue("@nombreTitular", registro["nombreTitular"].ToString());
                        reporte.SetParameterValue("@puestoTitular", registro["puestoTitular"].ToString());
                        reporte.SetParameterValue("@areaAlumno", registro["areaAlumno"].ToString());
                        reporte.SetParameterValue("@nombreAcesor", registro["nombreAcesor"].ToString());
                        reporte.SetParameterValue("@puestoAcesor", registro["puestoAcesor"].ToString());
                        reporte.SetParameterValue("@nombrePrograma", registro["nombrePrograma"].ToString());
                        reporte.SetParameterValue("@programaActividad", registro["programaActividad"].ToString());
                        reporte.SetParameterValue("@tipoPrograma", registro["tipoPrograma"].ToString());
                        reporte.SetParameterValue("@modalidad", registro["modalidad"].ToString());
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MM/yyyy"));
                        //mensaje.Text = registro["nombre"].ToString();
                        CrystalReportViewer1.ReportSource = reporte;
                    }
                }
                catch (Exception e)
                {
                    txtNumeroControl.Text = e.StackTrace;
                }
            }
        }
    }
}