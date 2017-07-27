using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonRelations
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var p = LoginDetails.Read(uname.Text);
                if(p.UserName != null && p.Password==password.Text)
                {
                    Response.Redirect("ViewDetails.aspx");
                }
                else
                {
                    invalidUser.Text = "*Invalid Username or Password";
                }
                //Response.Redirect("ViewDetails.aspx");
            }
        }

        protected void signUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}