using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonRelations
{
    public class Persons
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Biodata { get; set; }
        public int? ParentID { get; set; }
        public int? SpouseID { get; set; }
        public int Save(string fname, string lname,string gender,string dob,string biodata,int? parent_id=null,int? spouse_id=null)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            return dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int updatedRows;
                myCommand.CommandText = string.Format("INSERT INTO Persons VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6})", fname, lname, gender,dob,biodata,parent_id,spouse_id);
                updatedRows = myCommand.ExecuteNonQuery();
                return updatedRows;
            }
            );
        }
    }
}