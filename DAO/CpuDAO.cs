using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    
    class CpuDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        //MyDBDataContext db = new MyDBDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);
        public List<CPU> SelectAll()
        {
            List<CPU> cpus = new List<CPU>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM CPU";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                CPU cpu = new CPU()
                { 
                    ID = (int)dr["ID"],
                    Name = (String)dr["Name"],
                    Series = (String)dr["Series"],
                    Generation = (String)dr["Generation"],
                    Prices = (int)dr["Prices"],
                    Img = (byte[])dr["Img"],
                };
                cpus.Add(cpu);
            }
            con.Close();
            return cpus;
            //List<CPU> cpus = db.Books.ToList();
            //return cpus;
        }
        public CPU SelectByCode(int id)
        {
            CPU cpu = null;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM CPU WHERE ID=@ID";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@ID", id));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                cpu = new CPU()
                {
                    ID = (int)dr["ID"],
                    Name = (String)dr["Name"],
                    Series = (String)dr["Series"],
                    Generation = (String)dr["Generation"],
                    Prices = (int)dr["Prices"],
                    Img = (byte[])dr["Img"],
                };  
            }
            con.Close();
            return cpu;
        }
        public List<CPU> SelectByKeyword(String keyword)
        {
            List<CPU> cpus = new List<CPU>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM CPU WHERE Name LIKE @Keyword";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword +"%"));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                CPU cpu = new CPU()
                {
                    ID = (int)dr["ID"],
                    Name = (String)dr["Name"],
                    Series = (String)dr["Series"],
                    Generation = (String)dr["Generation"],
                    Prices = (int)dr["Prices"],
                    Img = (byte[])dr["Img"],
                };
                cpus.Add(cpu);
            }
            con.Close();
            return cpus;
        }
        public bool Insert(CPU newCpu)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "INSERT INTO CPU(Name, Series, Generation, Prices, Img) VALUES(@Name, @Series,@Generation, @Prices, @Img)";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Name", newCpu.Name));
            com.Parameters.Add(new SqlParameter("@Series", newCpu.Series));
            com.Parameters.Add(new SqlParameter("@Generation", newCpu.Generation));
            com.Parameters.Add(new SqlParameter("@Prices", newCpu.Prices));
            com.Parameters.Add(new SqlParameter("@Img", newCpu.Img));
            try { result = com.ExecuteNonQuery() > 0; }
            catch { result = false; }
            con.Close();
            return result;
        }

        public bool Update(CPU newCpu)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "UPDATE CPU SET Name = @Name, Series=@Series, Generation=@Generation, Prices = @Prices, Img = @Img WHERE ID = @ID";
            SqlCommand com = new SqlCommand (strCom, con);
            com.Parameters.Add(new SqlParameter("@ID", newCpu.ID));
            com.Parameters.Add(new SqlParameter ("@Name", newCpu.Name));
            com.Parameters. Add(new SqlParameter ("@Series", newCpu.Series));
            com.Parameters.Add(new SqlParameter("@Generation", newCpu.Generation));
            com.Parameters.Add(new SqlParameter ("@Prices", newCpu.Prices));
            com.Parameters.Add(new SqlParameter("@Img", newCpu.Img));
            try { result = com. ExecuteNonQuery() > 0; }
            catch { result = false; }
            con.Close();
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "DELETE FROM CPU WHERE ID=@ID";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@ID", id));
            try { result = com.ExecuteNonQuery() > 0; }
            catch { result = false; }
            con.Close();
            return result;
        }
        public CPU SelectName(String name)
        {
            CPU cpu = null;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM CPU WHERE Name=@Name";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Name", name));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                cpu = new CPU()
                {
                    ID = (int)dr["ID"],
                    Name = (String)dr["Name"],
                    Series = (String)dr["Series"],
                    Generation = (String)dr["Generation"],
                    Prices = (int)dr["Prices"],
                    Img = (byte[])dr["Img"],
                };
            }
            con.Close();
            return cpu;
        }
    }
}
