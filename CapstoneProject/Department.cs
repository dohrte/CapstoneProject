using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CapstoneProject
{
    public class Department
    {
        //SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
        //                                                   "password=Abc123!!;" +
        //                                                   "server=SQLSERVER480;" +
        //                                                   "Trusted_Connection=yes;" +
        //                                                   "database=UTSDB; " +
        //                                                   "connection timeout=10");
        SqlConnection sqlConnection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);

        public bool SetDepartment(string departmentName, string departmentAbbreviation)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("INSERT INTO Department (DepartmentName, DepartmentAbbreviation) VALUES ('" + departmentName + "', '" + departmentAbbreviation + "');", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable GetDepartment()
        {
            DataTable dt = new DataTable();

            try
            {
                sqlConnection.Open();
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Department", sqlConnection);                
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

        public bool UpdateDepartment(int departmentId, string departmentName, string departmentAbbreviation)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("UPDATE Department SET DepartmentName = '" + departmentName + "' ,DepartmentAbbreviation = '" + departmentAbbreviation + "'  WHERE DepartmentID = " +  departmentId + ";", sqlConnection);
                mySetCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteDepartment(int departmentId)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand mySetCommand = new SqlCommand("DELETE FROM Department WHERE DepartmentID = " + departmentId + ";", sqlConnection);
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