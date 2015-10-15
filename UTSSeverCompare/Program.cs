using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsService1.Groups;
using WindowsService1.Users;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection("user id=swright;" +
                                                           "password=Abc123!!;" +
                                                           "server=SQLSERVER480;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=UTSDB; " +
                                                           "connection timeout=10");
            try
            {
                //sqlConnection.Open();
                ////SqlCommand mySetCommand = new SqlCommand("insert into Groups (GroupsManager, GroupsName) values ('test', 'test2');", sqlConnection);
                //SqlCommand mySetCommand = new SqlCommand("insert into Department (DepartmentName, DepartmentAbbreviation) values ('test', 'test2');", sqlConnection);

                //mySetCommand.ExecuteNonQuery();

                //SqlDataReader myReader = null;
                //SqlCommand myGetCommand = new SqlCommand("select * from Groups", sqlConnection);
                //myReader = myGetCommand.ExecuteReader();

                //DataTable dt = new DataTable();
                //dt.Load(myReader);

                //sqlConnection.Close();


            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write(e.ToString());
            }

            GetUser t = new GetUser();
            t.GetGroups();
            string t3 = null;
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
        }

        


    }
}
