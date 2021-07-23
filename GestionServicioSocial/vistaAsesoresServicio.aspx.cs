using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class vistaAsesoresServicio : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userJefe"] == null)
                {
                    Response.Redirect("index.aspx");
                }

            }
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
                    SqlCommand consulta = new SqlCommand("select numeroControl as \"N.C\",solicitudServicio as \"Solicitud de Servicio Social\",cartaPresentacion as \"Carta de Presentación\",cartaAceptacion as \"Carta de Aceptación\",responsiva as \"Responsiva\",cartaCompromiso as \"Carta Compromiso\",planTrabajo as \"Plan de Trabajo\",reporte1 as \"Reporte 1\",reporte2 as \"Reporte 2\",reporte3 as \"Reporte 3\",reporte4 as \"Reporte 4\",reporte5 as \"Reporte 5\",evaluacionFinal as \"Evaluación Final\",reporteFinal as \"Reporte Final\",cartaLiberacion as \"Carta de liberación\",constanciaTerminacion as \"Constancia de Terminación\" from documentosServicio where numeroControl = '" + txtNumerocontrol.Text + "';", conn);


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
        public void llenarTablaCalificacionesGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numeroControl as \"N.C\",solicitudServicio as \"Solicitud de Servicio Social\",cartaPresentacion as \"Carta de Presentación\",cartaAceptacion as \"Carta de Aceptación\",responsiva as \"Responsiva\",cartaCompromiso as \"Carta Compromiso\",planTrabajo as \"Plan de Trabajo\",reporte1 as \"Reporte 1\",reporte2 as \"Reporte 2\",reporte3 as \"Reporte 3\",reporte4 as \"Reporte 4\",reporte5 as \"Reporte 5\",evaluacionFinal as \"Evaluación Final\",reporteFinal as \"Reporte Final\",cartaLiberacion as \"Carta de liberación\",constanciaTerminacion as \"Constancia de Terminación\" from documentosServicio where carrera = '" + txtCarreras.Text.ToString() + "';", conn);


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


        public void busquedaIndividual()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre dependencia\", nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre asesor\", puestoacesor as \"Puesto asesor\", nombreprograma as \"Nombre programa\", programaactividad as \"Programa actividad\",tipoprograma as \"Tipo programa\",servicioTec as \"Servicio tec\",fechaInicioServ as \"Fecha inicio del servicio \",fechaTerminoServ as \"Fecha terminación del servicio\",correoAsesorExterno as \"Correo asesor externo\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtNumerocontrol.Text + "'; ", conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {

                }

            }

        }
        public void busquedaGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre dependencia\", nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre asesor\", puestoacesor as \"Puesto asesor\", nombreprograma as \"Nombre programa\", programaactividad as \"Programa actividad\",tipoprograma as \"Tipo programa\",servicioTec as \"Servicio tec\",fechaInicioServ as \"Fecha inicio del servicio \",fechaTerminoServ as \"Fecha terminación del servicio\",correoAsesorExterno as \"Correo asesor externo\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where carrera = '" + txtCarreras.Text.ToString() + "';", conn);
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

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            busquedaIndividual();
            llenarTablaCalificaciones();
        }

        protected void BtnVerRegistros_Click(object sender, EventArgs e)
        {
            busquedaGeneral();
            llenarTablaCalificacionesGeneral();
        }

        protected void BtnResidencia_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaAsesoresResicencia.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userJefe");
            Response.Redirect("index.aspx");
        }

        protected void descargarRegistros_Click(object sender, EventArgs e)
        {
            string ruta = "~/DescargarBD";
            if (Directory.Exists(MapPath(ruta)))
            {
                string rutaArchivo = ruta + "/datosServicioJefe.csv";
                if (File.Exists(MapPath(rutaArchivo)))
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                    {
                        try
                        {
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre dependencia\", nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre asesor\", puestoacesor as \"Puesto asesor\", nombreprograma as \"Nombre programa\", programaactividad as \"Programa actividad\",tipoprograma as \"Tipo programa\",servicioTec as \"Servicio tec\",fechaInicioServ as \"Fecha inicio del servicio \",fechaTerminoServ as \"Fecha terminación del servicio\",correoAsesorExterno as \"Correo asesor externo\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where carrera = '" + txtCarreras.Text.ToString() + "';", conn);
                            dt = new DataTable();
                            da.Fill(dt);

                            List<string> lineas = new List<string>(), columnas = new List<string>();
                            foreach (DataColumn col in dt.Columns) columnas.Add(col.ColumnName);

                            lineas.Add(string.Join(";", columnas));
                            foreach (DataRow fila in dt.Rows)
                            {
                                List<string> celdas = new List<string>();
                                foreach (object celda in fila.ItemArray) celdas.Add(celda.ToString());
                                lineas.Add(string.Join(";", celdas));
                            }
                            File.WriteAllLines(MapPath(rutaArchivo), lineas, Encoding.UTF8);
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = ex.Message;
                        }
                    }
                    Response.ContentType = "text/csv";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosServicioJefe.csv");
                    Response.TransmitFile(Server.MapPath(rutaArchivo));
                    Response.End();
                }
                else
                {
                    File.Create(MapPath(rutaArchivo));
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                    {
                        try
                        {
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre dependencia\", nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre asesor\", puestoacesor as \"Puesto asesor\", nombreprograma as \"Nombre programa\", programaactividad as \"Programa actividad\",tipoprograma as \"Tipo programa\",servicioTec as \"Servicio tec\",fechaInicioServ as \"Fecha inicio del servicio \",fechaTerminoServ as \"Fecha terminación del servicio\",correoAsesorExterno as \"Correo asesor externo\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where carrera = '" + txtCarreras.Text.ToString() + "';", conn);
                            dt = new DataTable();
                            da.Fill(dt);

                            List<string> lineas = new List<string>(), columnas = new List<string>();
                            foreach (DataColumn col in dt.Columns) columnas.Add(col.ColumnName);

                            lineas.Add(string.Join(";", columnas));
                            foreach (DataRow fila in dt.Rows)
                            {
                                List<string> celdas = new List<string>();
                                foreach (object celda in fila.ItemArray) celdas.Add(celda.ToString());
                                lineas.Add(string.Join(";", celdas));
                            }
                            File.WriteAllLines(MapPath(rutaArchivo), lineas, Encoding.UTF8);
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = ex.Message;
                        }
                    }
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosServicioJefe.csv");
                    Response.TransmitFile(Server.MapPath(rutaArchivo));
                    Response.End();
                }
            }
            else
            {
                //Label1.Text = "No existe";
                Directory.CreateDirectory(MapPath(ruta));
                string rutaArchivo = ruta + "/datosServicioJefe.csv";
                File.Create(MapPath(rutaArchivo));
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre dependencia\", nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre asesor\", puestoacesor as \"Puesto asesor\", nombreprograma as \"Nombre programa\", programaactividad as \"Programa actividad\",tipoprograma as \"Tipo programa\",servicioTec as \"Servicio tec\",fechaInicioServ as \"Fecha inicio del servicio \",fechaTerminoServ as \"Fecha terminación del servicio\",correoAsesorExterno as \"Correo asesor externo\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where carrera = '" + txtCarreras.Text.ToString() + "';", conn);
                        dt = new DataTable();
                        da.Fill(dt);

                        List<string> lineas = new List<string>(), columnas = new List<string>();
                        foreach (DataColumn col in dt.Columns) columnas.Add(col.ColumnName);

                        lineas.Add(string.Join(";", columnas));
                        foreach (DataRow fila in dt.Rows)
                        {
                            List<string> celdas = new List<string>();
                            foreach (object celda in fila.ItemArray) celdas.Add(HttpUtility.HtmlDecode(celda.ToString()));
                            lineas.Add(string.Join(";", celdas));
                        }
                        File.WriteAllLines(MapPath(rutaArchivo), lineas, Encoding.UTF8);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = ex.Message;
                    }

                }
                Response.ContentType = "text/csv";
                Response.AppendHeader("Content-Disposition", "attachment;filename=datosServicioJefe.csv");
                Response.TransmitFile(Server.MapPath(rutaArchivo));
                Response.End();
            }
        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                string nc = txtNumerocontrol.Text;
                string ruta = "~/" + nc;
                string documento = DropDownList1.SelectedItem.Value;
                if (documento.Equals("servicioSocial"))
                {
                    string rutaArchivo = ruta + "/" + "SolicitudServicioSocial-" + nc + ".pdf";
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(rutaArchivo)))
                        {
                            //BtnDescargar.Text = "Existe";
                            Response.ContentType = "application/octet-stream";
                            Response.AppendHeader("Content-Disposition", "attachment;filename=SolicitudServicioSocial-" + nc + ".pdf");
                            Response.TransmitFile(Server.MapPath(rutaArchivo));
                            Response.End();
                        }
                        else
                        {
                            //descarminar.Text = "No existe archivo";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe documento')", true);
                        }
                    }
                    else
                    {
                        //descarminar.Text = "El Directorio no existe";
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
                else if (documento.Equals("Constancia de terminación"))
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
        }
    }
}