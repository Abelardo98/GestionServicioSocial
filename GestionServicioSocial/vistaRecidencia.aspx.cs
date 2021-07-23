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
    public partial class vistaRecidencia : System.Web.UI.Page
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
            //txtCambioVistas.Text = "Residencias profesionales";
        }

       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }
        public void busquedaGeneral()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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

                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtNumerocontrol.Text + "'; ", conn);
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

        public void eliminarDocumentosReci() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eiminarDocumentoReci";
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

        public void eliminarRpyysReci()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarrpyssReci";
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
        public void eliminarProgramaReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarProgramaReci";
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
        public void eliminarAlumnoReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarAlumnoReci";
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
        public void eliminarInfoEscolarReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarEscolarReci";
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
        public void eliminarDomicilioReci()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "eliminarDomicilioReci";
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



        protected void BtnVerRegistros_Click(object sender, EventArgs e)
        {
            busquedaGeneral();
        }

        protected void BTN_BUSCARREGISTRO_Click(object sender, EventArgs e)
        {
            busquedaIndividual();
        }

        protected void BTN_Eliminar_Click(object sender, EventArgs e)
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
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            eliminarRpyysReci();
                            eliminarProgramaReci();
                            eliminarAlumnoReci();
                            eliminarInfoEscolarReci();
                            eliminarDomicilioReci();
                            eliminarDocumentosReci();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Dato Eliminado!')", true);
                            txtNumerocontrol.Text = "";
                            busquedaGeneral();
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
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Response.Redirect("EditarResidencia.aspx?parametro=" + txtNumerocontrol.Text);
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
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Session["userResidencia"] = txtNumerocontrol.Text;
                            Response.Redirect("ExportarReportesReci.aspx");
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
                        string cadena = "select numerocontrol from AlumnoReci where numerocontrol='" + txtNumerocontrol.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Session["userResidencia"] = txtNumerocontrol.Text;
                            Response.Redirect("UsuarioResidenciaAdmin.aspx?parametro=" + txtNumerocontrol.Text);
                            

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

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Session.Remove("userAdmin");
            Response.Redirect("index.aspx");
        }

        protected void descargarResi_Click(object sender, EventArgs e)
        {
            string ruta = "~/DescargarBD";
            if (Directory.Exists(MapPath(ruta)))
            {
                string rutaArchivo = ruta + "/datosResidencia.csv";
                if (File.Exists(MapPath(rutaArchivo)))
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                    {
                        try
                        {
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosResidencia.csv");
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
                            da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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
                    Response.AppendHeader("Content-Disposition", "attachment;filename=datosResidencia.csv");
                    Response.TransmitFile(Server.MapPath(rutaArchivo));
                    Response.End();
                }
            }
            else
            {
                //Label1.Text = "No existe";
                Directory.CreateDirectory(MapPath(ruta));
                string rutaArchivo = ruta + "/Residencia.csv";
                File.Create(MapPath(rutaArchivo));
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        da = new SqlDataAdapter("select alu.numerocontrol as \"Numero control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad \"Modalidad\",creditosAprovados as \"Creditos aprobados\" , localidad as \"Localidad\",calle as \"Calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\",copiaNombrePersona as \"Con copia para\",copiaPuestoPersona as \"Puesto de la persona\", nombreacesor as \"Nombre asesor\" , puestoacesor as \"Puesto asesor\",correoAcesor  as \"Correo asesor\", nombreProyecto as \"Nombre proyecto\",recidenciaTec as \"Residencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss;", conn);
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
                Response.AppendHeader("Content-Disposition", "attachment;filename=datosResidencia.csv");
                Response.TransmitFile(Server.MapPath(rutaArchivo));
                Response.End();
            }
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://cartaprovisionalitsz.access.ly/vista.aspx");
        }
    }
}