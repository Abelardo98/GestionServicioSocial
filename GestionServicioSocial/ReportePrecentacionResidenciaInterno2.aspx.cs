﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GestionServicioSocial
{
    public partial class ReportePrecentacionResidenciaInterno2 : System.Web.UI.Page
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
                    string cadena = "SELECT alu.numerocontrol,nombre,apellidoP,apellidoM,carrera, seguroFacultativo, nombreAcesor, " +
                        "puestoAcesor,nombreTitular,puestoTitular,razonSocial,nombreAcesor,puestoAcesor,contador from infoEscolarReci" +
                        " inf join AlumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol=pro.idPrograma" +
                        " where alu.numerocontrol='" + txtNumeroControl.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        informePrecentacionRecidenciaInterno2 reporte = new informePrecentacionRecidenciaInterno2();
                        reporte.SetParameterValue("@nombreTitular", registro["nombreTitular"].ToString());
                        reporte.SetParameterValue("@puestoTitular", registro["puestoTitular"].ToString());
                        reporte.SetParameterValue("@dependencia", registro["razonSocial"].ToString());
                        reporte.SetParameterValue("@nombreAlumno", registro["nombre"].ToString());
                        reporte.SetParameterValue("@apellidoP", registro["apellidoP"].ToString());
                        reporte.SetParameterValue("@apellidoM", registro["apellidoM"].ToString());
                        reporte.SetParameterValue("@carrera", registro["carrera"].ToString());
                        reporte.SetParameterValue("@numeroControl", registro["numerocontrol"].ToString());
                        reporte.SetParameterValue("@imss", registro["seguroFacultativo"].ToString());
                        reporte.SetParameterValue("@contador", registro["contador"].ToString());
                        reporte.SetParameterValue("@puestoAsesor", registro["puestoAcesor"]);
                        reporte.SetParameterValue("@nombreAsesor", registro["nombreAcesor"]);
                        reporte.SetParameterValue("@fecha", dateTime.ToString("dd/MMMM/yyyy"));
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