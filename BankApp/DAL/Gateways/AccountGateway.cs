using System;
using System.Data.SQLite;

namespace DAL.Gateways
{
    public class AccountGateway
    {
        public SQLiteDataReader GetAllAccounts()
        {
            var commandText = "SELECT * FROM Accounts";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public SQLiteDataReader GetClientAccounts(int idClient)
        {
            var commandText = "SELECT * FROM Accounts WHERE idClient = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());
            sqlCommand.Parameters.AddWithValue("idAccount", idClient);

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }

        public SQLiteDataReader GetMoneyAmountByAccountId(int idAccount)
        {
            var commandText = "SELECT Money FROM Accounts WHERE idAccount = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());
            sqlCommand.Parameters.AddWithValue("idAccount", idAccount);

            sqlCommand.Connection.Open();

            return sqlCommand.ExecuteReader();
        }


        public void InsertAccount(string type, float money, DateTime creationDate, int clientId)
        {
            var commandText = "INSERT INTO Accounts VALUES (@idAccount, @type, @money, @creationDate, @clientId)";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.Add(new SQLiteParameter("idAccount"));
            sqlCommand.Parameters.Add(new SQLiteParameter("type", type));
            sqlCommand.Parameters.Add(new SQLiteParameter("money", money));
            sqlCommand.Parameters.Add(new SQLiteParameter("creationDate", creationDate));
            sqlCommand.Parameters.Add(new SQLiteParameter("clientId", clientId));
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateAccount(int idAccount, string type, float money, DateTime creationDate)
        {
            var commandText = "UPDATE Accounts SET type = ?, money = ?, creationDate = ? WHERE idAccount = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());
          
            sqlCommand.Parameters.Add(new SQLiteParameter("type", type));
            sqlCommand.Parameters.Add(new SQLiteParameter("money", money));
            sqlCommand.Parameters.Add(new SQLiteParameter("creationDate", creationDate));
            sqlCommand.Parameters.Add(new SQLiteParameter("idAccount", idAccount));
            sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

        }

        public void DeleteAccount(int idAccount)
        {
            var commandText = "DELETE FROM Accounts WHERE idAccount = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());

            sqlCommand.Parameters.AddWithValue("idAccount", idAccount);

            sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

        }

        public void TransferTo(int idForm, int idTo, float amount)
        {
            var commandText = "UPDATE Accounts SET money = money - ? WHERE idAccount = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());           
            sqlCommand.Parameters.Add(new SQLiteParameter("amount", amount));
            sqlCommand.Parameters.Add(new SQLiteParameter("idFrom", idForm));

            var commandText2 = "UPDATE Accounts SET money = money + ? WHERE idAccount = ?";
            var sqlCommand2 = new SQLiteCommand(commandText2, Configurations.GetConnectionString());
            sqlCommand2.Parameters.Add(new SQLiteParameter("amount", amount));
            sqlCommand2.Parameters.Add(new SQLiteParameter("idTo", idTo));

            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand2.Connection.Open();
            sqlCommand2.ExecuteNonQuery();
        }

        public void PayBill(int idAccount, float amount)
        {
            var commandText = "UPDATE Accounts SET money = money - ? WHERE idAccount = ?";
            var sqlCommand = new SQLiteCommand(commandText, Configurations.GetConnectionString());
            sqlCommand.Parameters.Add(new SQLiteParameter("amount", amount));
            sqlCommand.Parameters.Add(new SQLiteParameter("idAccount", idAccount));

            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();

        }

    }
}
