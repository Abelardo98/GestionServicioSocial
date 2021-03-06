using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Win32.SafeHandles;
using System.Collections;

namespace GestionServicioSocial
{
    public partial class servicio2 : System.Web.UI.Page
    {
        
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null)
            {

                txtNumeroControl.Text = Request.Params["parametro"];

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
                    SqlCommand consulta = new SqlCommand("SELECT * FROM validarResidencia where numerocontrol = '" +
                        txtNumeroControl.Text + "';", conn);

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

        public void llenarDatosAlumno()
        {
            foreach (GridViewRow row in GridView2.Rows)
            {
                txtNumeroControl.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtCreditos.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtnombre.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAp.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtAm.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtGenero.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                string carrera = row.Cells[6].Text;
                if (carrera.StartsWith("IINF"))
                {
                    TxtCarrera.Text = "INGENIERÍA INFORMÁTICA";
                }
                else if (row.Cells[6].Text.StartsWith("IM"))
                {
                    TxtCarrera.Text = "INGENIERÍA MECATRÓNICA";
                }
                else if (row.Cells[6].Text.StartsWith("IA"))
                {
                    TxtCarrera.Text = "INGENIERÍA EN ADMINISTRACIÓN";
                }
                else if (row.Cells[6].Text.StartsWith("II"))
                {
                    TxtCarrera.Text = "INGENIERÍA INDUSTRIAL";
                }
                else if (row.Cells[6].Text.StartsWith("IF"))
                {
                    TxtCarrera.Text = "INGENIERÍA FORESTAL";
                }
                else if (row.Cells[6].Text.StartsWith("LB"))
                {
                    TxtCarrera.Text = "LICENCIATURA EN BIOLOGÍA";
                }
                else
                {
                    TxtCarrera.Text = "GASTRONOMÍA";
                }
            }

        }

        public void insertarDocumentoServicio()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarDocumentoServicio";
                    cmd.Parameters.Add("@numeroControl", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@solicitudServicio", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaPresentacion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaAceptacion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@responsiva", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaCompromiso", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@planTrabajo", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@reporte1", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@reporte2", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@reporte3", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@reporte4", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@reporte5", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@evaluacionFinal", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@reporteFinal", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@cartaLiberacion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@constanciaTerminacion", SqlDbType.VarChar).Value = "Archivo aun no subido";
                    cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = HttpUtility.HtmlDecode(TxtCarrera.Text);
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
        
        public void insertarDomicilio() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try {
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarDomicilio";
                    cmd.Parameters.Add("@iddomicilio", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
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
                } catch (Exception ex) {
                    txtMunicipio.Text = ex.Message.ToString();
                }             
            }         
        }
        public void insertarEscolar() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try {
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarEscolar";
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = TxtCarrera.SelectedItem.ToString();
                    cmd.Parameters.Add("@periodo", SqlDbType.VarChar).Value = txtPeriodo.Text.Trim();
                    cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = txtSemestre.Text.Trim();
                    cmd.Parameters.Add("@inscrito", SqlDbType.VarChar).Value = txtInscrito.SelectedValue.ToString();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = txtModalidad.SelectedItem.ToString();
                    cmd.Parameters.Add("@creditosAprovados", SqlDbType.Int).Value = Int32.Parse(txtCreditos.Text.Trim());
                    cmd.Parameters.Add("@iddomicilio", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                } catch (Exception ex) {
                    txtLocalidad.Text = ex.Message.ToString();
                }             
            }         
        }
        public void insertarAlumno() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try {                   
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarAlumno";
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtnombre.Text.Trim();
                    cmd.Parameters.Add("@apellidoP", SqlDbType.VarChar).Value = txtAp.Text.Trim();
                    cmd.Parameters.Add("@apellidoM", SqlDbType.VarChar).Value = txtAm.Text.Trim();
                    cmd.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = txtcontraseña.Text.Trim();
                    cmd.Parameters.Add("@edad", SqlDbType.VarChar).Value = txtedad.SelectedItem.ToString(); ;
                    cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = txtGenero.SelectedItem.ToString();
                    cmd.Parameters.Add("@estadoCivil", SqlDbType.VarChar).Value = txtEstadoCivil.SelectedItem.ToString();
                    cmd.Parameters.Add("@correoElectronico", SqlDbType.VarChar).Value = txtcorreo.Text.Trim();
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                } catch (Exception ex) {
                    txtnombre.Text = ex.Message.ToString();
                }               
            }            
        }

        public void llenardatos()
        {
            int creditosV = Convert.ToInt32(txtCreditos.Text);

            if (creditosV >= 177)
            {
                insertarDomicilio();
                insertarEscolar();
                insertarAlumno();
                insertarDocumentoServicio();
                Response.Redirect("servicio1.aspx?parametro=" + txtNumeroControl.Text);
            }
            else {
                txtCreditos.Text = "Creditos no superados";
            }


           /* using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select * from validarServicio where numerocontrol = '" + txtNumeroControl.Text + "'; ", conn);

                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);


                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    if (validarRecidencia() == true)
                    {
                        insertarDomicilio();
                        insertarEscolar();
                        insertarAlumno();
                        insertarDocumentoServicio();
                        Response.Redirect("servicio1.aspx?parametro=" + txtNumeroControl.Text);
                    }
                    else
                    {
                        txtCreditos.Text = "Creditos no superados";
                    }
                }
                catch (Exception ex)
                {
                    txtCreditos.Text = "Numero de control no valido";
                }
               
            }*/
        }

        public Boolean validarRecidencia()
        {
            int creditosValidos = 177;
            string creditosAlumno;

            if (GridView2.Rows.Count == 0)
            {

                return false;
            }
            else
            {
                foreach (GridViewRow row in GridView2.Rows)
                {

                    creditosAlumno = row.Cells[1].Text;
                    int creditosAlumno2 = Int32.Parse(creditosAlumno);
                    txtCreditos.Text = row.Cells[1].Text;
                    if (creditosAlumno2 >= creditosValidos)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            llenardatos();
        }
    }
}