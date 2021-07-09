using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace GestionServicioSocial
{
    public partial class Residensia2 : System.Web.UI.Page
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
                    SqlCommand consulta = new SqlCommand("SELECT * FROM validarResidencia where numerocontrol = '" + txtNumeroControl.Text + "';", conn);

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
                txtgenero.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                //TxtCarrera.Text= HttpUtility.HtmlDecode(row.Cells[6].Text);
                
                if (row.Cells[6].Text.StartsWith("IINF"))
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

        public void insertarDomicilio()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarDomicilioReci";
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
                }
                catch (Exception ex)
                {
                    txtMunicipio.Text = ex.Message.ToString();
                }




            }



        }
        public void insertarEscolar()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarEscolarReci";
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@carrera", SqlDbType.VarChar).Value = TxtCarrera.Text.Trim();
                    cmd.Parameters.Add("@periodo", SqlDbType.VarChar).Value = txtPeriodo.SelectedItem.ToString();
                    cmd.Parameters.Add("@semestre", SqlDbType.VarChar).Value = txtSemestre.Text.Trim();
                    cmd.Parameters.Add("@inscrito", SqlDbType.VarChar).Value = txtInscrito.SelectedValue.ToString();
                    cmd.Parameters.Add("@seguroFacultativo", SqlDbType.VarChar).Value = txtNumeroFacultativo.Text.Trim();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = txtModalidad.SelectedItem.ToString();
                    cmd.Parameters.Add("@creditosAprovados", SqlDbType.Int).Value =Int32.Parse(txtCreditos.Text.Trim());
                    cmd.Parameters.Add("@iddomicilio", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
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
        public void insertarAlumno()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarAlumnoReci";
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtnombre.Text.Trim();
                    cmd.Parameters.Add("@apellidoP", SqlDbType.VarChar).Value = txtAp.Text.Trim();
                    cmd.Parameters.Add("@apellidoM", SqlDbType.VarChar).Value = txtAm.Text.Trim();
                    cmd.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = txtContraseña.Text.Trim();
                    cmd.Parameters.Add("@edad", SqlDbType.VarChar).Value = txtEdad.Text.Trim(); ;
                    cmd.Parameters.Add("@genero", SqlDbType.VarChar).Value = txtgenero.Text.Trim();
                    cmd.Parameters.Add("@estadoCivil", SqlDbType.VarChar).Value = txtEstadoCivil.Text.Trim().ToString();
                    cmd.Parameters.Add("@correoElectronico", SqlDbType.VarChar).Value = txtcorreo.Text.Trim();
                    cmd.Parameters.Add("@idescolar", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
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
        public void llenardatos() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select * from validarResidencia where numerocontrol = '" + txtNumeroControl.Text + "';; ", conn);

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
                        Response.Redirect("Residencia1.aspx?parametro=" + txtNumeroControl.Text);
                    }
                    else {
                        txtCreditos.Text = "Creditos no superados";
                    }
                }
                catch (Exception ex)
                {
                    txtCreditos.Text = "Creditos no superados";
                }

            }
        }

        public Boolean validarRecidencia() {

            int creditosValidos = 208;
            string creditosAlumno;
            
            if (GridView1.Rows.Count == 0)
            {

                return false;
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {

                    creditosAlumno = row.Cells[1].Text;
                    int creditosAlumno2 = Int32.Parse(creditosAlumno);
                    txtCreditos.Text= row.Cells[1].Text;
                    if (creditosAlumno2 >= creditosValidos) {
                        return true;
                    }
                    else {
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