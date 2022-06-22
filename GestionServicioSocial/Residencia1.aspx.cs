using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace GestionServicioSocial
{
    public partial class Recidencia1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton2.Visible = false;
            if (Request.Params["parametro"] != null)
            {

                txtNumeroControl.Text = Request.Params["parametro"];

            }
            
        }

        public void insertarPrograma()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarProgramaReci";
                    cmd.Parameters.Add("@idPrograma", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@razonSocial", SqlDbType.VarChar).Value = txtRazonSocial.Text.Trim();
                    cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = txtTipo.SelectedItem.ToString();
                    cmd.Parameters.Add("@nombreTitular", SqlDbType.VarChar).Value = txtTitularDependencia.Text.Trim();
                    cmd.Parameters.Add("@puestoTitular", SqlDbType.VarChar).Value = txtPuestoTitular.Text.Trim();
                    cmd.Parameters.Add("@areaAlumno", SqlDbType.VarChar).Value = txtAreaAlumno.Text.Trim();
                    cmd.Parameters.Add("@nombreAcesor", SqlDbType.VarChar).Value = txtNombreAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@puestoAcesor", SqlDbType.VarChar).Value = txtPuestoAsesorExterno.Text.Trim();
                    cmd.Parameters.Add("@correoAcesor", SqlDbType.VarChar).Value = txtCorreo.Text.Trim();
                    cmd.Parameters.Add("@nombreProyecto", SqlDbType.VarChar).Value = txtNombreProyecto.Text.Trim();
                    cmd.Parameters.Add("@recidenciaTec", SqlDbType.VarChar).Value = txtResidencia.SelectedItem.ToString();
                    cmd.Parameters.Add("@numerocontrol", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@copiaNombrePersona", SqlDbType.VarChar).Value = txtCopiaNombre.Text.Trim();
                    cmd.Parameters.Add("@copiaPuestoPersona", SqlDbType.VarChar).Value = txtCopiaPuesto.Text.Trim();
                    cmd.Parameters.Add("@municipioDependencia", SqlDbType.VarChar).Value = txtMunicipioDependencia.Text.Trim();
                    cmd.Parameters.Add("@estadoDependencia", SqlDbType.VarChar).Value = txtEstadoDependencia.Text.Trim();
                    cmd.Parameters.Add("@telefonoDependencia", SqlDbType.VarChar).Value = txtTelefonoDependencia.Text.Trim();
                    cmd.Parameters.Add("@correoDependencia", SqlDbType.VarChar).Value = txtCorreoDependencia.Text.Trim();

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

        public void insertaripyss()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "insertarrpyssReci";
                    cmd.Parameters.Add("@idrpyss", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@modalidad", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@fechaInicio", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@fechaTermi", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@observaciones", SqlDbType.VarChar).Value = " ";
                    cmd.Parameters.Add("@idprograma", SqlDbType.VarChar).Value = txtNumeroControl.Text.Trim();
                    cmd.Parameters.Add("@fechaRegistro", SqlDbType.VarChar).Value = DateTime.Now.ToString();
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
        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme()", true);

            insertarPrograma();
            insertaripyss();
          // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('¡IMPORTANTE! SI REALIZARAS LA RESIDENCIA PROFESIONAL EN EL INSTITUTO TECNOLÓGICO SUPERIOR DE ZACAPOAXTLA, SERÁS CONTACTADO EN LOS PRÓXIMOS DÍAS PARA QUE SE TE HAGA ENTREGA DE TU CARTA DE PRESENTACIÓN Y ACEPTACIÓN ')", true);
            Server.Transfer("sesion.aspx");

        }

        protected void txtResidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtResidencia.SelectedItem.ToString().Equals("SI")) {                
                LinkButton2.Visible = true;
                LinkButton1.Visible = false;
                txtTipo.Enabled = true;
                txtRazonSocial.Enabled = false;
                txtTitularDependencia.Enabled = false;
                txtPuestoTitular.Enabled = false;
                txtCopiaNombre.Enabled = false;
                txtCopiaPuesto.Enabled = false;
                Label9.Enabled = false;
                Label12.Enabled = false;
                BtnContinuar.Enabled = false;
                txtMunicipioDependencia.Enabled = false;
                txtEstadoDependencia.Enabled = false;
                txtTelefonoDependencia.Enabled = false;
                txtCorreoDependencia.Enabled = false;
                txtRazonSocial.Text = "INSTITUTO TECNOLÓGICO SUPERIOR DE ZACAPOAXTLA";
                txtTitularDependencia.Text = "GUSTAVO URBANO JUÁREZ";
                txtPuestoTitular.Text = "DIRECTOR GENERAL";
                txtTipo.SelectedValue= "Público";
                txtTipo.Enabled = false;
                txtMunicipioDependencia.Text = "ZACAPOAXTLA";
                txtEstadoDependencia.Text = "PUEBLA";
                txtTelefonoDependencia.Text = "233 317 5000";
                txtCorreoDependencia.Text = "recepcion.dg@zacapoaxtla.tecnm.mx";
            }
            else {              
                LinkButton2.Visible = false;
                LinkButton1.Visible = true;
                txtTipo.Enabled = true;
                txtRazonSocial.Enabled = true;
                txtTitularDependencia.Enabled = true;
                txtPuestoTitular.Enabled = true;
                txtCopiaNombre.Enabled = true;
                txtCopiaPuesto.Enabled = true;
                Label9.Enabled = true;
                Label12.Enabled = true;
                txtMunicipioDependencia.Enabled = true;
                txtEstadoDependencia.Enabled = true;
                txtTelefonoDependencia.Enabled = true;
                txtCorreoDependencia.Enabled = true;
                txtRazonSocial.Text = "";
                txtTitularDependencia.Text = "";
                txtPuestoTitular.Text = "";               
                txtAreaAlumno.Text = "";
                txtNombreAsesorExterno.Text = "";
                txtMunicipioDependencia.Text = "";
                txtEstadoDependencia.Text = "";
                txtTelefonoDependencia.Text = "";
                txtCorreoDependencia.Text = "";
            }
        }

        public void validarCamposServicioTec()
        {
            BtnContinuar.Enabled = false;
            
            if (txtResidencia.SelectedItem.Text.ToString().Equals("SI"))
            {
                LinkButton2.Visible = true;


                if (txtAreaAlumno.Text.Length > 1 && txtNombreAsesorExterno.Text.Length > 1 && txtPuestoAsesorExterno.Text.Length > 1)
                {
                    BtnContinuar.Enabled = true;
                }

            }
            else if (txtResidencia.SelectedItem.Text.ToString().Equals("NO"))
            {

                BtnContinuar.Enabled = true;


            }
            else
            {
                txtPuestoAsesorExterno.Text = "Entro al else";
            }


        }

        protected void txtNombreAsesorExterno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtAreaAlumno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }

        protected void txtPuestoAsesorExterno_TextChanged(object sender, EventArgs e)
        {
            validarCamposServicioTec();
        }
    }
}