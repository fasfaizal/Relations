using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonRelations
{
    public partial class AddRelation : System.Web.UI.Page
    {
        private int userId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelSpouse.Visible = false;
                Spouse.Visible = false;
                LabelParent.Visible = false;
                Parent.Visible = false;
                userId = Convert.ToInt32(Session["userId"]);
                List<Persons> children = new List<Persons>();
                Persons person = Persons.GetSpouse(userId);
                if (person.FName == null)
                {
                    Relation.Items.Add(new ListItem("Spouse", "Spouse"));
                }
                else
                {
                    children = Persons.GetChildren(userId);
                    Relation.Items.Add(new ListItem("Son", "Son"));
                    Relation.Items.Add(new ListItem("Daughter", "Daughter"));
                    Relation.Items.Add(new ListItem("Son In Law", "Son In Law"));
                    Relation.Items.Add(new ListItem("Daughter In Law", "Daughter In Law"));
                    Relation.Items.Add(new ListItem("Grandson", "Grandson"));
                    Relation.Items.Add(new ListItem("Granddaughter", "Granddaughter"));
                    foreach (Persons child in children)
                    {
                        if (child.SpouseID == 0)
                            Spouse.Items.Add(new ListItem(child.FName, Convert.ToString(child.ID)));
                        else
                            Parent.Items.Add(new ListItem(child.FName, Convert.ToString(child.ID)));
                    }
                }
            }
            else
            {
                if ((Relation.SelectedItem.Value == "Son In Law") || (Relation.SelectedItem.Value == "Daughter In Law"))
                {
                    LabelSpouse.Visible = true;
                    Spouse.Visible = true;
                    LabelParent.Visible = false;
                    Parent.Visible = false;
                }
                else if((Relation.SelectedItem.Value == "Grandson") || (Relation.SelectedItem.Value == "Granddaughter"))
                {
                    LabelParent.Visible = true;
                    Parent.Visible = true;
                    LabelSpouse.Visible = false;
                    Spouse.Visible = false;
                }
                else
                {
                    LabelSpouse.Visible = false;
                    Spouse.Visible = false;
                    LabelParent.Visible = false;
                    Parent.Visible = false;
                }
            }

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
                    spouseID = userId;
                else
                    spouseID = Convert.ToInt32(Spouse.SelectedValue);
                if ((Relation.SelectedValue == "Son") || (Relation.SelectedValue == "Daughter"))
                    parentID = userId;
                else
                    parentID = Convert.ToInt32(Parent.SelectedValue);
                personID = persons.Save(FName.Text, LName.Text, Gender.Text, DOB.Text, Biodata.Text, parentID, spouseID, bytes);
                persons.UpdateSpouseID(spouseID, personID);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Relation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelSpouse.Visible = true;
            Spouse.Visible = true;
            LabelParent.Visible = true;
            Parent.Visible = true;
        }
    }
}