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
    public partial class vista : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtCambioVistas.Text = "Servicio Social";
            if (!IsPostBack)
            {
                if (Session["userAdmin"] == null)
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        public void eliminarDocumentosServicio() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eiminarDocumentoServi";
                    cmd.Parameters.Add("@numeroControl", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();
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
        public void eliminarRpyys()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarrpyss";
                    cmd.Parameters.Add("@idrpyss", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();
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
        public void eliminarPrograma()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarPrograma";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();
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
        public void eliminarAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarAlumno";
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();
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
        public void eliminarInfoEscolar()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarEscolar";
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();
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
        public void eliminarDomicilio()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDomicilio";
                    cmd.Parameters.Add("@iddomicilio", SqlDbType.VarChar).Value = txtNumerocontrol.Text.Trim();
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

        public void eliminarCalificaciones()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {                   
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete from calificaciones where idCalificaciones=@NC";
                    cmd.Parameters.AddWithValue("@NC", txtNumerocontrol.Text);
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
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero de control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        
                            eliminarRpyys();
                            eliminarPrograma();
                            eliminarDocumentosServicio();
                            eliminarCalificaciones();
                            eliminarAlumno();
                            eliminarInfoEscolar();
                            eliminarDomicilio();                           
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('dato eliminado')", true);
                            txtNumerocontrol.Text = "";
                            busquedaGeneral();
                        
                        

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }
        }

        protected void BTNeditar_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from Alumno where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Response.Redirect("editar.aspx?parametro=" + txtNumerocontrol.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
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
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Número Control\" ,SIE as \"Validación SIE\",nombre as \"Nombre\",apellidop as \"Apellido Paterno\"" +
                        ",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\" ,fechaRegistro as \"Fecha de registro\",contadorIngresado as \"Contador Documentación\" ,horasServicio as \"Horas Totales Servicio\",edad as \"Edad\"," +
                        "genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\"," +
                        " semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados" +
                        " as \"Creditos Aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as" +
                        " \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\",municipioDependencia as \"Municipio Dependencia\",estadoDependencia as \"Estado Dependencia\"," +
                        "telefonoDependencia as \"Teléfono Dependencia\",correoDependencia as \"Correo Dependencia\", nombretitular as" +
                        " \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\",copiaNombrePersona as \"Con Copia Para\"," +
                        "copiaPuestoPersona as \"Puesto de la Persona\", nombreacesor as \"Nombre del Supervisor\", puestoacesor as \"Puesto del Supervisor\"," +
                        " nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec " +
                        "as \"Servicio Tec\",fechaInicioServ as \"Fecha Inicio del Servicio \",fechaTerminoServ as \"Fecha Terminación del Servicio\",correoAsesorExterno" +
                        " as \"Correo del Supervisor\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\",LEFT(final, 1) as \"Final\",LEFT(calificacion, 5) as \"Calificación\",nivelDesempenio as \"Nivel Desempeño\" from domicilio" +
                        " dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro" +
                        " on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss full join calificaciones on rp.idrpyss = idCalificaciones; ", conn);
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

        public void busquedaIndividual()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    //da = new SqlDataAdapter("select alu.numerocontrol as \"Número Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\",fechaRegistro as \"Fecha de registro\" ,edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos Aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\",copiaNombrePersona as \"Con Copia Para\",copiaPuestoPersona as \"Puesto de la Persona\", nombreacesor as \"Nombre del Supervisor\", puestoacesor as \"Puesto del Supervisor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec as \"Servicio Tec\",fechaInicioServ as \"Fecha Inicio del Servicio \",fechaTerminoServ as \"Fecha Terminación del Servicio\",correoAsesorExterno as \"Correo del Supervisor\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtNumerocontrol.Text + "'; ", conn);
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Número Control\" ,SIE as \"Validación SIE\",nombre as \"Nombre\",apellidop as \"Apellido Paterno\"" +
                        ",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\" ,fechaRegistro as \"Fecha de registro\",contadorIngresado as \"Contador Documentación\" ,horasServicio as \"Horas Totales Servicio\",edad as \"Edad\"," +
                        "genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\"," +
                        " semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados" +
                        " as \"Creditos Aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as" +
                        " \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\",municipioDependencia as \"Municipio Dependencia\",estadoDependencia as \"Estado Dependencia\"," +
                        "telefonoDependencia as \"Teléfono Dependencia\",correoDependencia as \"Correo Dependencia\", nombretitular as" +
                        " \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\",copiaNombrePersona as \"Con Copia Para\"," +
                        "copiaPuestoPersona as \"Puesto de la Persona\", nombreacesor as \"Nombre del Supervisor\", puestoacesor as \"Puesto del Supervisor\"," +
                        " nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec " +
                        "as \"Servicio Tec\",fechaInicioServ as \"Fecha Inicio del Servicio \",fechaTerminoServ as \"Fecha Terminación del Servicio\",correoAsesorExterno" +
                        " as \"Correo del Supervisor\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\",LEFT(final, 1) as \"Final\",LEFT(calificacion, 5) as \"Calificación\",nivelDesempenio as \"Nivel Desempeño\" from domicilio" +
                        " dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro" +
                        " on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss full join calificaciones on rp.idrpyss = idCalificaciones where inf.idescolar= '" + txtNumerocontrol.Text + "';", conn);
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

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            busquedaIndividual();

        }

        protected void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from Alumno where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Session["userServicio"] = txtNumerocontrol.Text;
                            Response.Redirect("ExportarReportes.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtNumerocontrol.Text.Equals("") || txtNumerocontrol.Text == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ingresa un numero control valido!')", true);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from Alumno where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Response.Redirect("UsuarioServicioAdmin.aspx?parametro=" + txtNumerocontrol.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }
            }

        }

        protected void BtnServicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }

        protected void BtnResidencia_Click(object sender, EventArgs e)
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
                        string cadenax = "BULK INSERT validarResidencia FROM '" + ruta + "' WITH(FIELDTERMINATOR = ';', ROWTERMINATOR = '\n')";
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
        public void elimininarArchivoBd() {
            string nc = "CargaArchivos";
            string ruta = "~/" + nc;
            //Label1.Text = "Entro";
            string rutaArchivo = ruta + "/" + "cargaDatos" + ".csv";
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
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Archivo eliminado')", true);
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


        protected void cargarBase_Click(object sender, EventArgs e)
        {
            string ruta1 = "";
            string ruta = "~/" + "CargaArchivos";

            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "cargaDatos.csv")))
                    {
                        elimininarArchivoBd();
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatos.csv"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        ruta1 = Server.MapPath(ruta + "/" + "cargaDatos.csv");
                        cargarDatos(ruta1);
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatos.csv"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        ruta1 = Server.MapPath(ruta + "/" + "cargaDatos.csv");
                        cargarDatos(ruta1);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath(ruta));
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "cargaDatos.csv"));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subida con exito')", true);
                    ruta1 = Server.MapPath(ruta + "/" + "cargaDatos.csv");
                    cargarDatos(ruta1);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("userAdmin");
            Response.Redirect("index.aspx");
        }

        protected void BtnGenerarConstanciaTerminacion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    conn.Open();
                    string cadena = "select numerocontrol from Alumno where numerocontrol='" + txtNumerocontrol.Text + "';";
                    SqlCommand comando = new SqlCommand(cadena, conn);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        Session["userServicio"] = txtNumerocontrol.Text;
                        Response.Redirect("ReporteConstanciaTerminacion2.aspx?nc=" + txtNumerocontrol.Text);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control ya no existe!')", true);
                    }

                }
                catch (Exception ex)
                {
                    //mensaje.Text = e.Message;
                }

            }
        }

        protected void descargarRegistros_Click(object sender, EventArgs e)
        {
            string ruta = "~/DescargarBD";
            if (Directory.Exists(MapPath(ruta)))
            {
                string rutaArchivo = ruta + "/datosServicio.csv";
                if (File.Exists(MapPath(rutaArchivo)))
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                    {
                        try
                        {
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Número Control\" ,SIE as \"Validación SIE\",nombre as \"Nombre\",apellidop as \"Apellido Paterno\"" +
                        ",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\" ,fechaRegistro as \"Fecha de registro\",contadorIngresado as \"Contador Documentación\" ,horasServicio as \"Horas Totales Servicio\",edad as \"Edad\"," +
                        "genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\"," +
                        " semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados" +
                        " as \"Creditos Aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as" +
                        " \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\",municipioDependencia as \"Municipio Dependencia\",estadoDependencia as \"Estado Dependencia\"," +
                        "telefonoDependencia as \"Teléfono Dependencia\",correoDependencia as \"Correo Dependencia\", nombretitular as" +
                        " \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\",copiaNombrePersona as \"Con Copia Para\"," +
                        "copiaPuestoPersona as \"Puesto de la Persona\", nombreacesor as \"Nombre del Supervisor\", puestoacesor as \"Puesto del Supervisor\"," +
                        " nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec " +
                        "as \"Servicio Tec\",fechaInicioServ as \"Fecha Inicio del Servicio \",fechaTerminoServ as \"Fecha Terminación del Servicio\",correoAsesorExterno" +
                        " as \"Correo del Supervisor\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\",LEFT(final, 1) as \"Final\",LEFT(calificacion, 5) as \"Calificación\",nivelDesempenio as \"Nivel Desempeño\" from domicilio" +
                        " dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro" +
                        " on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss full join calificaciones on rp.idrpyss = idCalificaciones; ", conn);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosServicio.csv");
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
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Número Control\" ,SIE as \"Validación SIE\",nombre as \"Nombre\",apellidop as \"Apellido Paterno\"" +
                        ",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\" ,fechaRegistro as \"Fecha de registro\",contadorIngresado as \"Contador Documentación\" ,horasServicio as \"Horas Totales Servicio\",edad as \"Edad\"," +
                        "genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\"," +
                        " semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados" +
                        " as \"Creditos Aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as" +
                        " \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\",municipioDependencia as \"Municipio Dependencia\",estadoDependencia as \"Estado Dependencia\"," +
                        "telefonoDependencia as \"Teléfono Dependencia\",correoDependencia as \"Correo Dependencia\", nombretitular as" +
                        " \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\",copiaNombrePersona as \"Con Copia Para\"," +
                        "copiaPuestoPersona as \"Puesto de la Persona\", nombreacesor as \"Nombre del Supervisor\", puestoacesor as \"Puesto del Supervisor\"," +
                        " nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec " +
                        "as \"Servicio Tec\",fechaInicioServ as \"Fecha Inicio del Servicio \",fechaTerminoServ as \"Fecha Terminación del Servicio\",correoAsesorExterno" +
                        " as \"Correo del Supervisor\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\",LEFT(final, 1) as \"Final\",LEFT(calificacion, 5) as \"Calificación\",nivelDesempenio as \"Nivel Desempeño\" from domicilio" +
                        " dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro" +
                        " on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss full join calificaciones on rp.idrpyss = idCalificaciones; ", conn);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosServicio.csv");
                    Response.TransmitFile(Server.MapPath(rutaArchivo));
                    Response.End();
                }
            }
            else
            {
                Directory.CreateDirectory(MapPath(ruta));
                string rutaArchivo = ruta + "/datosServicio.csv";
                File.Create(MapPath(rutaArchivo));
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        da = new SqlDataAdapter("select alu.numerocontrol as \"Número Control\" ,SIE as \"Validación SIE\",nombre as \"Nombre\",apellidop as \"Apellido Paterno\"" +
                        ",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\" ,fechaRegistro as \"Fecha de registro\",contadorIngresado as \"Contador Documentación\" ,horasServicio as \"Horas Totales Servicio\",edad as \"Edad\"," +
                        "genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\"," +
                        " semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados" +
                        " as \"Creditos Aprobados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as" +
                        " \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\",municipioDependencia as \"Municipio Dependencia\",estadoDependencia as \"Estado Dependencia\"," +
                        "telefonoDependencia as \"Teléfono Dependencia\",correoDependencia as \"Correo Dependencia\", nombretitular as" +
                        " \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\",copiaNombrePersona as \"Con Copia Para\"," +
                        "copiaPuestoPersona as \"Puesto de la Persona\", nombreacesor as \"Nombre del Supervisor\", puestoacesor as \"Puesto del Supervisor\"," +
                        " nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec " +
                        "as \"Servicio Tec\",fechaInicioServ as \"Fecha Inicio del Servicio \",fechaTerminoServ as \"Fecha Terminación del Servicio\",correoAsesorExterno" +
                        " as \"Correo del Supervisor\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\",LEFT(final, 1) as \"Final\",LEFT(calificacion, 5) as \"Calificación\",nivelDesempenio as \"Nivel Desempeño\" from domicilio" +
                        " dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro" +
                        " on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss full join calificaciones on rp.idrpyss = idCalificaciones; ", conn);
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
                Response.AppendHeader("Content-Disposition", "attachment;filename=datosServicio.csv");
                Response.TransmitFile(Server.MapPath(rutaArchivo));
                Response.End();
            }
        }

        protected void BtnCartaP_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://cartaprovisionalitsz.access.ly/vista.aspx");
        }

        protected void BtnLimpiarBD_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    try
                    {                       
                        string cadenax = "delete from validarResidencia;";
                        SqlCommand cmd = new SqlCommand(cadenax, conn);
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Base de datos limpia')", true);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        txtNumerocontrol.Text = ex.Message;
                    }
                }

            }
        }

        protected void BtnSie_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Si entre')", true);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update Programa set SIE=@SIE where idPrograma=@idPrograma";
                    cmd.Parameters.AddWithValue("@idPrograma", txtNumerocontrol.Text);
                    cmd.Parameters.AddWithValue("@SIE", "SIE");
                    
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                   // txtNumeroControl.Text = ex.Message;
                }
            }
        }
    }
}