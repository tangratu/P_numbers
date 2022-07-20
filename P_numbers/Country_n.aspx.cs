using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace P_numbers
{
    public partial class Country_n : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                NpgsqlConnection con = new NpgsqlConnection("Host = localhost; Username = postgres; Password = Tangra; Database = postgres");
                con.Open();
                
                    NpgsqlDataAdapter nda = new NpgsqlDataAdapter(
                        "SELECT c.country,COUNT(ph.ph_number) AS count FROM ph_number AS ph JOIN c_codes AS c ON ph.c_code = c.code GROUP BY c.country"
                        , con);
                    DataTable dt = new DataTable();
                    nda.Fill(dt);
                    
                    GV_country.DataSource = dt;
                    GV_country.DataBind();
                Chart1.DataSource = dt;
                Chart1.Series.Add("Country");
                Chart1.Series["Country"].XValueMember = "country";
                Chart1.Series["Country"].YValueMembers = "count";
               
                
                
                con.Close();
            }
        }

        protected void Bt_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Import.aspx");
        }
    }
}