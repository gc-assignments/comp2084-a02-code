using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// reference of model
using comp2084_a2.Models;

namespace comp2084_a2
{
    public partial class editmsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading for the first time (not posting back), check for a url
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    GetTheMsg();
                }
            }
        }

        protected void GetTheMsg()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                //get the id from the url
                Int32 postID = Convert.ToInt32(Request.QueryString["id"]);

                // look up post
                post postObj = (from p in db.posts
                           where p.id == postID
                           select p).FirstOrDefault();

                txtNewMsg.Text = postObj.message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                //connect
                using (DefaultConnection db = new DefaultConnection())
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        //get the id from the url
                        Int32 postID = Convert.ToInt32(Request.QueryString["id"]);

                        // look up post
                        post postObj = (from p in db.posts
                                        where p.id == postID
                                        select p).FirstOrDefault();

                        postObj.message = txtNewMsg.Text;

                        //save updated post
                        db.SaveChanges();

                        // redirect to user profile page
                        Response.Redirect("profile.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
            
    }
}