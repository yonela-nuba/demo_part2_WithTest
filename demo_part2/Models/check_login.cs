namespace demo_part2.Models
{

    using System.Data.SqlClient;
    public class check_login
    {

        public string email { get; set; }
        public string role { get; set; }
        public string password { get; set; }

        //connection string 
        connection connect = new connection();


        //method to check the user
        public string login_user(string emails,string roles, string password)
        {
            //temp message
            string message = "";
            try
            {
                //connect and open
                using(SqlConnection connects  = new SqlConnection(connect.connecting()))
                {
                    //open connection
                    connects.Open();

                    //query
                    string query = "select * from users where email='"+emails+"' and role='"+roles+"' and password='"+password+"';";

                    //prepare to execute
                    using (SqlCommand prepare = new SqlCommand(query, connects) )
                    {

                        //read the data
                        using (SqlDataReader find_user = prepare.ExecuteReader() ) {

                            //then check if the use is found
                            if (find_user.HasRows)
                            {
                                //then assign message
                                message = "found";
                            }
                            else
                            {
                                message = "not";
                            }
                        }

                    }



                }


            }
            catch (IOException erro_db) {
            //return error
            message = erro_db.Message;
            }

            return message;
        }

    }
}
