using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;
using lottoalgo.Controllers;
using lottoalgo.DTO;
using System;

namespace lottoalgo.Controllers
{
    public static class MySQLConnection
    {
        const string CONNECTION_STRING = "Database=lottoalgo;Data Source=localhost;User Id=ulottoalgo;Password=pwinner";

        public static List<Dto> Query(string sql, Type dtoType)
        {
            List<Dto> results = new List<Dto>();

            MySqlDataReader reader = GetReader(sql);
            while (reader.Read())
            {
                reader.GetString(0);
                dynamic result = Activator.CreateInstance(dtoType);
                PropertyInfo[] properties = dtoType.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    string propName = property.Name;
                    dynamic value = Convert.ChangeType(reader[propName], property.PropertyType);
                    property.SetValue(result, value);
                }
                results.Add((Dto) result);
            }
            reader.Close();
            return results;
        }

        private static MySqlDataReader GetReader(string sql)
        {
            MySqlConnection connection = new MySqlConnection(CONNECTION_STRING);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteReader();
        }
    }
}
