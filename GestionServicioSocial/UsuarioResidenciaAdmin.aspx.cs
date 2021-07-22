using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class UsuarioResidenciaAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userResidencia"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    txtNc.Text = Session["userResidencia"].ToString();
                }

            }

            if (!IsPostBack)
            {

                llenarTabla();
                llenarDatos();
                llenarTablaCalificaciones();
                
            }

        }

        public void llenarTablaCalificaciones()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select solicitudRecidencia as \"Solicitud de residencia profesional\",cartaPresentacion as \"Carta de presentación\",cartaAceptacion as \"Carta de aceptación RP\",responsiva as \"Responsiva\",cartaLiveracio as \"Carta de liberación RP\",constanciaCumplimiento as \"Constancia de cumplimiento\" from documentosReci where numeroControl = '" + txtNc.Text + "';", conn);

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

        public void llenarTabla()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select alu.numerocontrol, nombre, apellidop, apellidom, carrera,semestre,periodo,nombreProyecto from infoEscolarReci inf join AlumnoReci alu on inf.idescolar = alu.numerocontrol join ProgramaReci pro on alu.numerocontrol = pro.idprograma where inf.idescolar = '" + txtNc.Text + "';", conn);

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
        public void llenarDatos()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                txtNc.Text = row.Cells[0].Text;
                txtnombre.Text = row.Cells[1].Text;
                txtAP.Text = row.Cells[2].Text;
                txtAM.Text = row.Cells[3].Text;
                txtCarrera.Text = row.Cells[4].Text;
                txtSemestre.Text = row.Cells[5].Text;
                txtPeriodo.Text = row.Cells[6].Text;
                txtNombreProyecto.Text = row.Cells[7].Text;


            }

        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
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