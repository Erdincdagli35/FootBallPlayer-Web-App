using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FootballicaWebApp.Models
{
    public class FootballerDAL
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        public IEnumerable<Footballer> GetAllFootballer() 
        {
            List<Footballer> footList = new List<Footballer>();

            using (SqlConnection con = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("SP_GetAllFootballer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    Footballer foot = new Footballer();
                    foot.Id = Convert.ToInt32(dr["Id"].ToString());
                    foot.Name = dr["Name"].ToString();
                    foot.Position = dr["Position"].ToString();
                    foot.Team = dr["Team"].ToString();
                    foot.Nationalty = dr["Nationalty"].ToString();

                    footList.Add(foot);
                }
                con.Close();
            }
            return footList;
        }

        //To Insert Footballer
        public void AddFootballer(Footballer foot) 
        {
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("SP_InsertFootballer",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name",foot.Name);
                cmd.Parameters.AddWithValue("@Position", foot.Position);
                cmd.Parameters.AddWithValue("@Team", foot.Team);
                cmd.Parameters.AddWithValue("@Nationalty", foot.Nationalty);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //To Update Footballer
        public void UpdateFootballer(Footballer foot)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateFootballer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", foot.Id);
                cmd.Parameters.AddWithValue("@Name", foot.Name);
                cmd.Parameters.AddWithValue("@Position", foot.Position);
                cmd.Parameters.AddWithValue("@Team", foot.Team);
                cmd.Parameters.AddWithValue("@Nationalty", foot.Nationalty);
        

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //To Delete Footballer
        public void DeleteFootballer(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteFootballer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@F_Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        //Get Football by Id
        public Footballer GetFootballerBy(int? fID)
        {
            Footballer foot = new Footballer();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetFootballerByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@F_Id",fID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    foot.Id = Convert.ToInt32(dr["Id"].ToString());
                    foot.Name = dr["Name"].ToString();
                    foot.Position = dr["Position"].ToString();
                    foot.Team = dr["Team"].ToString();
                    foot.Nationalty = dr["Nationalty"].ToString();

                }
                con.Close();
            }
            return foot;
        }
    }
}
