using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Labo_Tool_2
{
    class ReadFiles
    {
        public static SqlConnection databaseConnection = new SqlConnection(@"Data Source=LAPTOP-2RD68A3P\SQLEXPRESS01;Initial Catalog=Lander Kellens Labo;Integrated Security=True");

        //inlezen alle files
        public static string[] FileLees(String file)
        {
            return File.ReadAllLines(file);
        }


        //inlezen straat
        public static void StratenLees(string[] lines)
        {
            lines = lines.Skip(1).ToArray();
            foreach (string line in lines)
            {
                StraatInvoegen(line);
            }
        }


        //inlezen Provincie
        public static void ProvincieLees(string[] lines)
        {
            lines = lines.Skip(1).ToArray();
            foreach (string line in lines)
            {
                ProvincieInvoegen(line);
            }
        }


        //inlezen gemeentes
        public static void GemeenteLees(string[] lines)
        {
            lines = lines.Skip(1).ToArray();
            foreach (string line in lines)
            {
                GemeenteInvoegen(line);
            }
        }


        //straat invoegen databank
        public static void StraatInvoegen(string line)
        {
            databaseConnection.Open();
            String[] info = line.Split(";");
            
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Straten] (ID,STRAATNAAM,LENGTE,SEGMENT) VALUES (@id,@naam,@lengte,@segment)", databaseConnection);
            command.Parameters.AddWithValue("@id", info[0]);
            command.Parameters.AddWithValue("@naam", info[1]);
            command.Parameters.AddWithValue("@lengte", info[2]);
            command.Parameters.AddWithValue("@segment", info[3]);


            SqlDataAdapter sqlAdapt = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            sqlAdapt.Fill(set);

            databaseConnection.Close();
        }


        //provincie invoegen databank
        public static void ProvincieInvoegen(string line)
        {
            databaseConnection.Open();
            String[] info = line.Split(";");

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Provincie] (ID,PROVINCIENAAM,GEMEENTEID) VALUES (@id,@naam,@gemeenteid)", databaseConnection);
            command.Parameters.AddWithValue("@id", info[0]);
            command.Parameters.AddWithValue("@naam", info[1]);
            command.Parameters.AddWithValue("@gemeenteid", info[2]);


            SqlDataAdapter sqlAdapt = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            sqlAdapt.Fill(set);

            databaseConnection.Close();
        }

        //gemeente invoegen databank
        public static void GemeenteInvoegen(string line)
        {
            databaseConnection.Open();
            String[] info = line.Split(";");

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Gemeente] (ID,GEMEENTENAAM,STRAATID,MIN,MAX) VALUES (@id,@naam,@straatid,@min,@max)", databaseConnection);
            command.Parameters.AddWithValue("@id", info[0]);
            command.Parameters.AddWithValue("@naam", info[1]);
            command.Parameters.AddWithValue("@straatid", info[2]);
            command.Parameters.AddWithValue("@min", info[3]);
            command.Parameters.AddWithValue("@max", info[4]);


            SqlDataAdapter sqlAdapt = new SqlDataAdapter(command);
            DataSet set = new DataSet();
            sqlAdapt.Fill(set);

            databaseConnection.Close();
        }
    }
}