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
        public int ParentID { get; set; }
        public int SpouseID { get; set; }
        public byte[] Image { get; set; }
        public int Save(string fname, string lname,string gender,string dob,string biodata,int parent_id,int spouse_id, byte[] image)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            return dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int PersonID=0;
                SqlDataReader tableData;
                myCommand.CommandText = string.Format("INSERT INTO Persons(FirstName,LastName,Gender,DOB,Biodata,ParentID,SpouseID,Image) VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},'{7}')", fname, lname, gender,dob,biodata,parent_id,spouse_id,image);
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = string.Format("SELECT IDENT_CURRENT('Persons') as ID ");
                tableData = myCommand.ExecuteReader();
                while (tableData.Read())
                {
                    PersonID = Convert.ToInt32(tableData["ID"]);
                }
                return PersonID;
            }
            );
        }


        public static Persons Read(int id)
        {
            Persons persons = new Persons();
            DBExecutor<Persons> dbExecutor = new DBExecutor<Persons>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                SqlDataReader tableData;
                myCommand.CommandText = string.Format("SELECT * FROM Persons WHERE ID={0}",id);
                tableData = myCommand.ExecuteReader();
                while (tableData.Read())
                {
                    persons.ID = Convert.ToInt32(tableData["ID"]);
                    persons.FName = Convert.ToString(tableData["FirstName"]);
                    persons.LName = Convert.ToString(tableData["LastName"]);
                    persons.Gender = Convert.ToString(tableData["Gender"]);
                    persons.Dob = Convert.ToString(tableData["DOB"]);
                    persons.Biodata = Convert.ToString(tableData["Biodata"]);
                    persons.ParentID = Convert.ToInt32(tableData["ParentID"]);
                    persons.SpouseID = Convert.ToInt32(tableData["SpouseID"]);
                    persons.Image = (byte[])tableData["Image"];
                }

                return persons;
            }
            );
            return persons;
        }


    }
}