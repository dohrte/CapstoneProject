using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1.Users
{
    class SetUsers
    {
        SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
                                                           "password=Abc123!!;" +
                                                           "server=SQLSERVER480;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=UTSDB; " +
                                                           "connection timeout=10");
        public void SetUTSUsers()
        {
            GetUser g = new GetUser();

            //GetADUsers

            //GetUTSUsers

            DataTable utsUsers = new DataTable();
            utsUsers = g.GetUTSUsers();

            //Compare

            //SetUTSUsers
        }

    }
}
