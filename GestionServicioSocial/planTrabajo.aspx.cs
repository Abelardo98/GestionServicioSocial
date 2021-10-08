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
        DateTime dateTime = DateTime.UtcNow.Date;
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

        public void actulizarPlanTrabajo()
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set planTrabajo=@planTrabajo where numeroControl=@numeroControl";
                    cmd.Parameters.AddWithValue("@planTrabajo", dateTime.ToString("dd/MM/yyyy"));
                    cmd.Parameters.AddWithValue("@numeroControl", txtNc.Text);
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            string ruta = "~/" + NoControl;
            if (FileUpload1.HasFile)
            {
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(ruta + "/" + "PlanTrabajoServicioSocial-" + NoControl + ".pdf")))
                    {
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
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "PlanTrabajoServicioSocial-" + NoControl + ".pdf"));
                            actulizarPlanTrabajo();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            insertarCorreo();
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    if (Correo.Text.Equals(""))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Correo de asesor obligatorio')", true);
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "PlanTrabajoServicioSocial-" + NoControl + ".pdf"));
                        actulizarPlanTrabajo();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                        insertarCorreo();
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
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