using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_LOGIN_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                conn.Open();
                if (txtTipo.SelectedItem.Text.Equals("ADMINISTRADORA"))
                {
                    SqlCommand consulta = new SqlCommand("select username,contrasenia from usuarios where tipoUsuario='" + txtusername.Text + "'; ", conn);
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userAdmin"] = txtusername.Text;
                        Server.Transfer("vista.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                else if (txtTipo.SelectedItem.Text.Equals("JEFE CARRERA"))
                {
                    SqlCommand consulta = new SqlCommand("select username,contrasenia from usuarios where username='" + txtusername.Text + "'; ", conn);
                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userJefe"] = txtusername.Text;
                        Server.Transfer("vistaAsesoresResicencia.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                else if (txtTipo.SelectedItem.Text.Equals("SERVICIO"))
                {
                    SqlCommand consulta = new SqlCommand("select numerocontrol,contraseña from Alumno where numerocontrol = '" + txtusername.Text + "'; ", conn);
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userServicio"] = txtusername.Text;
                        Response.Redirect("UsuarioServicio.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                else if (txtTipo.SelectedItem.Text.Equals("RESIDENCIA"))
                {
                    SqlCommand consulta = new SqlCommand("select numerocontrol,contraseña from AlumnoReci where numerocontrol = '" + txtusername.Text + "'; ", conn);
                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userResidencia"] = txtusername.Text;
                        Response.Redirect("UsuarioResidencia.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
            }       
        }
        


        public void loginProfesor()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numeroControl,nombre from docentes where numeroControl='" + txtusername.Text + "'; ", conn);                 
                    SqlDataAdapter con = new SqlDataAdapter(consulta);                   
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContrasenia() == true)
                    {
                        Session["userProfe"] = txtusername.Text;
                        Server.Transfer("SalidaDeEstudios.aspx");
                    }
                    else 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                catch (Exception ex)
                {
                    txtpasword.Text = ex.Message;
                }
            }
        }

        public void loginAdmin() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select username,contrasenia from usuarios where tipoUsuario='" + txtusername.Text + "'; ", conn);                  
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userAdmin"] = txtusername.Text;
                        Server.Transfer("vista.aspx");
                    }
                    else 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        public void loginjefeCarrera()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();                   
                    SqlCommand consulta = new SqlCommand("select username,contrasenia from usuarios where username='" + txtusername.Text + "'; ", conn);
                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userJefe"] = txtusername.Text;
                        Server.Transfer("vistaAsesoresResicencia.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                catch (Exception ex)
                {
                    txtusername.Text = ex.Message;
                }

            }

        }

        public void loginServicio() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numerocontrol,contraseña from Alumno where numerocontrol = '" + txtusername.Text + "'; ", conn);                   
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userServicio"]=txtusername.Text;
                        Response.Redirect("UsuarioServicio.aspx");
                    }
                    else 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void loginRecidencia()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select numerocontrol,contraseña from AlumnoReci where numerocontrol = '" + txtusername.Text + "'; ", conn);
                    ArrayList lista = new ArrayList();
                    SqlDataAdapter con = new SqlDataAdapter(consulta);
                    con.Fill(ds);
                    dt = ds.Tables[0];
                    dt.AcceptChanges();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (validarContraseniaUsuario() == true)
                    {
                        Session["userResidencia"] = txtusername.Text;
                        Response.Redirect("UsuarioResidencia.aspx");
                    }
                    else 
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage",
                            "alert('Usuario, contraseña incorrectos / ¿Seleccionaste el tipo indicado?')", true);
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }

        public Boolean validarContrasenia()
        {
            if (GridView1.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[2].Text.Equals(txtpasword.Text))
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

        public Boolean validarContraseniaUsuario()
        {
            if (GridView1.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.Cells[1].Text.Equals(txtpasword.Text))
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Residencia2.aspx?parametro=" + txtusername.Text);
        }



        /* protected void Btn_Registro_Click1(object sender, EventArgs e)
         {
             Response.Redirect("Residencia2.aspx?parametro=" + txtusername.Text);
         }*/

        protected void btnServicio_Click(object sender, EventArgs e)
        {
            if (numeroControlReg.Text.Equals(""))
            {
                alertaControl.Text = "Ingresa tu numero de control";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from validarResidencia where numerocontrol='" + numeroControlReg.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Response.Redirect("servicio2.aspx?parametro=" + numeroControlReg.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        txtusername.Text = ex.Message;
                    }
                }
                
            }

        }


        protected void btnResidencia_Click(object sender, EventArgs e)
        {
            if (numeroControlReg.Text.Equals("")) 
            {
                alertaControl.Text = "Ingresa tu numero de control";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numerocontrol from validarResidencia where numerocontrol='" + numeroControlReg.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {
                            Response.Redirect("Residencia2.aspx?parametro=" + numeroControlReg.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control no existe!')", true);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                
            }
        }

        protected void BtnVisitas_Click(object sender, EventArgs e)
        {
            if (numeroControlReg.Text.Equals(""))
            {
                alertaControl.Text = "Ingresa tu numero de control";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        string cadena = "select numeroControl from docentes where numeroControl='" + numeroControlReg.Text + "';";
                        SqlCommand comando = new SqlCommand(cadena, conn);
                        SqlDataReader registro = comando.ExecuteReader();
                        if (registro.Read())
                        {

                            Session["userProfe"] = numeroControlReg.Text;
                            Server.Transfer("SalidaDeEstudios.aspx");
                            //Response.Redirect("servicio2.aspx?parametro=" + numeroControlReg.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Ese numero de control no existe!')", true);
                        }

                    }
                    catch (Exception ex)
                    {
                        //mensaje.Text = e.Message;
                    }
                }

            }
        }

        protected void BtnProvicional_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://cartaprovisionalitsz.access.ly");
        }
    }
}