using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DAL.Gateways
{
    public class ActivitiesGateway
    {
        public SQLiteDataReader GetActivitiesByEmployee(int idEmployee)
        {
            var commandText = "SELECT * FROM Activities WHERE idEmployee = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());
            sqlCommand.Parameters.AddWithValue("idEmployee", idEmployee);

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public void InsertActivity(int idEmployee, string type, DateTime date)
        {
            var commandText = "INSERT INTO Activities VALUES (@idActivity, @idEmployee, @type, @date)";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.Add(new SQLiteParameter("idActivity"));
            sqlCommand.Parameters.Add(new SQLiteParameter("idEmployee", idEmployee));
            sqlCommand.Parameters.Add(new SQLiteParameter("type", type));            
            sqlCommand.Parameters.Add(new SQLiteParameter("date", date));
            
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
        }
    }
}
