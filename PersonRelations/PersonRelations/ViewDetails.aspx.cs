using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonRelations
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Persons> children = new List<Persons>();
            Persons person= Persons.GetSpouse(19);
            if(person.FName==null)
            {
                Relation.Items.Add("Spouse");
            }
            else
            {
                children = Persons.GetChildren(19);
                Relation.Items.Add("Son");
                Relation.Items.Add("Daughter");
                Relation.Items.Add("Son In Law");
                Relation.Items.Add("Daughter In Law");
                Relation.Items.Add("Grandson");
                Relation.Items.Add("Granddaughter");
                foreach(Persons child in  children)
                {
                        Parent.Items.Add(new ListItem(child.FName,Convert.ToString(child.ID)));
                        Spouse.Items.Add(new ListItem(child.FName, Convert.ToString(child.ID)));
                }
            }
            var p = Persons.Read(19);
            string strBase64 = Convert.ToBase64String(Persons.Read(19).Image);
            PersonImage.ImageUrl = "data:Image/png;base64," + strBase64;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            byte[] bytes;
            if (ImageUpload.HasFile)
            {
                string fileName = Path.GetFileName(ImageUpload.PostedFile.FileName);
                BinaryReader binaryReader = new BinaryReader(ImageUpload.PostedFile.InputStream);
                bytes = binaryReader.ReadBytes((int)ImageUpload.PostedFile.InputStream.Length);
                int personID;
                Persons persons = new Persons();
                string s = FirstName.Text;
                int spouseID;
                int parentID;
                if (Relation.SelectedValue == "Spouse")
                    spouseID = 19;
                else
                    spouseID = Convert.ToInt32(Spouse.SelectedValue);
                if ((Relation.SelectedValue == "Son")|| (Relation.SelectedValue == "Daughter"))
                    parentID = 19;
                else
                    parentID = Convert.ToInt32(Parent.SelectedValue);
                personID = persons.Save(FName.Text, LName.Text, Gender.Text, DOB.Text, Biodata.Text,parentID, spouseID, bytes);
                persons.UpdateSpouseID(spouseID,personID);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}