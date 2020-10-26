using System.Data.SQLite;

namespace DAL.Gateways
{
    public class ClientGateway
    {
        public SQLiteDataReader GetAllClients()
        {
            var commandText = "SELECT * FROM Clients";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public SQLiteDataReader GetClientWithCNP(string cnp)
        {
            var commandText = "SELECT * FROM Clients WHERE cnp = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());
            sqlCommand.Parameters.AddWithValue("cnp", cnp);

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public void InsertClient(string name, string cnp, string address, string phone)
        {
            var commandText = "INSERT INTO Clients VALUES (@idClient, @name, @cnp, @address, @phone)";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.Add(new SQLiteParameter("idClient"));
            sqlCommand.Parameters.Add(new SQLiteParameter("name", name));
            sqlCommand.Parameters.Add(new SQLiteParameter("cnp", cnp));
            sqlCommand.Parameters.Add(new SQLiteParameter("address", address));
            sqlCommand.Parameters.Add(new SQLiteParameter("phone", phone));
            sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

        }

        public void UpdateClient(int idClient, string name, string cnp, string address, string phone)
        {
            var commandText = "UPDATE Clients SET name = ?, cnp = ?, address = ?, phone = ? WHERE idClient = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.Add(new SQLiteParameter("name", name));
            sqlCommand.Parameters.Add(new SQLiteParameter("cnp", cnp));
            sqlCommand.Parameters.Add(new SQLiteParameter("address", address));
            sqlCommand.Parameters.Add(new SQLiteParameter("phone", phone));
            sqlCommand.Parameters.Add(new SQLiteParameter("idClient", idClient));
            sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

        }

    }
}
