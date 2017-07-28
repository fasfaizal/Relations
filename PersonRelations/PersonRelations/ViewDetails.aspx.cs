using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PersonRelations
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        private int userId { get; set; }
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            userId = Convert.ToInt32(Session["userId"]);
            Table table = new Table();
            DisplayRelations(userId, table);
            relationPlaceholder.Controls.Add(table);
            //var p = Persons.Read(19);
            //string strBase64 = Convert.ToBase64String(Persons.Read(19).Image);
            //PersonImage.ImageUrl = "data:Image/png;base64," + strBase64;
        }
        
        public Table DisplayRelations(int id, Table table)
        {
            table.Attributes.Add("class", "table table-bordered");
            var person = Persons.Read(id);
            table.BorderWidth = 5;
            TableRow tRow1 = new TableRow();
            TableCell tCell11 = new TableCell();
            HtmlGenericControl maindiv = new HtmlGenericControl("div");
            HtmlGenericControl div = new HtmlGenericControl("div");
            HtmlGenericControl image = new HtmlGenericControl("img");
            HtmlGenericControl fName = new HtmlGenericControl("div");
            fName.InnerHtml = "<b>" + person.FName + " " + person.LName + "</b>";
            HtmlGenericControl age = new HtmlGenericControl("div");
            age.InnerHtml = Convert.ToString(FindAge(person.Dob));
            HtmlGenericControl gender = new HtmlGenericControl("div");
            gender.InnerHtml = person.Gender;
            string strBase64 = Convert.ToBase64String(person.Image);
            image.Attributes.Add("src", "data: Image / png; base64," + strBase64);
            div.Attributes.Add("class", "bio");
            maindiv.Controls.Add(image);
            div.Controls.Add(fName);
            div.Controls.Add(age);
            div.Controls.Add(gender);
            maindiv.Controls.Add(div);
            tCell11.Controls.Add(maindiv);
            tRow1.Cells.Add(tCell11);

            var spouse = Persons.GetSpouse(id);
            if (spouse.ID != 0)
            {
                TableCell tCell12 = new TableCell();
                HtmlGenericControl s_maindiv = new HtmlGenericControl("div");
                HtmlGenericControl s_div = new HtmlGenericControl("div");
                HtmlGenericControl s_image = new HtmlGenericControl("img");
                HtmlGenericControl s_fName = new HtmlGenericControl("div");
                s_fName.InnerHtml = "<b>" + spouse.FName + " " + spouse.LName + "</b>";
                HtmlGenericControl s_age = new HtmlGenericControl("div");
                s_age.InnerHtml = Convert.ToString(FindAge(spouse.Dob));
                HtmlGenericControl s_gender = new HtmlGenericControl("div");
                s_gender.InnerHtml = spouse.Gender;
                string s_strBase64 = Convert.ToBase64String(spouse.Image);
                s_image.Attributes.Add("src", "data: Image / png; base64," + s_strBase64);
                s_div.Attributes.Add("class", "bio");
                s_maindiv.Controls.Add(s_image);
                s_div.Controls.Add(s_fName);
                s_div.Controls.Add(s_age);
                s_div.Controls.Add(s_gender);
                s_maindiv.Controls.Add(s_div);
                tCell12.Controls.Add(s_maindiv);
                tRow1.Cells.Add(tCell12);
            }
            table.Rows.Add(tRow1);

            var childen = Persons.GetChildren(id);
            if (childen.Count > 0)
            {
                TableRow tRow2 = new TableRow();
                TableCell tCell21 = new TableCell();
                Table innerTable = new Table();
                foreach (var child in childen)
                {
                    tCell21.Controls.Add(DisplayRelations(child.ID, innerTable));
                    tCell21.Attributes.Add("colspan", "2");
                }
                tRow2.Cells.Add(tCell21);
                table.Rows.Add(tRow2);
            }
            return table;

            //tCell1.Attributes.Add("class", "asd");
            //tCell1.Controls.Add(table1);
            //tRow.Cells.Add(tCell1);
            ////tRow2.Controls.Add(table1);
            //table.Rows.Add(tRow);
            //table.Rows.Add(tRow2);
            //relationPlaceholder.Controls.Add(table);

        }
        public int FindAge(string dob)
        {
            var today = DateTime.Today;
            var age = today.Year - Convert.ToDateTime(dob).Year;
            if (Convert.ToDateTime(dob) > today.AddYears(-age)) age--;
            return age;
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Response.Write("asddddddddddd");
            Response.Redirect("Login.aspx");
        }

        protected void BtnAddRelation_Click(object sender, EventArgs e)
        {
            AddRelation.Visible = true;
            BtnAddRelation.Visible = false;
            relationPlaceholder.Visible = false;
        }
    }

}