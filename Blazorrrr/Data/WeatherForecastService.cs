using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Blazorrrr.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
               {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherForecast> lst = new List<WeatherForecast>();

        public async void GetForecastAsync()
        {
            string connectionString = "Data Source=172.30.27.217;Initial Catalog=museumdb;Persist Security Info=True;User ID=museumdb;Password=\"Tw'5!=\"j;F4c*0";
            //string connectionString = @"Data Source=DESKTOP-OS1FU9G\SQLEXPRESS;Initial Catalog=AutoProcat;Integrated Security=True";
            var contract = new List<WeatherForecast>();
            string sqlExpression = $"SELECT * FROM Student";
            SqlConnection connection = new SqlConnection(connectionString);

            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();

            WeatherForecast contrac = new WeatherForecast();
            if (reader.HasRows) // если есть данные
            {
                while (await reader.ReadAsync()) // построчно считываем данные
                {
                    //MessageBox.Show(reader.GetValue(0).ToString());
                    contrac = new WeatherForecast();
                    contrac.Name = reader.GetValue(0).ToString();
                    contrac.Surname = reader.GetValue(1).ToString();
                    contrac.MiddleName = reader.GetValue(2).ToString();
                    contrac.Activities = reader.GetValue(3).ToString();
                    contrac.IdGroup = int.Parse(reader.GetValue(3).ToString());
                    contrac.IdPhoto = int.Parse(reader.GetValue(3).ToString());
                    contract.Add(contrac);
                }
            }
            await reader.CloseAsync();


            lst = contract;
        }
    }
}
