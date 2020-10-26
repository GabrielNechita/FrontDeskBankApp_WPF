using System;
using System.Data.SQLite;

namespace DAL.Gateways
{
    public class EmployeesGateway
    {
        public SQLiteDataReader GetAllEmployees()
        {
            var commandText = "SELECT * FROM Employees";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public SQLiteDataReader GetEmployeeIdAndPassword()
        {
            var commandText = "SELECT idEmployee, password FROM Employees ";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public void InsertEmployee(string name, float salary, string password)
        {
            var commandText = "INSERT INTO Employees VALUES (@idEmployee, @name, @salary, @password)";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.Add(new SQLiteParameter("idEmployee"));
            sqlCommand.Parameters.Add(new SQLiteParameter("name", name));
            sqlCommand.Parameters.Add(new SQLiteParameter("salary", salary));
            sqlCommand.Parameters.Add(new SQLiteParameter("password", password));
            sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

        }

        public void UpdateEmployee(int id, string name, float salary, string password)
        {
            var commandText = "UPDATE Employees SET name = ?, salary = ?, password = ? WHERE idEmployee = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.Add(new SQLiteParameter("name", name));
            sqlCommand.Parameters.Add(new SQLiteParameter("salary", salary));
            sqlCommand.Parameters.Add(new SQLiteParameter("password", password));
            sqlCommand.Parameters.Add(new SQLiteParameter("idEmployee", id));
            sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

        }

        public void DeleteEmployee(int idEmployee)
        {
            var commandText = "DELETE FROM Employees WHERE idEmployee = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.AddWithValue("idEmployee", idEmployee);
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();

        }
    }
}
