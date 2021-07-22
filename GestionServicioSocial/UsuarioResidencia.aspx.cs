using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace GestionServicioSocial
{
    public partial class UsuarioResidencia : System.Web.UI.Page
    {
        DateTime dateTime = DateTime.UtcNow.Date;
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
                    txtNc.Text = Session["userResidencia"].ToString();
                }

            }
            llenarTablaCalificaciones();
            llenarDatosCalificaciones();

            if (!IsPostBack) 
            {
                
                llenarTabla();
                llenarDatos();
                llenarTablaCalificaciones();
                llenarDatosCalificaciones();
            }
            
        }

        public void llenarTablaCalificaciones() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select * from documentosReci where numeroControl = '" + txtNc.Text + "';", conn);

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

        public void llenarDatosCalificaciones() {
            foreach (GridViewRow row in GridView2.Rows)
            {

                solicitud.Text = row.Cells[1].Text;
                presentacion.Text = row.Cells[2].Text;
                aceptacion.Text = row.Cells[3].Text;
                responsiva.Text = row.Cells[4].Text;
                liberacion.Text = row.Cells[5].Text;
                cumplimiento.Text = row.Cells[6].Text;
                


            }
        }

        public void llenarTabla() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select alu.numerocontrol, nombre, apellidop, apellidom, carrera,semestre,periodo,nombreProyecto from infoEscolarReci inf join AlumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma where inf.idescolar = '" + txtNc.Text + "';", conn);

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

                txtNc.Text = row.Cells[0].Text;
                txtnombre.Text = row.Cells[1].Text;
                txtAP.Text = row.Cells[2].Text;
                txtAM.Text = row.Cells[3].Text;
                txtCarrera.Text = row.Cells[4].Text;
                txtSemestre.Text = row.Cells[5].Text;
                txtPeriodo.Text = row.Cells[6].Text;
                txtNombreProyecto.Text = row.Cells[7].Text;


                }
            
        }


        public void subirSolicitud() {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "SolicitudResidencia-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archivo ya existe')", true);
                        //solicitud.Text = "Este archivo ya existe!";
                    }
                    else
                    {


                        //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "SolicitudResidencia-" + NoControl + ".pdf"));
                        actulizarSolicitudResi();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                        //solicitud.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "SolicitudResidencia-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    actulizarSolicitudResi();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                    //solicitud.Text = "Subido con éxito";
                }
            }
            else
            {
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //solicitud.Text = "Selecciona un archivo primero";
            }

        }
        protected void BtnSubirSolicitud_Click1(object sender, EventArgs e)
        {           
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select * from documentosReci where numeroControl='" + txtNc.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        subirSolicitud();
                    }
                    else
                    {
                        insertarDocumentoReci();
                        subirSolicitud();
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
                }
            }
        }
        public void insertarDocumentoReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarDocumentoReci";
                    cmd.Parameters.Add("@numeroControl", SqlDbType.VarChar).Value = txtNc.Text.Trim();
                    cmd.Parameters.Add("@solicitudRecidencia", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaPresentacion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaAceptacion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@responsiva", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaLiveracion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@constanciaCumplimiento", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    solicitud.Text = ex.Message.ToString();
                }
            }
        }

        public void actulizarSolicitudResi() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
   
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosReci set solicitudRecidencia=@solicitudRecidencia where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@solicitudRecidencia", dateTime.ToString("dd/MM/yyyy"));
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
        public void actulizarCartaPresentacion()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosReci set cartaPresentacion=@cartaPresentacion where numeroControl=@numeroControl";

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
        public void actulizararCartaAceptacion()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosReci set cartaAceptacion=@cartaAceptacion where numeroControl=@numeroControl";

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
                    cmd.CommandText = "update documentosReci set responsiva=@responsiva where numeroControl=@numeroControl";

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
        public void actulizarCartaLiveracion()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosReci set cartaLiveracio=@cartaLiveracio where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@cartaLiveracio", dateTime.ToString("dd/MM/yyyy"));
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
        public void actulizarConstanciaCumplimiento()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosReci set constanciaCumplimiento=@constanciaCumplimiento where numeroControl=@numeroControl";

                    cmd.Parameters.AddWithValue("@constanciaCumplimiento", dateTime.ToString("dd/MM/yyyy"));
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


        public void subirAceptacionRP() {

            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload3.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "CartaAceptación-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archivo ya existe')", true);
                        //aceptacion.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        FileUpload3.SaveAs(Server.MapPath(ruta + "/" + "CartaAceptación-" + NoControl + ".pdf"));
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        actulizararCartaAceptacion();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con exito')", true);
                        //aceptacion.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload3.SaveAs(Server.MapPath(ruta + "/" + "CartaAceptación-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    actulizararCartaAceptacion();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con exito')", true);
                    //aceptacion.Text = "Subido con éxito";
                }
            }
            else
            {
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //aceptacion.Text = "Selecciona un archivo primero";
            }

        }
        protected void BTNSubirAceptacionRP_Click(object sender, EventArgs e)
        {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select * from documentosReci where numeroControl='" + txtNc.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        subirAceptacionRP();
                    }
                    else
                    {
                        insertarDocumentoReci();
                        subirAceptacionRP();
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
                }
            }
        }

        public void subirResponsiva() {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload4.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "Responsiva-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archivo ya existe')", true);
                        //responsiva.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        FileUpload4.SaveAs(Server.MapPath(ruta + "/" + "Responsiva-" + NoControl + ".pdf"));
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        actulizarResponsiva();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                        //responsiva.Text = "Subida con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload4.SaveAs(Server.MapPath(ruta + "/" + "Responsiva-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    actulizarResponsiva();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                    //responsiva.Text = "Subida con éxito";
                }
            }
            else
            {
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //responsiva.Text = "Selecciona un archivo primero";
            }

        }
        protected void BTNSubirResponsiva_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select * from documentosReci where numeroControl='" + txtNc.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        subirResponsiva();
                    }
                    else
                    {
                        insertarDocumentoReci();
                        subirResponsiva();
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
                }
            }
        }

        public void subirLiberacion() {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload5.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "CartaLiberación-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archivo ya existe')", true);
                        //liberacion.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        FileUpload5.SaveAs(Server.MapPath(ruta + "/" + "CartaLiberación-" + NoControl + ".pdf"));
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        actulizarCartaLiveracion();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                        //liberacion.Text = "Subida con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload5.SaveAs(Server.MapPath(ruta + "/" + "CartaLiberación-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    actulizarCartaLiveracion();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                    //liberacion.Text = "Subida con éxito";
                }
            }
            else
            {
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //liberacion.Text = "Selecciona un archivo primero";
            }
        }
        protected void BtnSubirLiberacion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select * from documentosReci where numeroControl='" + txtNc.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        subirLiberacion();
                    }
                    else
                    {
                        insertarDocumentoReci();
                        subirLiberacion();
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
                }
            }
        }

        public void subirCumplimiento() {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload6.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "ConstanciaCumplimiento-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archivo ya existe')", true);
                        //cumplimiento.Text = "Este archivo ya existe!";
                    }
                    else
                    {


                        FileUpload6.SaveAs(Server.MapPath(ruta + "/" + "ConstanciaCumplimiento-" + NoControl + ".pdf"));
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        actulizarConstanciaCumplimiento();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                        //cumplimiento.Text = "Subida con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload6.SaveAs(Server.MapPath(ruta + "/" + "ConstanciaCumplimiento-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    actulizarConstanciaCumplimiento();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                    //cumplimiento.Text = "Subida con éxito";
                }
            }
            else
            {
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //cumplimiento.Text = "Selecciona un archivo primero";
            }
        }
        protected void BtnSubirCumplimiento_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select * from documentosReci where numeroControl='" + txtNc.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        subirCumplimiento();
                    }
                    else
                    {
                        insertarDocumentoReci();
                        subirCumplimiento();
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
                }
            }
        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            string documento = DropDownList1.SelectedItem.Text;
            if (documento.Equals("Solicitud Residencia"))
            {
                string rutaArchivo = ruta + "/" + "SolicitudResidencia-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=SolicitudResidencia-"+nc+ ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe documento')", true);
                        //descarga.Text = "No existe documento";
                    }
                }
                else
                {
                    //BtnDescargar.Text = "El Directorio no existe";
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Carta presentación"))
            {
                string rutaArchivo = ruta + "/" + "CartaPresentación-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaPresentación-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        //descarga.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //BtnDescargar.Text = "El Directorio no existe";
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Carta aceptación"))
            {
                string rutaArchivo = ruta + "/" + "CartaAceptación-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaAceptación-"+ nc +".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        //descarga.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //BtnDescargar.Text = "El Directorio no existe";
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe directorio')", true);
                }
            }
            else if (documento.Equals("Responsiva"))
            {
                string rutaArchivo = ruta + "/" + "Responsiva-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Responsiva-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        //descarga.Text = "No existe archvo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                    //BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Carta liberación"))
            {
                string rutaArchivo = ruta + "/" + "CartaLiberación-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaLiberación-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        //descarga.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //descarga.Text = "El Directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Directorio no existe')", true);
                    //BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else
            {
                string rutaArchivo = ruta + "/" + "ConstanciaCumplimiento-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ConstanciaCumplimiento-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        //descarga.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Directorio no existe')", true);
                    //BtnDescargar.Text = "El Directorio no existe";
                }
            }
        }

        public void subirCartaPrecentacion() {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload2.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "CartaPresentación-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archivo ya existe')", true);
                        //presentacion.Text = "Este archivo ya existe";
                    }
                    else
                    {


                        FileUpload2.SaveAs(Server.MapPath(ruta + "/" + "CartaPresentación-" + NoControl + ".pdf"));
                        //BtnSubirSolicitud.Text = "Subido con éxito";
                        actulizarCartaPresentacion();
                        llenarTablaCalificaciones();
                        llenarDatosCalificaciones();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con exito')", true);
                        //presentacion.Text = "Subido con éxito";
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    FileUpload2.SaveAs(Server.MapPath(ruta + "/" + "CartaPresentación-" + NoControl + ".pdf"));
                    //BtnSubirSolicitud.Text = "Subida con éxito";
                    actulizarCartaPresentacion();
                    llenarTablaCalificaciones();
                    llenarDatosCalificaciones();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con éxito')", true);
                    //presentacion.Text = "Subido con éxito";
                }
            }
            else
            {
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //presentacion.Text = "Selecciona un archivo primero";
            }

        }
        protected void BtnSubirPrecentacion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select * from documentosReci where numeroControl='" + txtNc.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        subirCartaPrecentacion();
                    }
                    else
                    {
                        insertarDocumentoReci();
                        subirCartaPrecentacion();
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
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

                        String NC = txtNc.Text;
                        Response.Write("<script type='text/javascript'>window.open('ReportePrecentacionResidenciaInterno2.aspx?');</script>");


                    }
                    else if (row.Cells[1].Text.Equals("NO"))
                    {
                        String NC = txtNc.Text;
                        Response.Write("<script type='text/javascript'>window.open('ReportePrecentacionResidencia2.aspx');</script>");
                    }
                    else
                    {




                    }

                }
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
                    SqlCommand consulta = new SqlCommand("select idPrograma,recidenciaTec from ProgramaReci where idPrograma = '" + txtNc.Text + "'; ", conn);


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
        protected void BtnSolicitud_Click(object sender, EventArgs e)
        {
            String NC = txtNc.Text;
            Response.Write("<script type='text/javascript'>window.open('ReporteSolicitudRecidencia2.aspx');</script>");
            
        }

        protected void BtnPrecentacion_Click(object sender, EventArgs e)
        {
            llenarDatosR();
            validarReporte();
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("userResidencia");
            Response.Redirect("index.aspx");
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            //"~/16XX00N"
            string documento = DropDownList1.SelectedItem.Value;
            if (documento.Equals("Solicitud Residencia"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "SolicitudResidencia-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //Label1.Text = "Archivo aun existe";
                            //descarga.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //Label1.Text = "Archivo Eliminado";
                            //descarga.Text = "Archivo eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //Label1.Text = "El archivo no existe";
                        //descarga.Text = "El archivo no existe!";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    // Label1.Text = "El directorio no existe";
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("Carta presentación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaPresentación-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //Label1.Text = "Archivo aun existe";
                            //descarga.Text = "Aun existe archivo";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //Label1.Text = "Archivo Eliminado";
                            //descarga.Text = "Archivo eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //Label1.Text = "El archivo no existe";
                        //descarga.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    // Label1.Text = "El directorio no existe";
                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }

            else if (documento.Equals("Carta aceptación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaAceptación-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarga.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarga.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarga.Text = "El archivo no existe";
                         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }

            else if (documento.Equals("Responsiva"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "Responsiva-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarga.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarga.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarga.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }

            else if (documento.Equals("Carta liberación"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "CartaLiberación-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarga.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarga.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarga.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }

            else if (documento.Equals("Constancia cumplimiento"))
            {
                //Label1.Text = "Entro";
                string rutaArchivo = ruta + "/" + "ConstanciaCumplimiento-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //Label1.Text = "Existe";
                        File.Delete(MapPath(rutaArchivo));
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //descarga.Text = "Archivo aun existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo aun existente')", true);
                        }
                        else
                        {
                            //descarga.Text = "Archivo Eliminado";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
                        }
                    }
                    else
                    {
                        //descarga.Text = "El archivo no existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El archivo no existe')", true);
                    }
                }
                else
                {

                    //descarga.Text = "El directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }

            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error')", true);
                //descarga.Text = "error";
            }

        }

        protected void BtnEditarInformacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarResidenciaAlumno.aspx?parametro=" + txtNc.Text);
        }
    }
}