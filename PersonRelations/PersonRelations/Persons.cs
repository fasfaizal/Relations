﻿using System;
using System.Collections.Generic;
using System.Data;
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
                myCommand.CommandText = string.Format("INSERT INTO Persons(FirstName,LastName,Gender,DOB,Biodata,ParentID,SpouseID,Image) VALUES('{0}','{1}','{2}','{3}','{4}',{5},{6},@binary)", fname, lname, gender,dob,biodata,parent_id,spouse_id);
                myCommand.Parameters.Add("@binary", SqlDbType.VarBinary, image.Length).Value = image;
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

        public void UpdateSpouseID(int personID,int spouseID)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int PersonID;
                myCommand.CommandText = string.Format("UPDATE Persons SET SPOUSEID={0} WHERE ID={1}",spouseID,personID);
                PersonID= myCommand.ExecuteNonQuery();
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

        public static Persons GetSpouse(int id)
        {
            Persons person = new Persons();
            DBExecutor<Persons> dbExecutor = new DBExecutor<Persons>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                SqlDataReader tableData;
                myCommand.CommandText = string.Format("SELECT * FROM Persons WHERE SpouseID={0}", id);
                tableData = myCommand.ExecuteReader();
                while (tableData.Read())
                {
                    person.ID = Convert.ToInt32(tableData["ID"]);
                    person.FName = Convert.ToString(tableData["FirstName"]);
                    person.LName = Convert.ToString(tableData["LastName"]);
                    person.Gender = Convert.ToString(tableData["Gender"]);
                    person.Dob = Convert.ToString(tableData["DOB"]);
                    person.Biodata = Convert.ToString(tableData["Biodata"]);
                    person.ParentID = Convert.ToInt32(tableData["ParentID"]);
                    person.SpouseID = Convert.ToInt32(tableData["SpouseID"]);
                    person.Image = (byte[])tableData["Image"];
                }

                return person;
            }
            );
            return person;
        }

        public static List<Persons> GetChildren(int id)
        {
            List<Persons> persons = new List<Persons>();
            DBExecutor<List<Persons>> dbExecutor = new DBExecutor<List<Persons>>();
            dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                SqlDataReader tableData;
                myCommand.CommandText = string.Format("SELECT * FROM Persons WHERE ParentID={0}", id);
                tableData = myCommand.ExecuteReader();
                while (tableData.Read())
                {
                    Persons person = new Persons();
                    person.ID = Convert.ToInt32(tableData["ID"]);
                    person.FName = Convert.ToString(tableData["FirstName"]);
                    person.LName = Convert.ToString(tableData["LastName"]);
                    person.Gender = Convert.ToString(tableData["Gender"]);
                    person.Dob = Convert.ToString(tableData["DOB"]);
                    person.Biodata = Convert.ToString(tableData["Biodata"]);
                    person.ParentID = Convert.ToInt32(tableData["ParentID"]);
                    person.SpouseID = Convert.ToInt32(tableData["SpouseID"]);
                    person.Image = (byte[])tableData["Image"];
                    persons.Add(person);
                }

                return persons;
            }
            );
            return persons;
        }

    }
}