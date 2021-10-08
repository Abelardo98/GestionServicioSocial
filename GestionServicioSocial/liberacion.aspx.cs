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
    public partial class terminacion : System.Web.UI.Page
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
        public void actulizarCartaLiberacion()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update documentosServicio set cartaLiberacion=@cartaLiberacion where numeroControl=@numeroControl";
                    cmd.Parameters.AddWithValue("@cartaLiberacion", dateTime.ToString("dd/MM/yyyy"));
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
                    if (File.Exists(MapPath(ruta + "/" + "ContanciaLiberaciónServicioSocial-" + NoControl + ".pdf")))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "ContanciaLiberaciónServicioSocial-" + NoControl + ".pdf"));
                        actulizarCartaLiberacion();
                        insertarFechas();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(MapPath("~/" + NoControl));
                    actulizarCartaLiberacion();
                    insertarFechas();
                    FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "ContanciaLiberaciónServicioSocial-" + NoControl + ".pdf"));                    
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
            }
        }
        public void insertarFechas() 
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    string fecha1 = numeroDia.Text+" de "+mesInicioServicio.SelectedValue+" del "+ anioInicioServicio.SelectedValue,
                        fecha2 = numeroDia2.Text + " de " + mesTerminoServicio.SelectedValue+" del "+anioTerminoServicio.SelectedValue;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update Programa set fechaInicioServ=@inicio, fechaTerminoServ=@termino,nombrePrograma=@nombrePrograma where idPrograma=@nCon";
                    cmd.Parameters.AddWithValue("@inicio", fecha1);
                    cmd.Parameters.AddWithValue("@termino", fecha2);
                    cmd.Parameters.AddWithValue("@nombrePrograma", txtNombreProyecto.Text);
                    cmd.Parameters.AddWithValue("@nCon", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    txtNombreProyecto.Text = ""; 
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioServicio.aspx?parametro=" + txtNc.Text);
        }
    }
}