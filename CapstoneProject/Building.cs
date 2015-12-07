using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CapstoneProject
{
    public class Building
    {
        SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);

        public bool SetBuilding(string buildingName, string buildingAbbreviation)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("INSERT INTO Building (BuildingName, BuildingAbbreviation) VALUES ('" + buildingName + "', '" + buildingAbbreviation + "');", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetBuilding()
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Building", sqlConnection);
                SqlDataReader myReader = getUsers.ExecuteReader();
                dt.Load(myReader);
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return dt;
        }

        public bool UpdateBuilding(int buildingId, string buildingName, string buildingAbbreviation)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("UPDATE Building SET BuildingName = '" + buildingName + "' ,BuildingAbbreviation = '" + buildingAbbreviation + "'  WHERE BuildingID = " + buildingId + ";", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteBuilding(int buildingId)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("DELETE FROM Building WHERE BuildingID = " + buildingId + ";", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}