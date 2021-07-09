
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionServicioSocial
{
    public partial class ReporteSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // txtNumeroControl.Text = "16zp0033";
            if (!IsPostBack) 
            {
                if (Session["userServicio"] == null) 
                {
                    Response.Redirect("index.aspx");
                }
                else 
                {
                    txtNumeroControl.Text = Session["userServicio"].ToString();
                }
            }
        }

        protected void txtNumeroControl_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }
    }
}