using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace sample123.Pages
{
    public class Listusers
    {
        public string userid = "";
        public string position;
        public int salary;
        public int tax;



    }

    public class LoginModel : PageModel
    {


        public List<Listusers> users = new List<Listusers>();
        public Lohininfo lohin = new Lohininfo();
        public string userd;
        public string passd;




        public string success = "";




        public int salary;
        public int tax;
        public string username = "";
        public int totalsalary;
        public void OnGet()
        {


        }
        public void OnPostDelete()
        {
            lohin.username = Request.Form["userid"];


            string connection = "Data Source=INLPF3KT6VN;initial catalog=bnm;trusted_connection=true ";
            SqlConnection connectionstring = new SqlConnection(connection);
            connectionstring.Open();
            Console.WriteLine("delete one  connection established");


            SqlCommand cmd2 = new SqlCommand("delete_a", connectionstring);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;

            cmd2.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = lohin.username;
            cmd2.ExecuteNonQuery();
            connectionstring.Close();

        }
        public void OnPost()
      
        {
            try
            {

                lohin.username = Request.Form["userid"];


                string connection = "Data Source=INLPF3KT6VN;initial catalog=bnm;trusted_connection=true ";
                SqlConnection connectionstring = new SqlConnection(connection);
                connectionstring.Open();
                Console.WriteLine("first connection established");


                SqlCommand cmd2 = new SqlCommand("check_a", connectionstring);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = lohin.username;
                cmd2.ExecuteNonQuery();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    success = reader2.GetString(0);
                }



                reader2.Close();






                Console.WriteLine("first connection established");

                SqlCommand cmd = new SqlCommand("user_details", connectionstring);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = lohin.username;
                Console.WriteLine("userid added to database");


                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Listusers listusers = new Listusers();
                    listusers.userid = reader.GetString(0);
                    listusers.position = reader.GetString(1);
                    listusers.salary = reader.GetInt32(2);
                    listusers.tax = reader.GetInt32(3);

                    users.Add(listusers);
                }
                Console.WriteLine("data was added to listusers");
                reader.Close();


                SqlCommand cmd1 = new SqlCommand("total_sa", connectionstring);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;




                cmd1.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = lohin.username;
                Console.WriteLine("id added for totalsalary");
                cmd1.ExecuteNonQuery();
                SqlDataReader reader1 = cmd1.ExecuteReader();
              
               







                    while (reader1.Read())
                    {


                        totalsalary = reader1.GetInt32(0);
                    }



                    reader1.Close();
                

                connectionstring.Close();
                lohin.username = "";


            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sql related problem");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("C# related problem");
            }
             

             
    }


public class Lohininfo
        {
            public string username;
            public string password;



        }
    }
}
