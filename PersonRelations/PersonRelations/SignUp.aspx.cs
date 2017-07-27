using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonRelations
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            byte[] bytes;
            if (Password.Text == ConfirmPassword.Text)
            {
                if (ImageUpload.HasFile)
                {
                    string fileName = Path.GetFileName(ImageUpload.PostedFile.FileName);
                    BinaryReader binaryReader = new BinaryReader(ImageUpload.PostedFile.InputStream);
                    bytes = binaryReader.ReadBytes((int)ImageUpload.PostedFile.InputStream.Length);
                    int personID;
                    Persons persons = new Persons();
                    string s = FirstName.Text;
                    personID = persons.Save(FName.Text, LName.Text, Gender.Text, DOB.Text, Biodata.Text, 0, 0, bytes);
                    LoginDetails loginDetails = new LoginDetails();
                    loginDetails.Save(personID, UserName.Text, Password.Text);
                    Response.Redirect("Login.aspx");
                }                
            }
            else
            {
            }
        }

        protected void Upload(object sender, EventArgs e)
        {
            
        }
        
    }
}