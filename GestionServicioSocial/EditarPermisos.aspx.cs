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
    public partial class EditarPermisos : System.Web.UI.Page
    {
        DataTable dt;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null)
            {

                txtidRegistro.Text = Request.Params["parametro"];

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

                    da = new SqlDataAdapter("select visitaPractica,visitaIndustrial,practica,docenteResponsable,numCelularDocente,CorreoElectronicoDocente,materia,semestre,grupo,alumnosProgramados,especialidad,carrera,objetivo,practicaDescripcion,nombreInstitucion,representante,puestoOcargo,direccion,municipioEstado,telefonoOrganizacion,fax,email,paginaWeb,fechaVisita,horaPropuesta,viajeNoche,recomendaciones,pd.idPermisoAcademico from  permisosDatosAcademicos pd join permisosDatosEmpresa pe on pd.idPermisoAcademico=pe.idPermiso where pd.CONTADOR= '" + txtidRegistro.Text + "'; ", conn);
                    dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();




                }
                catch (Exception ex)
                {
                    txtObjetivo.Text = ex.Message;
                }

            }

        }

        public void llenarDatos()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                txtVisitaPractica.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtVisitaIndustrial.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtPractica.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtDocenteResponsable.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtNumeroCelDocente.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtCorreoElextronicoDocente.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtMateria.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
                if (row.Cells[7].Text.Equals("primer")) {
                    txtSemestre.Text = "primero";
                } else if (row.Cells[7].Text.Equals("tercer")) {
                    txtSemestre.Text = "tercero";
                }
                else {
                    txtSemestre.Text = row.Cells[7].Text;
                }
                

                txtGrupo.Text = HttpUtility.HtmlDecode(row.Cells[8].Text);
                txtyCantidadAlumnos.Text = HttpUtility.HtmlDecode(row.Cells[9].Text);
                txtEspecialidad.Text = HttpUtility.HtmlDecode(row.Cells[10].Text);
                txtObjetivo.Text = HttpUtility.HtmlDecode(row.Cells[12].Text);
                txtEncasoPractica.Text = HttpUtility.HtmlDecode(row.Cells[13].Text);
                txtInstitucion.Text = HttpUtility.HtmlDecode(row.Cells[14].Text);
                txtRepresentante.Text = HttpUtility.HtmlDecode(row.Cells[15].Text);
                txtPuestoOCargo.Text = HttpUtility.HtmlDecode(row.Cells[16].Text);
                txtDireccion.Text = HttpUtility.HtmlDecode(row.Cells[17].Text);
                txtMunicipioEstado.Text = HttpUtility.HtmlDecode(row.Cells[18].Text);
                txtTelefonoEmpresa.Text = HttpUtility.HtmlDecode(row.Cells[19].Text);
                txtFax.Text = HttpUtility.HtmlDecode(row.Cells[20].Text);
                txtEmail.Text = HttpUtility.HtmlDecode(row.Cells[21].Text);
                txtPaginaWeb.Text = HttpUtility.HtmlDecode(row.Cells[22].Text);
                txtFechaPropuesta.Text = HttpUtility.HtmlDecode(row.Cells[23].Text);
                txtHoraPropuesta.Text = HttpUtility.HtmlDecode(row.Cells[24].Text);
                txtRecomedacionesOrganizacion.Text = HttpUtility.HtmlDecode(row.Cells[26].Text);
                txtNC2.Text = HttpUtility.HtmlDecode(row.Cells[27].Text);

            }
        }

        public void actuaizaAcademicos()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarAcademicos";
                    cmd.Parameters.Add("@idPermisoAcademico", SqlDbType.VarChar).Value = txtNC2.Text.Trim();
                    cmd.Parameters.Add("@visitaPractica", SqlDbType.VarChar).Value = txtVisitaPractica.SelectedItem.ToString();
                    cmd.Parameters.Add("@visitaIndustrial", SqlDbType.VarChar).Value = txtVisitaIndustrial.SelectedItem.ToString();
                    cmd.Parameters.Add("@practica", SqlDbType.VarChar).Value = txtPractica.SelectedItem.ToString();
                    cmd.Parameters.Add("@docenteResponsable", SqlDbType.VarChar).Value = txtDocenteResponsable.Text.Trim();
                    cmd.Parameters.Add("@numCelularDocente", SqlDbType.VarChar).Value = txtNumeroCelDocente.Text.Trim();
                    cmd.Parameters.Add("@CorreoElectronicoDocente", SqlDbType.VarChar).Value = txtCorreoElextronicoDocente.Text.Trim();
                    cmd.Parameters.Add("@materia", SqlDbType.VarChar).Value = txtMateria.Text.Trim();
                    if (txtSemestre.SelectedItem.ToString().Equals("primero")) {
                        cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = "primer";
                    } else if (txtSemestre.SelectedItem.ToString().Equals("tercero")) {
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
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA INFORMÁTICA";

                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IM"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA MECATRÓNICA";

                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IA"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA EN ADMINISTRACIÓN";

                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("II"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA INDUSTRIAL";

                    }
                    else if (txtEspecialidad.SelectedItem.ToString().Equals("IF"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "INGENIERÍA FORESTAL";

                    }

                    else if (txtEspecialidad.SelectedItem.ToString().Equals("LB"))
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "LICENCIATURA EN BIOLOGÍA";

                    }
                    else
                    {
                        cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = "LICENCIATURA EN GASTRONOMÍA";
                    }
  

                    cmd.Parameters.Add("@objetivo", SqlDbType.VarChar).Value =txtObjetivo.Text.Trim();
                    cmd.Parameters.Add("@practicaDescripcion", SqlDbType.VarChar).Value = txtEncasoPractica.Text.Trim();

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtRepresentante.Text=ex.Message;
                }




            }

        }

        public void actualizarEmpresa()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "actualizarEmpresa";
                    cmd.Parameters.Add("@idPermiso", SqlDbType.VarChar).Value = txtNC2.Text.Trim();
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
                    cmd.Parameters.Add("@recomendaciones", SqlDbType.VarChar).Value = txtRecomedacionesOrganizacion.Text.Trim();

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    txtDireccion.Text = ex.Message;
                }




            }

        }

        protected void BtnGuardarCambios_Click(object sender, EventArgs e)
        {
            actuaizaAcademicos();
            actualizarEmpresa();
            Server.Transfer("vistaPermisos.aspx");

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            llenarTabla();
            llenarDatos();
        }

        protected void txtVisitaPractica_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtVisitaIndustrial.Text = "";
            txtPractica.Text = "";
            txtEncasoPractica.Visible = true;
            Label9.Visible = true;
        }

        protected void txtVisitaIndustrial_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVisitaPractica.Text = "";
            txtPractica.Text = "";
            txtEncasoPractica.Visible = false;
            Label9.Visible = false;
            txtEncasoPractica.Text = "";
        }

        protected void txtPractica_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVisitaPractica.Text = "";
            txtVisitaIndustrial.Text = "";
            txtEncasoPractica.Visible = true;
            Label9.Visible = true;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Server.Transfer("vistaPermisos.aspx");
        }
    }
}