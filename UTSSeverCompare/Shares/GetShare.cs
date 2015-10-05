using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1.Shares
{
    class GetShare
    {
        SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
                                                           "password=Abc123!!;" +
                                                           "server=SQLSERVER480;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=UTSDB; " +
                                                           "connection timeout=10");

        public DataTable GetUTSShare()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand getUsers = new SqlCommand("SELECT * FROM Share", sqlConnection);

                sqlConnection.Open();

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
    }
}
