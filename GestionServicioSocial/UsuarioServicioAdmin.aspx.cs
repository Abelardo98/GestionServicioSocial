using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

namespace GestionServicioSocial
{
    public partial class UsuarioServicioAdmin : System.Web.UI.Page
    {
        CultureInfo culture = new CultureInfo("en-US");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["parametro"] != null)
            {

                txtNc.Text = Request.Params["parametro"];

            }

            Panel1.Visible = false;
            llenarTabla();
            llenarDatos();
            llenarCalificaciones();
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
                    SqlCommand consulta = new SqlCommand("select alu.numerocontrol, nombre, apellidop, apellidom, carrera,semestre,periodo,nombrePrograma from infoEscolar inf join Alumno alu on inf.idescolar = alu.numerocontrol join Programa pro on alu.numerocontrol = pro.idprograma where inf.idescolar = '" + txtNc.Text + "';", conn);

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

                txtNc.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
                txtnombre.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                txtAP.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                txtAM.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                txtCarrera.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                txtSemestre.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                txtPeriodo.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
                txtNombreProyecto.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);


            }

        }

        public void llenarCalificaciones() {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select E11 as \"Calificación uno\",E12 as \"Calificación dos\",E13 as \"Calificación tres\",E14 as \"Calificación cuatro\",E15 as \"Calificación cinco\",E16 as \"Calificación seis\",E17 as \"Calificación siete\",PromedioE1 as \"Promedio Evaluación 1\",A11 as \" Calificación uno\" ,A12 as \" Calificación dos \",A13 as \" Calificación tres \",A14 as \" Calificación cuatro \",A15 as \" Calificación cinco \",A16 as \" Calificación seis\",A17 as \" Calificación siete \"," +
                        "PromedioA1 as \"Promedio Autoevaluación 1\",E21 as \"  Calificación uno\",E22 as \" Calificación dos\",E23 as \" Calificación tres\",E24 as \" Calificación cuatro\",E25 as \" Calificación cinco\",E26 as \"  Calificación seis\",E27 as \"  Calificación siete\",PromedioE2 as \"Promedio Evaluación 2\",A21 as \"            Calificación uno\",A22 as \"  Calificación dos\",A23 as \"  Calificación tres\",A24 as \"  Calificación cuatro\",A25 as \"  Calificación cinco\",A26 as \"            Calificación seis\",A27 as \"            Calificación siete\"," +
                        "PromedioA2 as \"Promedio Autoevaluación 2\",E31 as \"   Calificación uno\",E32 as \"   Calificación dos\",E33 as \"   Calificación tres\",E34 as \"   Calificación cuatro\",E35 as \"   Calificación cinco\",E36 as \"   Calificación seis\",E37 as \"   Calificación siete\",PromedioE3 as \"Promedio Evaluación 3\",A31 as \"        Calificación uno\",A32 as \"        Calificación dos\",A33 as \"        Calificación tres\",A34 as \"        Calificación cuatro\",A35 as \"        Calificación cinco\",A36 as \"        Calificación seis\",A37 as \"        Calificación siete\"," +
                        "PromedioA3 as \"Promedio Autoevaluación 3\",EF1 as \"   Calificación final uno\",EF2 as \"   Calificación final dos\",EF3 as \"   Calificación final tres\",EF4 as \"   Calificación final cuatro\",EF5 as \"   Calificación final cinco\",EF6 as \"   Calificación final seis\",EF7 as \"   Calificación final siete\"," +
                        "PromedioEF,AF1 as \"        Calificación final uno\",AF2 as \"      Calificación final dos\",AF3 as \"     Calificación final tres\",AF4 as \"     Calificación final cuatro\",AF5 as \"      Calificación final cionco\",AF6 as \"     Calificación final seis\",AF7 as \"      Calificación final siete\"," +
                        "PromedioAF,E41 as \"    Calificación uno\",E42 as \"    Calificación dos\",E43 as \"    Calificación tres\",E44 as \"    Calificación cuatro\",E45 as \"    Calificación cinco\",E46 as \"    Calificación seis\",E47 as \"    Calificación site\",PromedioE4 as \"    Promedio Evaluación 4\",A41 as \"      Calificación uno\",A42 as \"      Calificación dos\",A43 as \"      Calificación tres\",A44 as \"      Calificación cuatro\",A45 as \"      Calificación cinco\",A46 as \"      Calificación seis\",A47 as \"      Calificación site\"," +
                        "PromedioA4 as \"Promedio Autoevaluación 4\",E51 as \"     Calificación uno\",E52 as \"     Calificación dos\",E53 as \"     Calificación tres\",E54 as \"     Calificación cuatro\",E55 as \"     Calificación cionco\",E56 as \"     Calificación seis\",E57 as \"     Calificación siete\",PromedioE5 as \"Promedio Evaluación 5\",A51 as \"           Calificación uno\",A52 as \"           Calificación dos\",A53 as \"           Calificación tres\",A54 as \"           Calificación cuatro\",A55 as \"           Calificación cinco\",A56 as \"          Calificación seis\",A57 as \"           Calificación siete\"," +
                        "PromedioA5 as \"Promedio Autoevaluación 5\" from calificaciones where idCalificaciones = '" + txtNc.Text + "';", conn);

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

        public void tablaCalificaciones() {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {

                try
                {

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    conn.Open();
                    SqlCommand consulta = new SqlCommand("select PromedioE1,PromedioE2,PromedioE3,PromedioE4,PromedioE5,PromedioEF,PromedioA1,PromedioA2,PromedioA3,PromedioA4,PromedioA5,PromedioAF from calificaciones where numerocontrol = '" + txtNc.Text + "';", conn);

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
        public void calcularCalificaciones()
        {
            //hola
            foreach (GridViewRow row in GridView1.Rows)
            {
                double promdioE1, promdioE2, promdioE3, promdioE4, promdioE5;
                double promedioA1, promedioA2, promedioA3, promedioA4, promedioA5;
                double promedioEF, promedioAf;
                double final, calificacion;
                double finalEV, finalAU, nivelDesemPeño;
                

                promdioE1 = double.Parse(row.Cells[0].Text, culture);
                promdioE2 = double.Parse(row.Cells[1].Text, culture);
                promdioE3 = double.Parse(row.Cells[2].Text, culture);
                // promdioE4 = double.Parse(row.Cells[3].Text, culture);
                // promdioE5 = double.Parse(row.Cells[4].Text, culture);
                promedioEF = double.Parse(row.Cells[5].Text, culture);
                //
                promedioA1 = double.Parse(row.Cells[6].Text, culture);
                promedioA2 = double.Parse(row.Cells[7].Text, culture);
                promedioA3 = double.Parse(row.Cells[8].Text, culture);
                //promedioA4 = double.Parse(row.Cells[9].Text, culture);
                //promedioA5 = double.Parse(row.Cells[10].Text, culture);
                promedioAf = double.Parse(row.Cells[11].Text, culture);

                

                finalEV = ((promdioE1+ promdioE2+ promdioE3+ promedioEF)/4)*0.9;

                finalAU = ((promedioA1 + promedioA2 + promedioA3 + promedioAf) / 4) * 0.1;
                final = finalEV + finalAU;
                calificacion = 70 + ((final - 1) * 10);

                txtEV.Text = finalEV.ToString();
                txtAuto.Text = finalAU.ToString();
                txtFinal.Text = final.ToString();
                txtCalificacion.Text = calificacion.ToString();
                if (final <= 0.99)
                {


                }
                else if (final <= 0.99)
                {
                    txtNivelDesem.Text = "INSUFICIENTE";
                }
                else if (final > 0.99 && final <= 1.49)
                {
                    txtNivelDesem.Text = "SUFICIENTE";
                }
                else if (final > 1.49 && final <= 2.49)
                {
                    txtNivelDesem.Text = "BUENO";
                }
                else if (final > 2.49 && final <= 3.49)
                {
                    txtNivelDesem.Text = "NOTABLE";
                }
                else if (final > 3.49)
                {
                    txtNivelDesem.Text = "EXCELENTE";
                }



            }

        }
        public void calcularCalificaciones4Reportes() {

            foreach (GridViewRow row in GridView1.Rows)
            {
                double promdioE1, promdioE2, promdioE3, promdioE4, promdioE5;
                double promedioA1, promedioA2, promedioA3, promedioA4, promedioA5;
                double promedioEF, promedioAf;
                double final, calificacion;
                double finalEV, finalAU, nivelDesemPeño;


                promdioE1 = double.Parse(row.Cells[0].Text, culture);
                promdioE2 = double.Parse(row.Cells[1].Text, culture);
                promdioE3 = double.Parse(row.Cells[2].Text, culture);
                promdioE4 = double.Parse(row.Cells[3].Text, culture);
                // promdioE5 = double.Parse(row.Cells[4].Text, culture);
                promedioEF = double.Parse(row.Cells[5].Text, culture);
                //
                promedioA1 = double.Parse(row.Cells[6].Text, culture);
                promedioA2 = double.Parse(row.Cells[7].Text, culture);
                promedioA3 = double.Parse(row.Cells[8].Text, culture);
                promedioA4 = double.Parse(row.Cells[9].Text, culture);
                //promedioA5 = double.Parse(row.Cells[10].Text, culture);
                promedioAf = double.Parse(row.Cells[11].Text, culture);



                finalEV = ((promdioE1 + promdioE2 + promdioE3 + promdioE4 + promedioEF) / 5) * 0.9;

                finalAU = ((promedioA1 + promedioA2 + promedioA3 + promedioA4 + promedioAf) / 5) * 0.1;
                final = finalEV + finalAU;
                calificacion = 70 + ((final - 1) * 10);

                txtEV.Text = finalEV.ToString();
                txtAuto.Text = finalAU.ToString();
                txtFinal.Text = final.ToString();
                txtCalificacion.Text = calificacion.ToString();

                if (final <= 0.99)
                {


                }
                else if (final <= 0.99)
                {
                    txtNivelDesem.Text = "INSUFICIENTE";
                }
                else if (final > 0.99 && final <= 1.49)
                {
                    txtNivelDesem.Text = "SUFICIENTE";
                }
                else if (final > 1.49 && final <= 2.49)
                {
                    txtNivelDesem.Text = "BUENO";
                }
                else if (final > 2.49 && final <= 3.49)
                {
                    txtNivelDesem.Text = "NOTABLE";
                }
                else if (final > 3.49)
                {
                    txtNivelDesem.Text = "EXCELENTE";
                }



            }



        }
        public void calcularCalificaciones5Reportes()
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                double promdioE1, promdioE2, promdioE3, promdioE4, promdioE5;
                double promedioA1, promedioA2, promedioA3, promedioA4, promedioA5;
                double promedioEF, promedioAf;
                double final, calificacion;
                double finalEV, finalAU, nivelDesemPeño;


                promdioE1 = double.Parse(row.Cells[0].Text, culture);
                promdioE2 = double.Parse(row.Cells[1].Text, culture);
                promdioE3 = double.Parse(row.Cells[2].Text, culture);
                promdioE4 = double.Parse(row.Cells[3].Text, culture);
                promdioE5 = double.Parse(row.Cells[4].Text, culture);
                promedioEF = double.Parse(row.Cells[5].Text, culture);
                //
                promedioA1 = double.Parse(row.Cells[6].Text, culture);
                promedioA2 = double.Parse(row.Cells[7].Text, culture);
                promedioA3 = double.Parse(row.Cells[8].Text, culture);
                promedioA4 = double.Parse(row.Cells[9].Text, culture);
                promedioA5 = double.Parse(row.Cells[10].Text, culture);
                promedioAf = double.Parse(row.Cells[11].Text, culture);



                finalEV = ((promdioE1 + promdioE2 + promdioE3 + promdioE4 + promdioE5 + promedioEF) / 5) * 0.9;

                finalAU = ((promedioA1 + promedioA2 + promedioA3 + promedioA4+ promedioA5 + promedioAf) / 5) * 0.1;
                final = finalEV + finalAU;
                calificacion = 70 + ((final - 1) * 10);

                txtEV.Text = finalEV.ToString();
                txtAuto.Text = finalAU.ToString();
                txtFinal.Text = final.ToString();
                txtCalificacion.Text = calificacion.ToString();

                if (final <= 0.99)
                {


                }
                else if (final <= 0.99)
                {
                    txtNivelDesem.Text = "INSUFICIENTE";
                }
                else if (final > 0.99 && final <= 1.49)
                {
                    txtNivelDesem.Text = "SUFICIENTE";
                }
                else if (final > 1.49 && final <= 2.49)
                {
                    txtNivelDesem.Text = "BUENO";
                }
                else if (final > 2.49 && final <= 3.49)
                {
                    txtNivelDesem.Text = "NOTABLE";
                }
                else if (final > 3.49)
                {
                    txtNivelDesem.Text = "EXCELENTE";
                }



            }



        }
        public void gurdarCalificaciones()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["coonBd"].ConnectionString))
            {
                try
                {
                    //string no = "16ZP0034";
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "update Programa set fechaInicioServ=@inicio, fechaTerminoServ=@termino,nombrePrograma=@nombrePrograma where idPrograma=@nCon";
                    cmd.CommandText = "update calificaciones set finalEV=@finalEV,finalAU=@finalAU,final=@final,calificacion=@calificacion,nivelDesempenio=@nivelDesempenio where idCalificaciones=@idCalificaciones";
                    cmd.Parameters.AddWithValue("@finalEV", txtEV.Text);
                    cmd.Parameters.AddWithValue("@finalAU", txtAuto.Text);
                    cmd.Parameters.AddWithValue("@final", txtFinal.Text);
                    cmd.Parameters.AddWithValue("@calificacion", txtCalificacion.Text);
                    cmd.Parameters.AddWithValue("@nivelDesempenio", txtNivelDesem.Text);
                    cmd.Parameters.AddWithValue("@idCalificaciones", txtNc.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    //Label3.Text = ex.Message;
                }

            }



        }
        protected void Btn_CalcularCalificaciones_Click(object sender, EventArgs e)
        {
            tablaCalificaciones();
            foreach (GridViewRow row in GridView1.Rows)
            {
                //txtEV.Text=row.Cells[3].Text;
              if (txtNreportes.Text.ToString().Equals("3")) {
                    calcularCalificaciones();
                    gurdarCalificaciones();
                    txtnombre.Text = "entre 3 reportes";
                } else if (txtNreportes.Text.ToString().Equals("4")) {
                    calcularCalificaciones4Reportes();
                    gurdarCalificaciones();
                    txtnombre.Text = "entre 4 reportes";
                } else if(txtNreportes.Text.ToString().Equals("5"))
                {
                    calcularCalificaciones5Reportes();
                    gurdarCalificaciones();
                    txtnombre.Text = "entre 5 reportes";
                    
                }
                else {
                    txtEV.Text = "Ningunop";
                } 
            }
            Panel1.Visible = true;

        }

        protected void BtnDescargar_Click(object sender, EventArgs e)
        {
            string nc = txtNc.Text;
            string ruta = "~/" + nc;
            string documento = DropDownList1.SelectedItem.Value;
            if (documento.Equals("servicioSocial"))
            {
                string rutaArchivo = ruta + "/" + "SolicitudServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=SolicitudServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe documento')", true);
                    }
                }
                else
                {
                    //BtnDescargar.Text = "El Directorio no existe";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("presentacion"))
            {
                string rutaArchivo = ruta + "/" + "AcuseCartaPresentacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaPresentaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('El directorio no existe')", true);
                }
            }
            else if (documento.Equals("cartaAceptación"))
            {
                string rutaArchivo = ruta + "/" + "CartaAceptaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaAceptaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe directorio')", true);
                }
            }
            else if (documento.Equals("responsiva"))
            {
                string rutaArchivo = ruta + "/" + "ResponsivaServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ResponsivaServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("compromiso"))
            {
                string rutaArchivo = ruta + "/" + "CartaCompromisoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=CartaCompromisoServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("planTrabajo"))
            {
                string rutaArchivo = ruta + "/" + "PlanTrabajoServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=PlanTrabajoServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 1"))
            {
                string rutaArchivo = ruta + "/" + "Reporte1-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte1-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 2"))
            {
                string rutaArchivo = ruta + "/" + "Reporte2-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte2-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 3"))
            {
                string rutaArchivo = ruta + "/" + "Reporte3-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte3-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 4"))
            {
                string rutaArchivo = ruta + "/" + "Reporte4-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte4-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Reporte 5"))
            {
                string rutaArchivo = ruta + "/" + "Reporte5-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=Reporte5-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Evaluaciones finales"))
            {
                string rutaArchivo = ruta + "/" + "EvaluaciónFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=EvaluaciónFinal-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("rFinal"))
            {
                string rutaArchivo = ruta + "/" + "ReporteFinal-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ReporteFinal-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("liberacion"))
            {
                string rutaArchivo = ruta + "/" + "ContanciaLiberaciónServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ContanciaLiberaciónServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    BtnDescargar.Text = "El Directorio no existe";
                }
            }
            else if (documento.Equals("Constancia de terminación"))
            {
                string rutaArchivo = ruta + "/" + "ContanciaTerminacionServicioSocial-" + nc + ".pdf";
                if (Directory.Exists(MapPath(ruta)))
                {
                    if (File.Exists(MapPath(rutaArchivo)))
                    {
                        //BtnDescargar.Text = "Existe";
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment;filename=ContanciaTerminacionServicioSocial-" + nc + ".pdf");
                        Response.TransmitFile(Server.MapPath(rutaArchivo));
                        Response.End();
                    }
                    else
                    {
                        //BtnDescargar.Text = "No existe archivo";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No existe archivo')", true);
                    }
                }
                else
                {
                    //BtnDescargar.Text = "El Directorio no existe";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("vista.aspx");
        }
    }
}