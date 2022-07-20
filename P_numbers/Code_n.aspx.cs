using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.IO;

namespace P_numbers
{
    public partial class Code_n : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                NpgsqlConnection con = new NpgsqlConnection("Host = localhost; Username = postgres; Password = Tangra; Database = postgres");
                con.Open();
                
                
                    NpgsqlDataAdapter nda = new NpgsqlDataAdapter(
                        "SELECT ph_number AS number,ph.c_code AS code,c.country AS country FROM ph_number AS ph JOIN c_codes AS c ON ph.c_code = c.code; "
                        , con);
                    DataTable dt = new DataTable();
                    nda.Fill(dt);
                    GV_country.DataSource = dt;
                    GV_country.DataBind();
                    
                
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Import.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            NpgsqlConnection con = new NpgsqlConnection("Host = localhost; Username = postgres; Password = Tangra; Database = postgres");
            con.Open();
            new NpgsqlCommand("COPY (SELECT ph_number,ph.c_code,c.country FROM ph_number AS ph JOIN c_codes AS c ON ph.c_code = c.code) TO 'D:\\export.csv' CSV DELIMITER ','; ", con).ExecuteNonQuery();
            con.Close();
        }
    }
}