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
    public partial class CostanciaTerminacionDatosFinales : System.Web.UI.Page
    {

        DataTable dt;
        SqlDataAdapter da;
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
                    llenarTabla();
                    llenarDatos();
                }
            }
        }
        public void llenarTabla()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    //  da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\",calle as \"Calle\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\", nombreacesor as \"Nombre Asesor\", puestoacesor as \"Puesto Asesor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\", modalidad as \"Madalidad\", fechainicio as \"Fecha Inicio\", fechatermi as \"Fecha Termino\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtbuscar.Text + "'; ", conn);
                    da = new SqlDataAdapter("select contadorIngresado,diaTerminacion,mesTerminacion,anioTerminacion,horasServicio,municipioDependencia,estadoDependencia from Alumno join Programa on Alumno.numerocontrol=Programa.idPrograma where Alumno.numerocontrol= '" + txtNumeroControl.Text + "'; ", conn);

                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {
                    txtNumeroControl.Text = ex.Message;
                }

            }

        }

        public void llenarDatos()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                txtNumeroOficio.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtDia.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtMes.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAnio.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtHorasServicio.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtMunicipioDependencia.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtEstadoDependencia.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);

            }

        }
        public void actualizarAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update documentosServicio set reporte1=@reporte1 where numeroControl=@numeroControl";
                    cmd.CommandText = "update Alumno set contadorIngresado=@contadorIngresado,diaTerminacion=@diaTerminacion,mesTerminacion=@mesTerminacion,anioTerminacion=@anioTerminacion,horasServicio=@horasServicio where numerocontrol=@numerocontrol";
                    cmd.Parameters.AddWithValue("@numerocontrol", txtNumeroControl.Text);
                    cmd.Parameters.AddWithValue("@contadorIngresado", txtNumeroOficio.Text);
                    cmd.Parameters.AddWithValue("@diaTerminacion", txtDia.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@mesTerminacion", txtMes.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@anioTerminacion", txtAnio.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@horasServicio", txtHorasServicio.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtNumeroControl.Text = ex.Message;
                }
            }
        }
        
        public void actualizarPrograma()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update Programa set municipioDependencia=@municipioDependencia,estadoDependencia=@estadoDependencia where idPrograma=@idPrograma";
                    cmd.Parameters.AddWithValue("@idPrograma", txtNumeroControl.Text);
                    cmd.Parameters.AddWithValue("@municipioDependencia", txtMunicipioDependencia.Text);
                    cmd.Parameters.AddWithValue("@estadoDependencia",txtEstadoDependencia.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtNumeroControl.Text = ex.Message;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            actualizarAlumno();
            actualizarPrograma();

            String NC = txtNumeroControl.Text;
            Session["userServicio"] = NC;
            Response.Redirect("ReporteConstanciaTerminacion2.aspx");
            //Response.Write("<script type='text/javascript'>window.open('ReporteConstanciaTerminacion2.aspx');</script>");

        }

        

    }
}