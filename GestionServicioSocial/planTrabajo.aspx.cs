using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace GestionServicioSocial
{
    public partial class planTrabajo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userServicio"] == null)
                {
                    Response.Redirect("index.aspx");
                }
                else
                {
                    txtNc.Text = Session["userServicio"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {

                    if (File.Exists(MapPath(ruta + "/" + "PlanTrabajoServicioSocial-" + NoControl + ".pdf")))
                    {
                        //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        if (Correo.Text.Equals(""))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo de asesor obligatorio')", true);
                        }
                        else
                        {
                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "PlanTrabajoServicioSocial-" + NoControl + ".pdf"));
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            insertarCorreo();
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                    if (Correo.Text.Equals(""))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo de asesor obligatorio')", true);
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "PlanTrabajoServicioSocial-" + NoControl + ".pdf"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        insertarCorreo();
                        //BtnSubirSolicitud.Text = "Subida con éxito";
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }

        }

        public void insertarCorreo()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    
                    cmd.Parameters.AddWithValue("@correo", Correo.Text);
                    cmd.Parameters.AddWithValue("@nCon", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Correo.Text = "";
                    
                }
                catch (Exception ex)
                {
                    
                }
            }
        }


        protected void BtnRegresar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioServicio.aspx?parametro=" + txtNc.Text);
        }
    }
}