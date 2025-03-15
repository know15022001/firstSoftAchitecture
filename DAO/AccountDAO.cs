using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    class AccountDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Account> SelectByKeyword(String keyword)
        {
            List<Account> accs = new List<Account>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Account WHERE Name LIKE @Keyword";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                Account acc = new Account()
                {
                    username = (String)dr["Name"],

                };
                accs.Add(acc);
            }
            con.Close();
            return accs;
        }
    }
}
