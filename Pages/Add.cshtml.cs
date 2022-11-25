using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace sample123.Pages
{

    public class Addusers
    {
        public string userid = "";
        public string position="";
        public int salary=0;
        public int tax=0;



    }
    public class AddModel : PageModel
    {
        [Required]
        public Addusers Users=new Addusers();
     
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Users.userid = Request.Form["userid"];
            Users.position = Request.Form["position"];
            Users.tax = Convert.ToInt32(Request.Form["tax"]);
            Users.salary = Convert.ToInt32(Request.Form["salary"]);



            string connection = "Data Source=INLPF3KT6VN;initial catalog=bnm;trusted_connection=true ";
            SqlConnection connectionstring = new SqlConnection(connection);
            connectionstring.Open();
            Console.WriteLine("adding one connection established");


            SqlCommand cmd2 = new SqlCommand("add_a", connectionstring);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;

            cmd2.Parameters.Add("@ide", System.Data.SqlDbType.VarChar).Value = Users.userid;
            cmd2.Parameters.Add("@positio", System.Data.SqlDbType.VarChar).Value = Users.position;
            cmd2.Parameters.Add("@salar", System.Data.SqlDbType.Int).Value = Users.salary;
            cmd2.Parameters.Add("@taxa", System.Data.SqlDbType.Int).Value = Users.tax;
            cmd2.ExecuteNonQuery();
            connectionstring.Close();
            Users.userid = "";
            Users.position = "";
            Users.tax = 0;
            Users.salary = 0;



        }

    }
}
