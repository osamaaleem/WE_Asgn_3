using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WE_Asgn_3.Models;

namespace WE_Asgn_3.DAL
{
    public class MobileEntity
    {
        public MobileEntity()
        {
            sqlConnection = new SqlConnection(connection);
        }
        private int rowsAffected = 0;
        private string connection = @"data source = DESKTOP-7GUB027\SQLEXPRESS; initial catalog = SqlProjectdb; integrated security = True";
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private string query;
        private SqlDataReader sqlDataReader = null;
        public int AddMobile(Mobile mobile)
        {
            query = $"INSERT INTO Mobile(imei, os, releaseDate," +
                $" color, weight_grams, model_no, ram_gb," +
                $" price) VALUES ('{mobile.Imei}','{mobile.OprSys.Name}'," +
                $"'{mobile.ReleaseDate.ToShortDateString()}', '{mobile.Color}','{mobile.GramWeight}'," +
                $"'{mobile.ModelNo}','{mobile.GbRam}','{mobile.Price}')";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                rowsAffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            return rowsAffected;
        }
        public List<Mobile> GetMobiles()
        {
            List<Mobile> mobList = new List<Mobile>();
            query = "SELECT * FROM Mobile";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                mobList.Add(new Mobile
                {
                    Id = Convert.ToInt32(sqlDataReader["id"].ToString()),
                    Imei = sqlDataReader["imei"].ToString(),
                    OprSys = new OprSys { Name = sqlDataReader["os"].ToString() },
                    Color = sqlDataReader["color"].ToString(),
                    GbRam = Convert.ToInt32(sqlDataReader["ram_gb"].ToString()),
                    GramWeight = Convert.ToInt32(sqlDataReader["weight_grams"].ToString()),
                    Price = Convert.ToInt32(sqlDataReader["price"].ToString()),
                    ModelNo = sqlDataReader["model_no"].ToString(),
                    ReleaseDate = Convert.ToDateTime(sqlDataReader["releaseDate"].ToString()),
                    ShortDate = Convert.ToDateTime(sqlDataReader["releaseDate"].ToString()).ToShortDateString(),
                });
            }
            sqlConnection.Close();
            return mobList;
        }
    }
}