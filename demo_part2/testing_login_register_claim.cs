﻿namespace demo_part2
{
    public class testing_login_register_claim
    {


        //login method
        public string Login(string username, string password)
        {
            //temp for message
            string message = "";

            //check if the user is correct
            if (username.Equals("rose@gmail.com") && password.Equals("12345")  ) {

                //then assign user found to message
                message = "user found";
            }
            else
            {
                //then if the user is not found
                message = "user not found";
            }

            return message;

        }

        //register method
        public string Register(string username,string role, string password) { 
        
         
            //validate data
            if(username.Contains("@gmail.com") &&role.Equals("lecture") &&password.Length>=8 )
            {
                //then return
                return "user is registered";
            }
            else
            {
                //then also return
                return "user not registered";
            }

        }


        //claim method
        public string claim(string qualification,string module,string group,string date,string hours_work,string rate,string file)
        {
            if (qualification != "")
            {
                return "submitted";

            }
            else{

                return "not submitted";
            }

        }


    }
}
