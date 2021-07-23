using System;
using System.Collections;
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
    public partial class vistaAsesores : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        //userJefe
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
        public void busquedaIndividual()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtNumerocontrol.Text + "'; ", conn);

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
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss where carrera = '" + txtCarreras.Text.ToString() + "';", conn);
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

        public void llenarTablaCalificacionesIndividual()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numeroControl as \"N.C\",solicitudRecidencia as \"Solicitud de residencia profesional\",cartaPresentacion as \"Carta de presentación\",cartaAceptacion as \"Carta de aceptación RP\",responsiva as \"Responsiva\",cartaLiveracio as \"Carta de liberación RP\",constanciaCumplimiento as \"Constancia de cumplimiento\" from documentosReci where numeroControl = '" + txtNumerocontrol.Text + "';", conn);

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
        public void llenarTablaCalificacionesGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numeroControl as \"N.C\",solicitudRecidencia as \"Solicitud de residencia profesional\",cartaPresentacion as \"Carta de presentación\",cartaAceptacion as \"Carta de aceptación RP\",responsiva as \"Responsiva\",cartaLiveracio as \"Carta de liberación RP\",constanciaCumplimiento as \"Constancia de cumplimiento\" from documentosReci ;", conn);

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

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            busquedaIndividual();
            llenarTablaCalificacionesIndividual();
        }

        protected void BtnVerRegistros_Click(object sender, EventArgs e)
        {

            llenarTablaCalificacionesGeneral();
            busquedaGeneral();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userJefe");
            Response.Redirect("index.aspx");
        }

        protected void BtnServicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaAsesoresServicio.aspx");
        }

        protected void descargarResi_Click(object sender, EventArgs e)
        {

            string ruta = "~/DescargarBD";
            if (Directory.Exists(MapPath(ruta)))
            {
                string rutaArchivo = ruta + "/datosResidenciaJefe.csv";
                if (File.Exists(MapPath(rutaArchivo)))
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                    {
                        try
                        {
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosResidenciaJefe.csv");
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
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosResidenciaJefe.csv");
                    Response.TransmitFile(Server.MapPath(rutaArchivo));
                    Response.End();
                }
                DropDownList1.SelectedValue = "0";
            }
            else
            {
                //Label1.Text = "No existe";
                Directory.CreateDirectory(MapPath(ruta));
                string rutaArchivo = ruta + "/datosResidenciaJefe.csv";
                File.Create(MapPath(rutaArchivo));
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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
                Response.AppendHeader("Content-Disposition", "attachment;filename=datosResidenciaJefe.csv");
                Response.TransmitFile(Server.MapPath(rutaArchivo));
                Response.End();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {


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
                            Response.AppendHeader("Content-Disposition", "attachment;filename=SolicitudResidencia-" + nc + ".pdf");
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
                            Response.AppendHeader("Content-Disposition", "attachment;filename=CartaAceptación-" + nc + ".pdf");
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
        }
    }
}