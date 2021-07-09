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
    public partial class reportesxd : System.Web.UI.Page
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

        public decimal promedioEV() {
            decimal cal1, cal2, cal3, cal4, cal5, cal6, cal7;

            cal1 = decimal.Parse(txtEV1.Text);
            cal2 = decimal.Parse(txtEV2.Text);
            cal3 = decimal.Parse(txtEV3.Text);
            cal4 = decimal.Parse(txtEV4.Text);
            cal5 = decimal.Parse(txtEV5.Text);
            cal6 = decimal.Parse(txtEV6.Text);
            cal7 = decimal.Parse(txtEV7.Text);

            
            return ((cal1+cal2 + cal3 + cal4 + cal5 + cal6 + cal7)/7);
        }
        public decimal promedioAU()
        {
            decimal cal1, cal2, cal3, cal4, cal5, cal6, cal7;

            cal1 = decimal.Parse(txtAU1.Text);
            cal2 = decimal.Parse(txtAU2.Text);
            cal3 = decimal.Parse(txtAU3.Text);
            cal4 = decimal.Parse(txtAU4.Text);
            cal5 = decimal.Parse(txtAU5.Text);
            cal6 = decimal.Parse(txtAU6.Text);
            cal7 = decimal.Parse(txtAU7.Text);


            return ((cal1 + cal2 + cal3 + cal4 + cal5 + cal6 + cal7) / 7);
        }
        public void insertarAlumno() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert into calificaciones (idCalificaciones,numerocontrol) values(@NC,@NC);";
                    
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                   
                    
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void iserterCalificacionesR1() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    

                    insertarAlumno();
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set E11=@E11,E12=@E12,E13=@E13,E14=@E14,E15=@E15,E16=@E16,E17=@E17,A11=@A11,A12=@A12,A13=@A13,A14=@A14,A15=@A15,A16=@A16,A17=@A17,PromedioE1=@PE1, PromedioA1= @PA1 where idCalificaciones=@NC";
                    //
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                    //
                    cmd.Parameters.AddWithValue("@PE1", promedioEV());
                    cmd.Parameters.AddWithValue("@PA1", promedioAU());
                    //
                    cmd.Parameters.AddWithValue("@E11", txtEV1.Text);
                    cmd.Parameters.AddWithValue("@E12", txtEV2.Text);
                    cmd.Parameters.AddWithValue("@E13", txtEV3.Text);
                    cmd.Parameters.AddWithValue("@E14", txtEV4.Text);
                    cmd.Parameters.AddWithValue("@E15", txtEV5.Text);
                    cmd.Parameters.AddWithValue("@E16", txtEV6.Text);
                    cmd.Parameters.AddWithValue("@E17", txtEV7.Text);
                    //
                    cmd.Parameters.AddWithValue("@A11", txtAU1.Text);
                    cmd.Parameters.AddWithValue("@A12", txtAU2.Text);
                    cmd.Parameters.AddWithValue("@A13", txtAU3.Text);
                    cmd.Parameters.AddWithValue("@A14", txtAU4.Text);
                    cmd.Parameters.AddWithValue("@A15", txtAU5.Text);
                    cmd.Parameters.AddWithValue("@A16", txtAU6.Text);
                    cmd.Parameters.AddWithValue("@A17", txtAU7.Text);
                    //
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void iserterCalificacionesR2()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set E21=@E11,E22=@E12,E23=@E13,E24=@E14,E25=@E15,E26=@E16,E27=@E17,A21=@A11,A22=@A12,A23=@A13,A24=@A14,A25=@A15,A26=@A16,A27=@A17,PromedioE2=@PE1, PromedioA2= @PA1 where idCalificaciones=@NC";
                    //
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                    //
                    cmd.Parameters.AddWithValue("@PE1", promedioEV());
                    cmd.Parameters.AddWithValue("@PA1", promedioAU());
                    //
                    cmd.Parameters.AddWithValue("@E11", txtEV1.Text);
                    cmd.Parameters.AddWithValue("@E12", txtEV2.Text);
                    cmd.Parameters.AddWithValue("@E13", txtEV3.Text);
                    cmd.Parameters.AddWithValue("@E14", txtEV4.Text);
                    cmd.Parameters.AddWithValue("@E15", txtEV5.Text);
                    cmd.Parameters.AddWithValue("@E16", txtEV6.Text);
                    cmd.Parameters.AddWithValue("@E17", txtEV7.Text);
                    //
                    cmd.Parameters.AddWithValue("@A11", txtAU1.Text);
                    cmd.Parameters.AddWithValue("@A12", txtAU2.Text);
                    cmd.Parameters.AddWithValue("@A13", txtAU3.Text);
                    cmd.Parameters.AddWithValue("@A14", txtAU4.Text);
                    cmd.Parameters.AddWithValue("@A15", txtAU5.Text);
                    cmd.Parameters.AddWithValue("@A16", txtAU6.Text);
                    cmd.Parameters.AddWithValue("@A17", txtAU7.Text);
                    //
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void iserterCalificacionesR3()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set E31=@E11,E32=@E12,E33=@E13,E34=@E14,E35=@E15,E36=@E16,E37=@E17,A31=@A11,A32=@A12,A33=@A13,A34=@A14,A35=@A15,A36=@A16,A37=@A17,PromedioE3=@PE1, PromedioA3= @PA1 where idCalificaciones=@NC";
                    //
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                    //
                    cmd.Parameters.AddWithValue("@PE1", promedioEV());
                    cmd.Parameters.AddWithValue("@PA1", promedioAU());
                    //
                    cmd.Parameters.AddWithValue("@E11", txtEV1.Text);
                    cmd.Parameters.AddWithValue("@E12", txtEV2.Text);
                    cmd.Parameters.AddWithValue("@E13", txtEV3.Text);
                    cmd.Parameters.AddWithValue("@E14", txtEV4.Text);
                    cmd.Parameters.AddWithValue("@E15", txtEV5.Text);
                    cmd.Parameters.AddWithValue("@E16", txtEV6.Text);
                    cmd.Parameters.AddWithValue("@E17", txtEV7.Text);
                    //
                    cmd.Parameters.AddWithValue("@A11", txtAU1.Text);
                    cmd.Parameters.AddWithValue("@A12", txtAU2.Text);
                    cmd.Parameters.AddWithValue("@A13", txtAU3.Text);
                    cmd.Parameters.AddWithValue("@A14", txtAU4.Text);
                    cmd.Parameters.AddWithValue("@A15", txtAU5.Text);
                    cmd.Parameters.AddWithValue("@A16", txtAU6.Text);
                    cmd.Parameters.AddWithValue("@A17", txtAU7.Text);
                    //
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void iserterCalificacionesRFinal()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set EF1=@E11,EF2=@E12,EF3=@E13,EF4=@E14,EF5=@E15,EF6=@E16,EF7=@E17,AF1=@A11,AF2=@A12,AF3=@A13,AF4=@A14,AF5=@A15,AF6=@A16,AF7=@A17,PromedioEF=@PE1, PromedioAF= @PA1 where idCalificaciones=@NC";
                    //
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                    //
                    cmd.Parameters.AddWithValue("@PE1", promedioEV());
                    cmd.Parameters.AddWithValue("@PA1", promedioAU());
                    //
                    cmd.Parameters.AddWithValue("@E11", txtEV1.Text);
                    cmd.Parameters.AddWithValue("@E12", txtEV2.Text);
                    cmd.Parameters.AddWithValue("@E13", txtEV3.Text);
                    cmd.Parameters.AddWithValue("@E14", txtEV4.Text);
                    cmd.Parameters.AddWithValue("@E15", txtEV5.Text);
                    cmd.Parameters.AddWithValue("@E16", txtEV6.Text);
                    cmd.Parameters.AddWithValue("@E17", txtEV7.Text);
                    //
                    cmd.Parameters.AddWithValue("@A11", txtAU1.Text);
                    cmd.Parameters.AddWithValue("@A12", txtAU2.Text);
                    cmd.Parameters.AddWithValue("@A13", txtAU3.Text);
                    cmd.Parameters.AddWithValue("@A14", txtAU4.Text);
                    cmd.Parameters.AddWithValue("@A15", txtAU5.Text);
                    cmd.Parameters.AddWithValue("@A16", txtAU6.Text);
                    cmd.Parameters.AddWithValue("@A17", txtAU7.Text);
                    //
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void iserterCalificacionesR4()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set E41=@E11,E42=@E12,E43=@E13,E44=@E14,E45=@E15,E46=@E16,E47=@E17,A41=@A11,A42=@A12,A43=@A13,A44=@A14,A45=@A15,A46=@A16,A47=@A17,PromedioE4=@PE1, PromedioA4= @PA1 where idCalificaciones=@NC";
                    //
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                    //
                    cmd.Parameters.AddWithValue("@PE1", promedioEV());
                    cmd.Parameters.AddWithValue("@PA1", promedioAU());
                    //
                    cmd.Parameters.AddWithValue("@E11", txtEV1.Text);
                    cmd.Parameters.AddWithValue("@E12", txtEV2.Text);
                    cmd.Parameters.AddWithValue("@E13", txtEV3.Text);
                    cmd.Parameters.AddWithValue("@E14", txtEV4.Text);
                    cmd.Parameters.AddWithValue("@E15", txtEV5.Text);
                    cmd.Parameters.AddWithValue("@E16", txtEV6.Text);
                    cmd.Parameters.AddWithValue("@E17", txtEV7.Text);
                    //
                    cmd.Parameters.AddWithValue("@A11", txtAU1.Text);
                    cmd.Parameters.AddWithValue("@A12", txtAU2.Text);
                    cmd.Parameters.AddWithValue("@A13", txtAU3.Text);
                    cmd.Parameters.AddWithValue("@A14", txtAU4.Text);
                    cmd.Parameters.AddWithValue("@A15", txtAU5.Text);
                    cmd.Parameters.AddWithValue("@A16", txtAU6.Text);
                    cmd.Parameters.AddWithValue("@A17", txtAU7.Text);
                    //
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void iserterCalificacionesR5()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandText = "update Programa set correoAsesorExterno=@correo where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set E51=@E11,E52=@E12,E53=@E13,E54=@E14,E55=@E15,E56=@E16,E57=@E17,A51=@A11,A52=@A12,A53=@A13,A54=@A14,A55=@A15,A56=@A16,A57=@A17,PromedioE5=@PE1, PromedioA5= @PA1 where idCalificaciones=@NC";
                    //
                    cmd.Parameters.AddWithValue("@NC", txtNc.Text);
                    //
                    cmd.Parameters.AddWithValue("@PE1", promedioEV());
                    cmd.Parameters.AddWithValue("@PA1", promedioAU());
                    //
                    cmd.Parameters.AddWithValue("@E11", txtEV1.Text);
                    cmd.Parameters.AddWithValue("@E12", txtEV2.Text);
                    cmd.Parameters.AddWithValue("@E13", txtEV3.Text);
                    cmd.Parameters.AddWithValue("@E14", txtEV4.Text);
                    cmd.Parameters.AddWithValue("@E15", txtEV5.Text);
                    cmd.Parameters.AddWithValue("@E16", txtEV6.Text);
                    cmd.Parameters.AddWithValue("@E17", txtEV7.Text);
                    //
                    cmd.Parameters.AddWithValue("@A11", txtAU1.Text);
                    cmd.Parameters.AddWithValue("@A12", txtAU2.Text);
                    cmd.Parameters.AddWithValue("@A13", txtAU3.Text);
                    cmd.Parameters.AddWithValue("@A14", txtAU4.Text);
                    cmd.Parameters.AddWithValue("@A15", txtAU5.Text);
                    cmd.Parameters.AddWithValue("@A16", txtAU6.Text);
                    cmd.Parameters.AddWithValue("@A17", txtAU7.Text);
                    //
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    txtEV7.Text = ex.Message;
                }
            }

        }
        public void limpiarCampos() {

            txtEV1.Text = "";
            txtEV2.Text = "";
            txtEV3.Text = "";
            txtEV4.Text = "";
            txtEV5.Text = "";
            txtEV6.Text = "";
            txtEV7.Text = "";
            txtAU1.Text = "";
            txtAU2.Text = "";
            txtAU3.Text = "";
            txtAU4.Text = "";
            txtAU5.Text = "";
            txtAU6.Text = "";
            txtAU7.Text = "";
            
        }





        public void isertarCalificaciones() {
            if (txtReporte.SelectedValue.ToString().Equals("Reporte 1")) {
                iserterCalificacionesR1();
                limpiarCampos();
            } else if (txtReporte.SelectedValue.ToString().Equals("Reporte 2")) {
                iserterCalificacionesR2();
                limpiarCampos();
            } else if (txtReporte.SelectedValue.ToString().Equals("Reporte 3")) {
                iserterCalificacionesR3();
                limpiarCampos();
            } else if (txtReporte.SelectedValue.ToString().Equals("Reporte 4")) {
                iserterCalificacionesR4();
                limpiarCampos();
            } else if (txtReporte.SelectedValue.ToString().Equals("Reporte 5")) {
                iserterCalificacionesR5();
                limpiarCampos();
            } else if (txtReporte.SelectedValue.ToString().Equals("Evaluación Final")) {
                iserterCalificacionesRFinal();
                limpiarCampos();
            }
            else { 
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string NoControl = txtNc.Text;
            //string NoControl = "16ZP0010";
            string ruta = "~/" + NoControl;
            //string ruta1 = @"C:\Users\GENERICO\source\repos\pdf\pdf\16ZP0010";
            //Label1.Text = ruta;
            if (FileUpload1.HasFile)
            {
                if (txtReporte.SelectedItem.Text.Equals("Reporte 1"))
                {
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(ruta + "/" + "Reporte1-" + NoControl + ".pdf")))
                        {
                            //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        }
                        else
                        {


                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "Reporte1-" + NoControl + ".pdf"));
                            isertarCalificaciones();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }
                    
                }
                else if (txtReporte.SelectedItem.Text.Equals("Reporte 2"))
                {
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(ruta + "/" + "Reporte2-" + NoControl + ".pdf")))
                        {
                            //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        }
                        else
                        {


                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "Reporte2-" + NoControl + ".pdf"));
                            isertarCalificaciones();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }
                    
                }
                else if (txtReporte.SelectedItem.Text.Equals("Reporte 3"))
                {
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(ruta + "/" + "Reporte3-" + NoControl + ".pdf")))
                        {
                            //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                           
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        }
                        else
                        {


                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "Reporte3-" + NoControl + ".pdf"));
                            isertarCalificaciones();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }
                    
                }
                else if (txtReporte.SelectedItem.Text.Equals("Reporte 4"))
                {
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(ruta + "/" + "Reporte4-" + NoControl + ".pdf")))
                        {
                            //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        }
                        else
                        {


                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "Reporte4-" + NoControl + ".pdf"));
                            isertarCalificaciones();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }
                   
                }
                else if (txtReporte.SelectedItem.Text.Equals("Reporte 5"))
                {
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(ruta + "/" + "Reporte5-" + NoControl + ".pdf")))
                        {
                            //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        }
                        else
                        {


                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "Reporte5-" + NoControl + ".pdf"));
                            isertarCalificaciones();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }
                    
                }
                else if (txtReporte.SelectedItem.Text.Equals("Evaluación Final"))
                {
                    if (Directory.Exists(MapPath(ruta)))
                    {
                        if (File.Exists(MapPath(ruta + "/" + "EvaluaciónFinal-" + NoControl + ".pdf")))
                        {
                            //BtnSubirSolicitud.Text = "Existe archivo ya existe";
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Este archvio ya existe')", true);
                        }
                        else
                        {


                            //FileUpload1.SaveAs(Server.MapPath(ruta + "/" + FileUpload1.FileName));
                            FileUpload1.SaveAs(Server.MapPath(ruta + "/" + "EvaluaciónFinal-" + NoControl + ".pdf"));
                            isertarCalificaciones();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Subido con éxito')", true);
                            //BtnSubirSolicitud.Text = "Subido con éxito";
                        }
                    }

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona un archivo primero')", true);
                //BtnSubirSolicitud.Text = "Selecciona un archivo primero";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioServicio.aspx?parametro=" + txtNc.Text);
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Server.Transfer("UsuarioServicio.aspx");
        }
    }

   
}