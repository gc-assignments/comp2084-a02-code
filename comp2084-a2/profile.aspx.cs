using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using comp2084_a2.Models;

namespace comp2084_a2
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                lblUsername.Text = Session["username"].ToString();
                GetUserMsg();
            }
            else
            {
                btnLogout.Text = "Log In Here";
            }
        }

        protected void GetUserMsg()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                Int32 userID = Convert.ToInt32(Session["userID"]);

                // posts filtered for logged in user
                var posts = from p in db.posts
                            where p.user_id == userID
                            select p;

                // bind user posts to profile page gridview
                grdUserMsg.DataSource = posts.ToArray();
                grdUserMsg.DataBind();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("login.aspx");
            } else
            {
                // kill session
                Session["userID"] = null;
                Session["username"] = null;

                // redirect to default
                Response.Redirect("default.aspx");
            }
        }

        protected void grdUserMsg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // identify post id
            Int32 postID = Convert.ToInt32(grdUserMsg.DataKeys[e.RowIndex].Values["id"]);

            // connect 
            using (DefaultConnection db = new DefaultConnection())
            {
                post postObj = (from p in db.posts
                                where p.id == postID
                                select p).FirstOrDefault();

                // delete
                db.posts.Remove(postObj);
                db.SaveChanges();

                //refresh grid
                GetUserMsg();
            }
        }
    }
}