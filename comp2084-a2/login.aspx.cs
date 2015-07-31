using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//additional references
using comp2084_a2.Models;
using System.Security.Cryptography;

namespace comp2084_a2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                // create user obj
                user userObj = new user();

                // get username from input value
                String username = txtUsername.Text;

                userObj = (from u in db.users
                           where u.username == username
                           select u).FirstOrDefault();

                // check if user exists
                if (userObj != null)
                {
                    String salt = userObj.salt;

                    // salt and hash the plain text password
                    String password = txtPassword.Text;

                    String pass_and_salt = password + salt;

                    // Create a new instance of the hash crypto service provider.
                    HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();

                    // Convert the data to hash to an array of Bytes.
                    byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(pass_and_salt);

                    // Compute the Hash. This returns an array of Bytes.
                    byte[] bytHash = hashAlg.ComputeHash(bytValue);

                    // Optionally, represent the hash value as a base64-encoded string,
                    // For example, if you need to display the value or transmit it over a network.
                    string base64 = Convert.ToBase64String(bytHash);

                    if (userObj.password == base64)
                    {
                        //lblError.Text = "Valid Login";
                        //store the identity in the session object
                        Session["userID"] = userObj.id;
                        Session["username"] = userObj.username;

                        // redirect to departments page
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        lblError.Text = "Invalid Login";
                    }
                } else
                {
                    lblError.Text = "Invalid Login";
                }
            }
        }
    }
}