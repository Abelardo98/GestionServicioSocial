using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestionServicioSocial
{
    public partial class EditarResidencia : System.Web.UI.Page
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

                    da = new SqlDataAdapter("select alu.numerocontrol as \"Numero Control\" ,nombre as \"Nombre\",apellidop as \"Apellido paterno\",apellidom as \"Apellido materno\",contraseña as \"Contraseña\",edad as \"Edad\",genero as \"Género\",estadocivil as \"Estado Civil\",correoelectronico as \"Correo electrónico\", carrera as \"Carrera\", semestre as \"Semestre\", periodo as \"Periodo\", inscrito as \"Inscrito\", seguroFacultativo as \"Seguro facultativo\",inf.modalidad Modalidad,creditosAprovados as \"Creditos aprovados\" , localidad as \"localidad\",calle as \"calle\", codigopostal as \"Código postal\",municipio as \"Municipio\", estado as \"Estado\" , telefono as \"Telefono\", razonSocial as \"Razón social\",tipo as \"Tipo\" , nombretitular as \"Nombre Titular\", puestotitular as \"Puesto titular\",areaalumno as \"Área alumno\", nombreacesor as \"Nombre Acesor\" , puestoacesor as \"Puesto acesor\",correoAcesor  as \"Correo acesor\", nombreProyecto as \"Nombre Proyecto\",recidenciaTec as \"Recidencias tec\", fechainicio , fechatermi , observaciones  from DomicilioReci dom join infoEscolarReci inf on dom.iddomicilio = inf.idescolar join alumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma join rpyssReci rp on pro.idprograma = rp.idrpyss where inf.idescolar= '" + txtbuscar.Text + "'; ", conn);
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

                txtNumeroControl.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtnombre.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAp.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtAm.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtContraseña.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtEdad.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
                txtgenero.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);
                txtEstadoCivil.Text = HttpUtility.HtmlDecode(row.Cells[8].Text);

                txtcorreo.Text = HttpUtility.HtmlDecode(row.Cells[9].Text);
                

                TxtCarrera.Text = HttpUtility.HtmlDecode(row.Cells[10].Text);
                txtSemestre.Text = HttpUtility.HtmlDecode(row.Cells[11].Text);
                txtPeriodo.Text = HttpUtility.HtmlDecode(row.Cells[12].Text);
                txtInscrito.Text = HttpUtility.HtmlDecode(row.Cells[13].Text);
                txtNumeroFacultativo.Text = HttpUtility.HtmlDecode(row.Cells[14].Text);
                txtModalidad.Text = HttpUtility.HtmlDecode(row.Cells[15].Text);
                txtCreditos.Text = HttpUtility.HtmlDecode(row.Cells[16].Text);
                txtLocalidad.Text = HttpUtility.HtmlDecode(row.Cells[17].Text);
                txtDomicilio.Text = HttpUtility.HtmlDecode(row.Cells[18].Text);
                txtCodigoPostal.Text = HttpUtility.HtmlDecode(row.Cells[19].Text);
                txtMunicipio.Text = HttpUtility.HtmlDecode(row.Cells[20].Text);



                txtestado.Text = HttpUtility.HtmlDecode(row.Cells[21].Text);
                txttelefono.Text = HttpUtility.HtmlDecode(row.Cells[22].Text);
                txtRazonSocial.Text = HttpUtility.HtmlDecode(row.Cells[23].Text);
                txtTipo.Text = HttpUtility.HtmlDecode(row.Cells[24].Text);
                txtTitularDependencia.Text = HttpUtility.HtmlDecode(row.Cells[25].Text);
                txtPuestoTitular.Text = HttpUtility.HtmlDecode(row.Cells[26].Text);
                txtAreaAlumno.Text = HttpUtility.HtmlDecode(row.Cells[27].Text);
                txtNombreAsesorExterno.Text = HttpUtility.HtmlDecode(row.Cells[28].Text);
                txtPuestoAsesorExterno.Text = HttpUtility.HtmlDecode(row.Cells[29].Text);
                txtCorreoAsesorExterno.Text = HttpUtility.HtmlDecode(row.Cells[30].Text);
                txtNombreProyecto.Text = HttpUtility.HtmlDecode(row.Cells[31].Text);

                txtResidencia.Text = HttpUtility.HtmlDecode(row.Cells[32].Text);



            }
        }

        protected void BTN_Buscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
            llenarDatos();
        }

        


        public void actuaizaPrograma()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarprogramaReci";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar).Value = txtRazonSocial.Text.Trim();
                    cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = txtTipo.SelectedItem.ToString();
                    cmd.Parameters.Add("@nombreTitular", SqlDbType.VarChar).Value = txtTitularDependencia.Text.Trim();
                    cmd.Parameters.Add("@puestoTitular", SqlDbType.VarChar).Value = txtPuestoTitular.Text.Trim();
                    cmd.Parameters.Add("@areaAlumno", SqlDbType.VarChar).Value = txtAreaAlumno.Text.Trim();
                    cmd.Parameters.Add("@nombreAcesor", SqlDbType.VarChar).Value = txtNombreAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@puestoAcesor", SqlDbType.VarChar).Value = txtPuestoAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@correoAcesor", SqlDbType.VarChar).Value = txtCorreoAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@nombreProyecto", SqlDbType.VarChar).Value = txtNombreProyecto.Text.Trim();
                    cmd.Parameters.Add("@recidenciaTec", SqlDbType.VarChar).Value = txtResidencia.SelectedItem.ToString();
                    
                    

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

        public void actualizarAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarAlumnoReci";
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtnombre.Text.Trim();
                    cmd.Parameters.Add("@apellidoP", SqlDbType.VarChar).Value = txtAp.Text.Trim();
                    cmd.Parameters.Add("@apellidoM", SqlDbType.VarChar).Value = txtAm.Text.Trim();
                    cmd.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = txtContraseña.Text.Trim();
                    cmd.Parameters.Add("@edad", SqlDbType.VarChar).Value = txtEdad.SelectedItem.ToString(); ;
                    cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = txtgenero.SelectedItem.ToString();
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

        public void actualizarInfoEscolar()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarinfoescolarReci";
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtbuscar.Text.Trim();
                    cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = TxtCarrera.Text.Trim();
                    cmd.Parameters.Add("@periodo", SqlDbType.VarChar).Value = txtPeriodo.Text.Trim();
                    cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = txtSemestre.SelectedItem.ToString();
                    cmd.Parameters.Add("@inscrito", SqlDbType.VarChar).Value = txtInscrito.SelectedValue.ToString();
                    cmd.Parameters.Add("@seguroFacultativo", SqlDbType.VarChar).Value = txtNumeroFacultativo.Text.Trim();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = txtModalidad.SelectedValue.ToString();
                    cmd.Parameters.Add("@creditosAprovados", SqlDbType.Int).Value =Int32.Parse(txtCreditos.Text.Trim());

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

        public void actualizarDomicilio()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizardomicilioReci";
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

        protected void BtnGuardar_Click1(object sender, EventArgs e)
        {
            actuaizaPrograma();
            actualizarAlumno();
            actualizarInfoEscolar();
            actualizarDomicilio();

            Server.Transfer("vistaRecidencia.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaRecidencia.aspx");
        }
    }
}