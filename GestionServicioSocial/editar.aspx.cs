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
    public partial class editar : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Params["parametro"] != null)
            {

                txtbuscar.Text = Request.Params["parametro"];

            }

            if (!Page.IsPostBack)
            {
                llenarTabla();
                llenarDatos();
            }
            
            
            
        }




        public void llenarTabla()
        {
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    //  da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\",calle as \"Calle\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\", nombreacesor as \"Nombre Asesor\", puestoacesor as \"Puesto Asesor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\", modalidad as \"Madalidad\", fechainicio as \"Fecha Inicio\", fechatermi as \"Fecha Termino\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtbuscar.Text + "'; ", conn);
                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido Paterno\",apellidom as \"Apellido Materno\",contraseña as \"Contraseña\" ,edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo Electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\",inf.modalidad as \"Modalidad\",creditosAprovados as \"Creditos Aprovados\",calle as \"Dirección\", localidad as \"Localidad\", codigopostal as \"Código Postal\",municipio as \"Municipio\", estado as \"Estado\", telefono as \"Teléfono\", nombredependencia as \"Nombre Dependencia\", nombretitular as \"Nombre Titular\", puestotitular as \"Puesto Titular\",areaalumno as \"Área Alumno\", nombreacesor as \"Nombre Asesor\", puestoacesor as \"Puesto Asesor\", nombreprograma as \"Nombre Programa\", programaactividad as \"Programa Actividad\",tipoprograma as \"Tipo Programa\",servicioTec as \"Servicio Tec\",fechaInicioServ as \"Fecha inicio del servicio \",fechaTerminoServ as \"Fecha terminación del servicio\",correoAsesorExterno as \"Correo asesor externo\", aceptado as \"Aceptado\", motivo as \"Motivo\", observaciones as \"Observaciones\" from domicilio dom join infoescolar inf on dom.iddomicilio = inf.idescolar join alumno alu on inf.idescolar = alu.numerocontrol join programa pro on alu.numerocontrol = pro.idprograma join rpyss rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtbuscar.Text + "'; ", conn);

                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {
                    txtDomicilio.Text = ex.Message;
                }

            }

        }

        public void llenarDatos()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                txtNumeroControl.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtnombre.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtAm.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAp.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtcontraseña.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtedad.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtGenero.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
                txtEstadoCivil.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);

                txtcorreo.Text = HttpUtility.HtmlDecode(row.Cells[8].Text);
                TxtCarrera.Text = HttpUtility.HtmlDecode(row.Cells[9].Text);
                txtSemestre.Text = HttpUtility.HtmlDecode(row.Cells[10].Text);
                txtPeriodo.Text = HttpUtility.HtmlDecode(row.Cells[11].Text);
                txtInscrito.Text = HttpUtility.HtmlDecode(row.Cells[12].Text);
                txtModalidad.Text = HttpUtility.HtmlDecode(row.Cells[13].Text);
                txtCreditos.Text = HttpUtility.HtmlDecode(row.Cells[14].Text);
                txtDomicilio.Text = HttpUtility.HtmlDecode(row.Cells[15].Text);
                
                

                txtLocalidad.Text = HttpUtility.HtmlDecode(row.Cells[16].Text);
                txtCodigoPostal.Text = HttpUtility.HtmlDecode(row.Cells[17].Text);              
                txtMunicipio.Text = HttpUtility.HtmlDecode(row.Cells[18].Text);
                txtestado.Text = HttpUtility.HtmlDecode(row.Cells[19].Text);
                txttelefono.Text = HttpUtility.HtmlDecode(row.Cells[20].Text);


                txtDependenciaOficial.Text = HttpUtility.HtmlDecode(row.Cells[21].Text);
                txtTitularDependencia.Text = HttpUtility.HtmlDecode(row.Cells[22].Text);
                txtPuestoTitular.Text = HttpUtility.HtmlDecode(row.Cells[23].Text);
                txtAreaAlumno.Text = HttpUtility.HtmlDecode(row.Cells[24].Text);
                txtNombrePersonaServicio.Text = HttpUtility.HtmlDecode(row.Cells[25].Text);
                txtPuesto.Text = HttpUtility.HtmlDecode(row.Cells[26].Text);
                txtNombrePrograma.Text = HttpUtility.HtmlDecode(row.Cells[27].Text);
                txtProgramaActividades.Text = HttpUtility.HtmlDecode(row.Cells[28].Text);
                txttipoprograma.Text = HttpUtility.HtmlDecode(row.Cells[29].Text);
                txtServicio.Text = HttpUtility.HtmlDecode(row.Cells[30].Text);
                txtFechaInicioServ.Text = HttpUtility.HtmlDecode(row.Cells[31].Text);
                txtFechaTerminoServ.Text = HttpUtility.HtmlDecode(row.Cells[32].Text);
                txtCorreoAcesorExterno.Text = HttpUtility.HtmlDecode(row.Cells[33].Text);



            }
        
        }

       

        
        public void actuaizaPrograma() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarprograma";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@nombreDependencia", SqlDbType.VarChar).Value = txtDependenciaOficial.Text.Trim();
                    cmd.Parameters.Add("@nombreTitular", SqlDbType.VarChar).Value = txtTitularDependencia.Text.Trim();
                    cmd.Parameters.Add("@puestoTitular", SqlDbType.VarChar).Value = txtPuestoTitular.Text.Trim();
                    cmd.Parameters.Add("@areaAlumno", SqlDbType.VarChar).Value = txtAreaAlumno.Text.Trim();
                    cmd.Parameters.Add("@nombreAcesor", SqlDbType.VarChar).Value = txtNombrePersonaServicio.Text.Trim();
                    cmd.Parameters.Add("@puestoAcesor", SqlDbType.VarChar).Value = txtPuesto.Text.Trim();
                    cmd.Parameters.Add("@nombrePrograma", SqlDbType.VarChar).Value = txtNombrePrograma.Text.Trim();
                    cmd.Parameters.Add("@programaActividad", SqlDbType.VarChar).Value = txtProgramaActividades.Text.Trim();
                    cmd.Parameters.Add("@tipoPrograma", SqlDbType.VarChar).Value = txttipoprograma.SelectedItem.ToString();
                    cmd.Parameters.Add("@servicioTec", SqlDbType.VarChar).Value = txtServicio.SelectedItem.ToString();
                    cmd.Parameters.Add("@correoAsesorExterno", SqlDbType.VarChar).Value = txtCorreoAcesorExterno.Text.Trim();
                    cmd.Parameters.Add("@fechaInicioServ", SqlDbType.VarChar).Value = txtFechaInicioServ.Text.Trim();
                    cmd.Parameters.Add("@fechaTerminoServ", SqlDbType.VarChar).Value = txtFechaTerminoServ.Text.Trim();

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtnombre.Text = ex.Message.ToString();
                }




            }

        }

        public void actualizarAlumno() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarAlumno";
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtnombre.Text.Trim();
                    cmd.Parameters.Add("@apellidoP", SqlDbType.VarChar).Value = txtAp.Text.Trim();
                    cmd.Parameters.Add("@apellidoM", SqlDbType.VarChar).Value = txtAm.Text.Trim();
                    cmd.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = txtcontraseña.Text.Trim();
                    cmd.Parameters.Add("@edad", SqlDbType.VarChar).Value = txtedad.SelectedItem.ToString(); ;
                    cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = txtGenero.SelectedItem.ToString();
                    cmd.Parameters.Add("@estadoCivil", SqlDbType.VarChar).Value = txtEstadoCivil.SelectedItem.ToString();
                    cmd.Parameters.Add("@correoElectronico", SqlDbType.VarChar).Value = txtcorreo.Text.Trim();
                    
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtnombre.Text = ex.Message.ToString();
                }

            }

        }

        public void actualizarInfoEscolar() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarinfoescolar";
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = TxtCarrera.Text.Trim();
                    cmd.Parameters.Add("@periodo", SqlDbType.VarChar).Value = txtPeriodo.SelectedItem.ToString();
                    cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = txtSemestre.SelectedItem.ToString();
                    cmd.Parameters.Add("@inscrito", SqlDbType.VarChar).Value = txtInscrito.SelectedValue.ToString();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = txtModalidad.SelectedValue.ToString();
                    cmd.Parameters.Add("@creditosAprovados", SqlDbType.VarChar).Value = Int32.Parse(txtCreditos.Text.Trim());

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtLocalidad.Text = ex.Message.ToString();
                }

            }

        }

        public void actualizarDomicilio() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizardomicilio";
                    cmd.Parameters.Add("@iddomicilio", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@calle", SqlDbType.VarChar).Value = txtDomicilio.Text.Trim();
                    cmd.Parameters.Add("@codigoPostal", SqlDbType.VarChar).Value = txtCodigoPostal.Text.Trim();
                    cmd.Parameters.Add("@localidad", SqlDbType.VarChar).Value = txtLocalidad.Text.Trim();
                    cmd.Parameters.Add("@municipio", SqlDbType.VarChar).Value = txtMunicipio.Text.Trim();
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = txtestado.Text.Trim();
                    cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txttelefono.Text.Trim();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtMunicipio.Text = ex.Message.ToString();
                }




            }

        }

       

        protected void BTN_Buscar_Click1(object sender, EventArgs e)
        {
            llenarTabla();
            llenarDatos();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            actuaizaPrograma();
            actualizarAlumno();
            actualizarInfoEscolar();
            actualizarDomicilio();

            Server.Transfer("vista.aspx");
        }
    }
} 