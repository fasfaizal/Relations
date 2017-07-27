using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonRelations
{
    public class LoginDetails
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Save(int personid,string name,string password)
        {
            DBExecutor<int> dbExecutor = new DBExecutor<int>();
            return dbExecutor.Execute(delegate (SqlCommand myCommand)
            {
                int updatedRows;
                myCommand.CommandText = string.Format("INSERT INTO LoginDetails VALUES({0},'{1}','{2}')", personid, name, password);
                updatedRows = myCommand.ExecuteNonQuery();
                return updatedRows;
            }
            );
        }
        public static LoginDetails Read(string uName)
        {
            DBExecutor<LoginDetails> db = new DBExecutor<LoginDetails>();
            return db.Execute(delegate (SqlCommand cmd)
            {
                cmd.CommandText = string.Format("SELECT * FROM LoginDetails WHERE UserName='{0}'" , uName);
                var dr = cmd.ExecuteReader();
                LoginDetails ib = new LoginDetails();
                while (dr.Read())
                {
                    ib.ID = Convert.ToInt32(dr["ID"]);
                    ib.PersonID = Convert.ToInt32(dr["PersonID"]);
                    ib.UserName = Convert.ToString(dr["UserName"]);
                    ib.Password = Convert.ToString(dr["Password"]);
                }
                return ib;
            });
        }
    }
}