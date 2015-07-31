using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// reference of model
using comp2084_a2.Models;

// cryto lib ref
using System.Security.Cryptography;

namespace comp2084_a2
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            // connect
            using (DefaultConnection db = new DefaultConnection())
            {
                // create a new user
                user userObj = new user();

                // fill user name from sign up form input
                userObj.username = txtUsername.Text;

                // salt and hash the plain text password
                String password = txtPassword.Text;
                String salt = CreateSalt(8);
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

                userObj.password = base64;
                userObj.salt = salt;

                // save
                db.users.Add(userObj);
                db.SaveChanges();

                // redirect
                Response.Redirect("default.aspx");
            }
        }
    }
}