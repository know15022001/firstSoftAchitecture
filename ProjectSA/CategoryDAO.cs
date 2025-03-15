using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSA
{
    public class CategoryDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Category> SelectAll()
        {
            List<Category> categories = new List<Category>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Category";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Category Category = new Category()
                {
                    Code = (String)dr["Code"],
                    Name = (String)dr["Name"],
                    
                };
                categories.Add(Category);
            }
            con.Close();
            return categories;
        }
        public Category SelectByCode(string Code)
        {
            Category category = null;
            SqlConnection con = new SqlConnection(strCon); 
            con.Open();
            String strCom = "SELECT * FROM Category WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", Code));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                category = new Category()
                {
                    Code = (String)dr["Code"],
                    Name = (String)dr["Name"],
                   
                };
            }
            con.Close();
            return category;
        }
        public List<Category> SelectByKeyword(String keyword)
        {
            List<Category> categories = new List<Category>();
            SqlConnection con = new SqlConnection(strCon); 
            con.Open();
            String strCom = "SELECT * FROM Category WHERE Name LIKE @Keyword";
            SqlCommand com = new SqlCommand(strCom, con); 
            com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            SqlDataReader dr = com.ExecuteReader(); while (dr.Read())
            {
                Category category = new Category()
                {
                    Code = (String)dr["Code"],
                    Name = (String)dr["Name"],
               
                };
                categories.Add(category);
            }
            con.Close();
            return categories;
        }
        public bool Insert(Category newCategory)
        {
            bool result = false; SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "INSERT INTO Category (Code,Name) VALUES (@Code,@Name)";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", newCategory.Code));
            com.Parameters.Add(new SqlParameter("@Name", newCategory.Name));

            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
        public bool Update(Category newCategory)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //String strCom = "UPDATE Book SET Code=@Code,Name=@Name, Country=@Country WHERE Code = @Code";
            String strCom = "UPDATE Category SET Name=@Name WHERE Code = @Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", newCategory.Code));
            com.Parameters.Add(new SqlParameter("@Name", newCategory.Name));

            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
        public bool Delete(string Code)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "DELETE FROM Category WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", Code));
            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
    }
}

