using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonRelations
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var p = Persons.Read(19);
            string strBase64 = Convert.ToBase64String(Persons.Read(19).Image);
            PersonImage.ImageUrl = "data:Image/png;base64," + strBase64;
        }

        protected void submit_Click(object sender, EventArgs e)
        {

        }
    }
}