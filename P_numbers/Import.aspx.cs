using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using Npgsql;

namespace P_numbers
{
    public partial class Import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bt_upload_Click(object sender, EventArgs e)
        {

            if (F_upload.HasFile)
            {
                string savepath = "D:\\";
                string fname = F_upload.FileName;
                string tname = "";
                string path = savepath + fname;
                if (System.IO.File.Exists(path))
                {
                    int counter = 2;
                    tname = counter.ToString() + fname;
                    path = savepath + tname;
                    while (System.IO.File.Exists(path))
                    {
                        counter++;
                        tname = counter.ToString() + fname;
                        path = savepath + tname;
                    }
                    fname = tname;

                }
                savepath += fname;
                F_upload.SaveAs(savepath);
                NpgsqlConnection con = new NpgsqlConnection("Host = localhost; Username = postgres; Password = Tangra; Database = postgres");
                con.Open();



                Stopwatch sp = new Stopwatch();
                sp.Start();
                using (StreamReader s = new StreamReader(savepath))
                {
                    
                    string code ="";
                    string inp;
                    while (!s.EndOfStream)
                    {
                        inp = s.ReadLine();
                        if (inp.Length < 17 && inp.Length > 10)
                        {

                            switch (inp.Length)
                            {
                                case 16:
                                    {
                                        code = inp.Substring(0, 6);
                                        break;
                                    }
                                case 14:
                                    {
                                        code = inp.Substring(0, 4);
                                        break;
                                    }
                                case 13:
                                    {
                                        code = inp.Substring(0, 3);
                                        break;
                                    }
                                case 12:
                                    {
                                        code = inp.Substring(0, 2);
                                        break;
                                    }
                                case 11:
                                    {
                                        code = inp.Substring(0, 1);
                                        break;
                                    }
                            }
                            
                            if(int.Parse(new NpgsqlCommand("SELECT COUNT(code) FROM c_codes WHERE code='" + code + "'",con).ExecuteScalar().ToString()) == 0)
                            {
                                code = "invalid";
                            }
                            
                            NpgsqlCommand check_n = new NpgsqlCommand("SELECT COUNT(*) FROM ph_number WHERE ph_number = '" + inp + "'", con);
                            if (int.Parse(check_n.ExecuteScalar().ToString()) == 0)
                            {

                                
                                    NpgsqlCommand fillcom = new NpgsqlCommand("INSERT INTO ph_number(ph_number,c_code) VALUES(@number,@code)", con);
                                    fillcom.Parameters.AddWithValue("@number", Convert.ToInt64(inp));
                                    fillcom.Parameters.AddWithValue("@code", code);
                                    fillcom.ExecuteNonQuery();
                               
                            }
                        }
                        
                        
                    }
                }
                sp.Stop();
                Response.Write(sp.ElapsedMilliseconds.ToString());
                
                con.Close();
            }
            else { Response.Write("No file selected!"); }

        }
        protected void Bt_gencountry_Click(object sender, EventArgs e)
        {
            Response.Redirect("Country_n.aspx");
        }
        protected void Bt_gennumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("Code_n.aspx");
        }
    }
}