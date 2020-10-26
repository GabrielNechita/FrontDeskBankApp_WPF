using DAL.Gateways;
using System;
using System.Collections.Generic;
using System.Collections;
namespace BL.Users
{
    public class User
    {
        public string Username;

        public string Password;


        public Hashtable GetIdEmployeePassword()
        {
            var reader = new EmployeesGateway().GetEmployeeIdAndPassword();
            var employeesHashtable = new Hashtable();
            while (reader.Read())
            {
                employeesHashtable.Add(Convert.ToInt32(reader.GetValue(0)), Password = reader.GetValue(1).ToString());
            }

            return employeesHashtable;

        }

        public IList<object> GetAllClients()
        {
            var reader = new ClientGateway().GetAllClients();

            var clientsList = new List<object>();
            while (reader.Read())
            {
                clientsList.Add(new
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    Name = reader.GetValue(1).ToString(),
                    Cnp = reader.GetValue(2).ToString(),
                    Address = reader.GetValue(3).ToString(),
                    Phone = reader.GetValue(4).ToString()
                });
            }

            return clientsList;
        }

        public IList<object> GetAccountsByClientId(int id)
        {
            var reader = new AccountGateway().GetClientAccounts(id);

            var accountsList = new List<object>();
            while (reader.Read())
            {
                accountsList.Add(new
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    Type = reader.GetValue(1).ToString(),
                    Money = float.Parse(reader.GetValue(2).ToString()),
                    CreationDate = Convert.ToDateTime(reader.GetValue(3).ToString())
                });
            }

            return accountsList;
        }

        public float GetMoneyAmountByAccountId(int accountId)
        {
            var reader = new AccountGateway().GetMoneyAmountByAccountId(accountId);

            var list = new List<object>();
            float amount = 0;
            while (reader.Read())
            {
               amount = float.Parse(reader.GetValue(0).ToString());
            }

            return amount;
        }

        public void DeleteAccount(int idAccount)
        {
            new AccountGateway().DeleteAccount(idAccount);
        }

        public void InsertClient(string name, string cnp, string address, string phone)
        {
            new ClientGateway().InsertClient(name, cnp, address, phone);
        }

        public void UpdateClient(int id, string name, string cnp, string address, string phone)
        {
            new ClientGateway().UpdateClient(id, name, cnp, address, phone);
        }

        public void InsertAccount(string type, float money, DateTime creationDate, int idClient)
        {
            new AccountGateway().InsertAccount(type, money, creationDate, idClient);
        }

        public void UpdateAccount(int idAccount, string type, float money, DateTime creationDate)
        {
            new AccountGateway().UpdateAccount(idAccount, type, money, creationDate);
        }

        public void Transfer(int idFrom, int idTo, float amount)
        {
            new AccountGateway().TransferTo(idFrom, idTo, amount);
        }

        public void PayBill(int idAccount, float amount)
        {
            new AccountGateway().PayBill(idAccount, amount);
        }

        public void AddActivity(int idEmloyee, string type, DateTime today)
        {
            new ActivitiesGateway().InsertActivity(idEmloyee, type, today);
        }
    }
}
