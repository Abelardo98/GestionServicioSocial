using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using System.IO;

namespace GestionServicioSocial
{
    public partial class UsuarioServicio : System.Web.UI.Page
    {
        DateTime dateTime = DateTime.UtcNow.Date;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userServicio"]== null)
                {
                    Response.Redirect("index.aspx");
                }
                else 
                {
                    txtNc.Text = Session["userServicio"].ToString();
                }
            }
            llenarTablaCalificaciones();
            llenarDatosCalificaciones();
            llenarTabla();
            llenarDatos();
        }
        public void llenarTablaCalificaciones()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numeroControl,solicitudServicio,cartaPresentacion,cartaAceptacion,responsiva,cartaCompromiso,planTrabajo,reporteFinal,cartaLiberacion,constanciaTerminacion from documentosServicio where numeroControl = '" + txtNc.Text + "';", conn);

                    ArrayList lista = new ArrayList();
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
        public void llenarDatosCalificaciones()
        {
            foreach (GridViewRow row in GridView2.Rows)
            {

                solicitud.Text = row.Cells[1].Text;
                presentacion.Text = row.Cells[2].Text;
                aceptacion.Text = row.Cells[3].Text;
                responsivaxd.Text = row.Cells[4].Text;
                compromiso.Text = row.Cells[5].Text;
                trabajo.Text = row.Cells[6].Text;
                final.Text = row.Cells[7].Text;
                liberacion.Text = row.Cells[8].Text;
                terminacion.Text = row.Cells[9].Text;



            }
        }

        public void llenarTabla()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select alu.numerocontrol, nombre, apellidop, apellidom, carrera,semestre,periodo,nombrePrograma from infoEscolar inf join Alumno alu on inf.idescolar = alu.numerocontrol join Programa pro on alu.numerocontrol = pro.idprograma where inf.idescolar = '" + txtNc.Text + "';", conn);

                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }

        public void llenarDatos()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                txtNc.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtnombre.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtAP.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAM.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtCarrera.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtSemestre.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtPeriodo.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
                txtNombreProyecto.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);


            }

        }

        public void actulizarSolicitudResi()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set solicitudServicio=@solicitudServicio where numeroControl=@numeroControl";
                    cmd.Parameters.AddWithValue("@solicitudServicio", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
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
        public void actulizarCartaPresentacion()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set cartaPresentacion=@cartaPresentacion where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@cartaPresentacion", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }
            }
        }
        public void actulizarCartaAceptacion()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set cartaAceptacion=@cartaAceptacion where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@cartaAceptacion", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }
            }
        }
        public void actulizarResponsiva()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set responsiva=@responsiva where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@responsiva", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }
            }
        }
        public void actulizarCartaCompromiso()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set cartaCompromiso=@cartaCompromiso where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@cartaCompromiso", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }
            }
        }              
        public void actulizarReporteFinal()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set reporteFinal=@reporteFinal where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@reporteFinal", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }
            }
        }
        public void actulizarConstanciaTerminacion()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set constanciaTerminacion=@constanciaTerminacion where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@constanciaTerminacion", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "SolicitudServicioSocial-"+NoControl+".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "SolicitudServicioSocial-" + NoControl + ".pdf"));
                        actulizarSolicitudResi();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "SolicitudServicioSocial-" + NoControl + ".pdf"));
                    actulizarSolicitudResi();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }
        protected void acusePresentacion_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload2.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload2.SaveAs(Server.MapPath(ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + NoControl + ".pdf"));
                        actulizarCartaPresentacion();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload2.SaveAs(Server.MapPath(ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + NoControl + ".pdf"));
                    actulizarCartaPresentacion();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }

        protected void cartaAceptacion_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload3.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(ruta + "/" + "CartaAceptaciónServicioSocial-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload3.SaveAs(Server.MapPath(ruta + "/" + "CartaAceptaciónServicioSocial-" + NoControl + ".pdf"));
                        actulizarCartaAceptacion();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload3.SaveAs(Server.MapPath(ruta + "/" + "CartaAceptaciónServicioSocial-" + NoControl + ".pdf"));
                    actulizarCartaAceptacion();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }

        protected void Responsiva_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload4.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(ruta + "/" + "ResponsivaServicioSocial-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload4.SaveAs(Server.MapPath(ruta + "/" + "ResponsivaServicioSocial-" + NoControl + ".pdf"));
                        actulizarResponsiva();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload4.SaveAs(Server.MapPath(ruta + "/" + "ResponsivaServicioSocial-" + NoControl + ".pdf"));
                    actulizarResponsiva();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }

        protected void cartaCompromiso_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload7.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "CartaCompromisoServicioSocial-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload7.SaveAs(Server.MapPath(ruta + "/" + "CartaCompromisoServicioSocial-" + NoControl + ".pdf"));
                        actulizarCartaCompromiso();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload7.SaveAs(Server.MapPath(ruta + "/" + "CartaCompromisoServicioSocial-" + NoControl + ".pdf"));
                    actulizarCartaCompromiso();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }

        protected void reporteFinal_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload5.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "ReporteFinal-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload5.SaveAs(Server.MapPath(ruta + "/" + "ReporteFinal-" + NoControl + ".pdf"));
                        actulizarReporteFinal();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload5.SaveAs(Server.MapPath(ruta + "/" + "ReporteFinal-" + NoControl + ".pdf"));
                    actulizarReporteFinal();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }

        protected void cartaLibre_Click(object sender, EventArgs e)
        {
            Response.Redirect("liberacion.aspx");
        }
        protected void consTerminacion_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload6.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "ContanciaTerminacionServicioSocial-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload6.SaveAs(Server.MapPath(ruta + "/" + "ContanciaTerminacionServicioSocial-" + NoControl + ".pdf"));
                        actulizarConstanciaTerminacion();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload6.SaveAs(Server.MapPath(ruta + "/" + "ContanciaTerminacionServicioSocial-" + NoControl + ".pdf"));
                    actulizarConstanciaTerminacion();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
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
                    SqlCommand consulta = new SqlCommand("select idPrograma,servicioTec from Programa where idPrograma = '" + txtNc.Text + "'; ", conn);


                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                catch (Exception ex)
                {
                }

            }

        }
        public void validarReporte()
        {
            if (GridView1.Rows.Count == 0)
            {


            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {

                    if (row.Cells[1].Text.Equals("SI"))
                    {

                        /*String NC = txtNc.Text;                       
                        Response.Write("<script type='text/javascript'>window.open('ReportePresentacionInterno2.aspx');</script>");*/
                        txtNoti.Text = "si";

                    }
                    else if (row.Cells[1].Text.Equals("NO"))
                    {
                        String NC = txtNc.Text;                        
                        Response.Write("<script type='text/javascript'>window.open('ReportePresentacion2.aspx');</script>");
                    }
                    else
                    {




                    }

                }
            }

        }
        protected void planTrabajo_Click(object sender, EventArgs e)
        {
            //Response.Redirect("planTrabajo.aspx");
            Server.Transfer("planTrabajo.aspx");
        }
        protected void generarCarta_Click(object sender, EventArgs e)
        {
            llenarDatosR();
            validarReporte();
            if (txtNoti.Text.Equals("si"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);
            }
        }
        protected void generarSolicitud_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'>window.open('ReporteSolicitud2.aspx');</script>");
        }
        protected void subirReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportesxd.aspx");
        }

        protected void BtnGenerarConstanciaTerminacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReporteConstanciaTerminacion2.aspx");
        }

        protected void descargar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            string documento = DropDownList1.SelectedItem.Value;
            if (documento.Equals("servicioSocial"))
            {
                string rutaArchivo = ruta + "/" + "SolicitudServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=SolicitudServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe documento')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("presentacion"))
            {
                string rutaArchivo = ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaPresentaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //descarminar.Text = "El Directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("cartaAceptación"))
            {
                string rutaArchivo = ruta + "/" + "CartaAceptaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaAceptaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //descarminar.Text = "El Directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe directorio')", true);
                }
            }
            else if (documento.Equals("responsiva"))
            {
                string rutaArchivo = ruta + "/" + "ResponsivaServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ResponsivaServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El Directorio no existe')", true);
                    //descarminar.Text = "";
                }
            }
            else if (documento.Equals("compromiso"))
            {
                string rutaArchivo = ruta + "/" + "CartaCompromisoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaCompromisoServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("planTrabajo"))
            {
                string rutaArchivo = ruta + "/" + "PlanTrabajoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=PlanTrabajoServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 1"))
            {
                string rutaArchivo = ruta + "/" + "Reporte1-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte1-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 2"))
            {
                string rutaArchivo = ruta + "/" + "Reporte2-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte2-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 3"))
            {
                string rutaArchivo = ruta + "/" + "Reporte3-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte3-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 4"))
            {
                string rutaArchivo = ruta + "/" + "Reporte4-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte4-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 5"))
            {
                string rutaArchivo = ruta + "/" + "Reporte5-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte5-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Evaluaciones finales"))
            {
                string rutaArchivo = ruta + "/" + "EvaluaciónFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=EvaluaciónFinal-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("rFinal"))
            {
                string rutaArchivo = ruta + "/" + "ReporteFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ReporteFinal-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("liberacion"))
            {
                string rutaArchivo = ruta + "/" + "ContanciaLiberaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ContanciaLiberaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
            else if(documento.Equals("Constancia de terminación"))
            {
                string rutaArchivo = ruta + "/" + "ContanciaTerminacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ContanciaTerminacionServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //descarminar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe directorio')", true);
                    //descarminar.Text = "El Directorio no existe";
                }
            }
        }

        protected void BtnCerraSesion_Click(object sender, EventArgs e)
        {
            Response.Write("<script>self.close();</script>");
        }
        protected void eliminar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            string documento = DropDownList1.SelectedItem.Value;
            if (documento.Equals("servicioSocial"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "SolicitudServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("presentacion"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("cartaAceptación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaAceptaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("responsiva"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ResponsivaServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("compromiso"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaCompromisoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("planTrabajo"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "PlanTrabajoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 1"))
            {
                string rutaArchivo = ruta + "/" + "Reporte1-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 2"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte2-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 3"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte3-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 4"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte4-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Reporte 5"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Reporte5-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Evaluaciones finales"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "EvaluaciónFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("rFinal"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ReporteFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("liberacion"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ContanciaLiberaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Constancia de terminación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ContanciaTerminacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarminar.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarminar.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarminar.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else
            {
                descarminar.Text = "error";
            }
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("userServicio");
            Response.Redirect("index.aspx");
        }

        protected void BtnEditarInformacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarServicoAlumno.aspx?parametro=" + txtNc.Text);
        }
    }
}