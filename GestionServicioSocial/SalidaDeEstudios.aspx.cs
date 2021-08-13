using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace GestionServicioSocial
{
    public partial class SalidaDeEstudios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["userProfe"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else {
                    txtNC.Text = Session["userProfe"].ToString();
                }

            }

            llenarTabla();
            llenarDatosAlumno();
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
                    SqlCommand consulta = new SqlCommand("select nombre from docentes where numeroControl = '" + txtNC.Text + "';", conn);

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
        public void llenarDatosAlumno()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                txtDocenteResponsable.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
            }  

        }

        public void insertarPermisoAcademico() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarpermisosDatosAcademicos";
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtNC.Text.Trim()+txtyCantidadAlumnos.Text.Trim() + txtSemestre.Text.Trim();
                    cmd.Parameters.Add("@visitaPractica", SqlDbType.VarChar).Value = txtVisitaPractica.SelectedItem.ToString();
                    cmd.Parameters.Add("@visitaIndustrial", SqlDbType.VarChar).Value = txtVisitaIndustrial.SelectedItem.ToString();
                    cmd.Parameters.Add("@practica", SqlDbType.VarChar).Value = txtPractica.SelectedItem.ToString();
                    cmd.Parameters.Add("@docenteResponsable", SqlDbType.VarChar).Value = txtDocenteResponsable.Text.Trim();
                    cmd.Parameters.Add("@numCelularDocente", SqlDbType.VarChar).Value = txtNumeroCelDocente.Text.Trim();
                    cmd.Parameters.Add("@CorreoElectronicoDocente", SqlDbType.VarChar).Value = txtCorreoElextronicoDocente.Text.Trim();
                    cmd.Parameters.Add("@materia", SqlDbType.VarChar).Value = txtMateria.Text.Trim();
                    if (txtSemestre.SelectedValue.ToString().Equals("primer"))
                    {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = "primer";
                    }
                    else if (txtSemestre.SelectedValue.ToString().Equals("tercer"))
                    {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = "tercer";
                    }
                    else {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = txtSemestre.SelectedItem.ToString();
                    }
                    

                    cmd.Parameters.Add("@grupo", SqlDbType.VarChar).Value = txtGrupo.SelectedItem.ToString();
                    cmd.Parameters.Add("@alumnosProgramados", SqlDbType.VarChar).Value = txtyCantidadAlumnos.Text.Trim();
                    cmd.Parameters.Add("@especialidad", SqlDbType.VarChar).Value = txtEspecialidad.SelectedItem.ToString();

                    if (txtEspecialidad.SelectedItem.ToString().Equals("IINF"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Ingeniería Informática";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IM"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Ingeniería Mecatrónica";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IA"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Ingeniería en Administración";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("II"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Ingeniería Industrial";
                        
                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IF"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Ingeniería Forestal";
                        
                    }
                    
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("LB"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Licenciatura en Biología";
                        
                    }
                    else
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "Gastronomía";
                        
                    }

                    cmd.Parameters.Add("@objetivo", SqlDbType.VarChar).Value = txtObjetivo.Text.Trim();
                    cmd.Parameters.Add("@practicaDescripcion", SqlDbType.VarChar).Value = txtEncasoPractica.Text.Trim();
                  
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtInstitucion.Text = ex.Message.ToString();
                }




            }
        }


        public void insertarPermisosEmpresa() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarpermisosDatosEmpresa";
                    cmd.Parameters.Add("@idPermiso", SqlDbType.VarChar).Value = txtNC.Text.Trim() + txtyCantidadAlumnos.Text.Trim() + txtSemestre.Text.Trim();
                    cmd.Parameters.Add("@nombreInstitucion", SqlDbType.VarChar).Value = txtInstitucion.Text.Trim();
                    cmd.Parameters.Add("@representante", SqlDbType.VarChar).Value = txtRepresentante.Text.Trim();
                    cmd.Parameters.Add("@puestoOcargo", SqlDbType.VarChar).Value = txtPuestoOCargo.Text.Trim();
                    cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txtDireccion.Text.Trim();
                    cmd.Parameters.Add("@municipioEstado", SqlDbType.VarChar).Value = txtMunicipioEstado.Text.Trim();
                    cmd.Parameters.Add("@telefonoOrganizacion", SqlDbType.VarChar).Value = txtTelefonoEmpresa.Text.Trim();
                    cmd.Parameters.Add("@fax", SqlDbType.VarChar).Value = txtFax.Text.Trim();
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                    cmd.Parameters.Add("@paginaWeb", SqlDbType.VarChar).Value = txtPaginaWeb.Text.Trim();
                    cmd.Parameters.Add("@fechaVisita", SqlDbType.VarChar).Value = txtFechaPropuesta.Text.Trim();
                    cmd.Parameters.Add("@horaPropuesta", SqlDbType.VarChar).Value = txtHoraPropuesta.Text.Trim();
                    cmd.Parameters.Add("@viajeNoche", SqlDbType.VarChar).Value = txtViajeNoche.SelectedItem.ToString();
                    cmd.Parameters.Add("@recomendaciones", SqlDbType.VarChar).Value = txtRecomedacionesOrganizacion.Text.Trim();
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtNC.Text.Trim() + txtyCantidadAlumnos.Text.Trim() + txtSemestre.Text.Trim(); ;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtInstitucion.Text = ex.Message.ToString();
                }




            }
        }

        protected void BtnGenerarPermiso_Click(object sender, EventArgs e)
        {

            insertarPermisoAcademico();
            insertarPermisosEmpresa();
            Response.Redirect("ReportePermisos2.aspx?parametro=" + txtNC.Text.Trim() + txtyCantidadAlumnos.Text.Trim() + txtSemestre.Text.Trim());

        }




        protected void txtVisitaPractica_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                txtVisitaIndustrial.Text = "";
                txtPractica.Text = "";
                txtEncasoPractica.Visible = true;
                txtEncasoDeSerPractica2.Visible = true;

            
            
        }

        protected void txtVisitaIndustrial_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                txtVisitaPractica.Text = "";
                txtPractica.Text = "";
                txtEncasoPractica.Visible = false;
                txtEncasoDeSerPractica2.Visible = false;
                txtEncasoPractica.Text = "";

            
            
        }

        protected void txtPractica_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
                txtVisitaPractica.Text = "";
                txtVisitaIndustrial.Text = "";
                txtEncasoPractica.Visible = true;
                txtEncasoDeSerPractica2.Visible = true;

           
        }
    }
}