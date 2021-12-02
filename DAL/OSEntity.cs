using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using WE_Asgn_3.Models;

namespace WE_Asgn_3.DAL
{
    public class OSEntity
    {
        public OSEntity()
        {
            sqlConnection = new SqlConnection(connection);
        }
        private int rowsAffected = 0;
        private string connection = @"data source = DESKTOP-7GUB027\SQLEXPRESS; initial catalog = SqlProjectdb; integrated security = True";
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private string query;
        private SqlDataReader sqlDataReader = null;
        public List<SelectListItem> getOS()
        {
            int val = 0;
            query = "SELECT * FROM OperatingSystems";
            List<OprSys> osList = new List<OprSys>();
            List<SelectListItem> selectOsList = new List<SelectListItem>();
            sqlConnection.Open();
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                osList.Add(new OprSys { Name = sqlDataReader["name"].ToString() });
            }
            sqlConnection.Close();
            foreach (OprSys os in osList)
            {
                val++;
                selectOsList.Add(new SelectListItem { Value = os.Name, Text = os.Name });
            }
            return selectOsList;
        }
    }
}