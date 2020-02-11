using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Gryphon.Net.Core.Launcher
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=DESKTOP-L2B8N96;Initial Catalog=GRYPHON;Integrated Security=True; Connection Timeout = 2");
            cmd.CommandText = "SELECT * FROM GROUP_DEFINITIONS";
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[2].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("=====");
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}