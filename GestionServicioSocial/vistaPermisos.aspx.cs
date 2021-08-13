using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace GestionServicioSocial
{
    public partial class vistaPermisos : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["userAdmin"] == null) 
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void BtnVerRegistros_Click(object sender, EventArgs e)
        {
            busquedaGeneral();
        }

        public void busquedaGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    da = new SqlDataAdapter("select pd.CONTADOR as \"Contador\",visitaPractica as \"Visita Y Practica\",visitaIndustrial as \"Visita\",practica as \"Práctica\",docenteResponsable as \"Docente Responsable\",numCelularDocente as \"Numero Celular Docente\",CorreoElectronicoDocente as \"Correo Electrónico Docente\",materia as \"Materia\",semestre as \"Semestre\",grupo as \"Grupo\",alumnosProgramados as \"Alumnos Programados\",especialidad as \"Especialidad\",objetivo as \"Objetivo\",practicaDescripcion as \"Descripción Practica\",nombreInstitucion \"Nombre Institución\",representante as \"Representante\",puestoOcargo as \"Puesto Ó Cargo\",direccion as \"Dirección\",municipioEstado as \"Municipio/Estado\",telefonoOrganizacion as \"Teléfono Organización\",fax as \"Fax\",email as \"Email\",paginaWeb as \"Pagina Web\",fechaVisita as \"Fecha Propuesta Visita\",horaPropuesta as \"Hora Propuesta Visita\",recomendaciones as \"Recomendaciones\" from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso; ", conn);

                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {
                    txtNumerocontrol.Text = ex.Message;
                }

            }
        }

        public void eliminarDatosAcademicos()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDatosAcademicos";
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {

                }

            }

        }

        public void eliminarDatosEmpresa()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDatosEmpresa";
                    cmd.Parameters.Add("@idPermiso", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {

                }

            }

        }

        protected void BTN_Eliminar_Click(object sender, EventArgs e)
        {
            
            eliminarDatosEmpresa();
            eliminarDatosAcademicos();
            busquedaGeneral();
        }

        protected void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
           // Response.Redirect("ReportePermisos.aspx?parametro=" + txtNumerocontrol.Text);
            Response.Write("<script type='text/javascript'>window.open('ReportePermisos.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx");
        }

        protected void BTNeditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPermisos.aspx?parametro=" + txtNumerocontrol.Text);
        }

        protected void BTNCaraPresentacion_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CartaPrecentacionPermisos.aspx?parametro=" + txtNumerocontrol.Text);
            //Response.Write("<script type='text/javascript'>window.open('CartaPrecentacionPermisos.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");
            llenarDatosR();
            validarReporte();
        }
        public void llenarDatosR()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select visitaPractica,visitaIndustrial,practica from permisosDatosAcademicos where CONTADOR = '" + txtNumerocontrol.Text + "'; ", conn);


                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView2.DataSource = dt;
                    GridView2.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }
        public void validarReporte()
        {
            if (GridView2.Rows.Count == 0)
            {


            }
            else
            {
                foreach (GridViewRow row in GridView2.Rows)
                {

                    if (row.Cells[0].Text.Equals("Virtual") || row.Cells[0].Text.Equals("Presencial"))
                    {
                        Response.Write("<script type='text/javascript'>window.open('presentacionPermisos.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");
                        
                    }
                    else if (row.Cells[1].Text.Equals("Virtual") || row.Cells[1].Text.Equals("Presencial"))
                    {
                        
                        Response.Write("<script type='text/javascript'>window.open('presentacionPermiso2.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");

                    }
                    else if (row.Cells[2].Text.Equals("Virtual") || row.Cells[2].Text.Equals("Presencial"))
                    {
                        
                        Response.Write("<script type='text/javascript'>window.open('presentacionPermiso3.aspx?parametro=" + txtNumerocontrol.Text + "');</script>");

                    }
                    else
                    {


                        txtNumerocontrol.Text = "Entro al else";
                        
                    }

                }
            }

        }

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    da = new SqlDataAdapter("select pd.CONTADOR as \"Contador\",visitaPractica as \"Visita Y Practica\",visitaIndustrial as \"Visita\",practica as \"Práctica\",docenteResponsable as \"Docente Responsable\",numCelularDocente as \"Numero Celular Docente\",CorreoElectronicoDocente as \"Correo Electrónico Docente\",materia as \"Materia\",semestre as \"Semestre\",grupo as \"Grupo\",alumnosProgramados as \"Alumnos Programados\",especialidad as \"Especialidad\",objetivo as \"Objetivo\",practicaDescripcion as \"Descripción Practica\",nombreInstitucion \"Nombre Institución\",representante as \"Representante\",puestoOcargo as \"Puesto Ó Cargo\",direccion as \"Dirección\",municipioEstado as \"Municipio/Estado\",telefonoOrganizacion as \"Teléfono Organización\",fax as \"Fax\",email as \"Email\",paginaWeb as \"Pagina Web\",fechaVisita as \"Fecha Propuesta Visita\",horaPropuesta as \"Hora Propuesta Visita\",recomendaciones as \"Recomendaciones\" from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso where pd.CONTADOR='" + txtNumerocontrol.Text + "'", conn);

                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    txtNumerocontrol.Text = ex.Message;
                }

            }
        }

        protected void BtnSeervicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }

        protected void BtnRecidencia_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaRecidencia.aspx");
        }

        protected void BtnPermisos_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaPermisos.aspx");
        }

        public void cargarDatos(string ruta)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    try
                    {
                        /*var bulkCopy = new SqlBulkCopy(conn);
                        bulkCopy.*/
                        string cadenax = "BULK INSERT docentes FROM '" + ruta + "' WITH(FIELDTERMINATOR = ';', ROWTERMINATOR = '\n')";
                        SqlCommand cmd = new SqlCommand(cadenax, conn);
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        txtNumerocontrol.Text = ex.Message;
                    }
                }

            }
        }

        protected void cargarBase_Click(object sender, EventArgs e)
        {
            string ruta1 = "";
            string ruta = "~/" + "CargaArchivos";

            //Label1.Text = ruta;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "cargaDatosUsuario.csv")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        //ruta1 = Server.MapPath(ruta + "/" + "cargaDatos.csv");

                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        ruta1 = Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv");
                        cargarDatos(ruta1);
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath(ruta));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv"));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con exito')", true);
                    ruta1 = Server.MapPath(ruta + "/" + "cargaDatosUsuario.csv");
                    cargarDatos(ruta1);
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userAdmin");
            Response.Redirect("index.aspx");
        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("http://cartaprovisionalitsz.access.ly/vista.aspx");
        }
    }
}