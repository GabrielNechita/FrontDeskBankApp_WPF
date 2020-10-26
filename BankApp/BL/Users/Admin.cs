using DAL.Gateways;
using System;
using System.Collections.Generic;

namespace BL.Users
{
    public class Admin
    {
        public string Username => "admin";

        public string Password => "1234";

        public IList<object> GetAllEmployees()
        {
            var reader = new EmployeesGateway().GetAllEmployees();

            var employeesList = new List<object>();
            while (reader.Read())
            {
                employeesList.Add(new
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    Name = reader.GetValue(1).ToString(),
                    Salary = float.Parse(reader.GetValue(2).ToString())
                });
            }
            
            return employeesList;
        }

        public IList<object> GetActivitiesByIdEmployees(int idEmployee)
        {
            var reader = new ActivitiesGateway().GetActivitiesByEmployee(idEmployee);

            var activitiesList = new List<object>();
            while (reader.Read())
            {
                activitiesList.Add(new
                {
                    Type = reader.GetValue(2).ToString(),
                    Date = Convert.ToDateTime(reader.GetValue(3).ToString())
                });               
            }

            return activitiesList;
        }

        public void InsertEmployee(string name, float salary, string password)
        {
            new EmployeesGateway().InsertEmployee(name, salary, password);
        }

        public void UpdateEmployee(int idEmployee, string name, float salary, string  password)
        {
            new EmployeesGateway().UpdateEmployee(idEmployee, name, salary, password);
        }

        public void DeleteEmployee(int idEmployee)
        {
            new EmployeesGateway().DeleteEmployee(idEmployee);
        }
    }
}
