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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                lblWarning.Text = "Post message, be disliked";
            }

            GetMessages();
        }

        protected void GetMessages()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                grdMessages.DataSource = db.posts.ToArray();
                grdMessages.DataBind();
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            if (Session["userID"] != null)
            {
                // connect
                using (DefaultConnection db = new DefaultConnection())
                {
                    // create new post object in memory
                    post postObj = new post();
                    // get user id
                    Int32 userID = Convert.ToInt32(Session["userID"]);
                    String username = Session["username"].ToString();

                    // fill new post content
                    postObj.message = txtMessage.Text;
                    postObj.user_id = userID;
                    postObj.dislike_count = 0;
                    postObj.post_by = username;

                    // add post to database
                    db.posts.Add(postObj);

                    // save the new post
                    db.SaveChanges();

                    txtMessage.Text = "";
                    lblStatus.Text = "";

                    GetMessages();
                }
            } else
            {
                lblStatus.Text = "You must log in first to post";
            }
        }

        protected void grdMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DislikeMsg")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);
                Int32 postID = Convert.ToInt32(grdMessages.DataKeys[index].Values["id"]);

                //connect
                using (DefaultConnection db = new DefaultConnection())
                {
                    post postObj = (from p in db.posts
                                    where p.id == postID
                                    select p).FirstOrDefault();
                    // increase dislike count
                    postObj.dislike_count++;

                    db.SaveChanges();

                    // refresh grid
                    GetMessages();
                }
            }
        }
    }
}