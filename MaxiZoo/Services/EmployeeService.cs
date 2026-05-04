using MaxiZoo.Models;
using MaxiZoo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(string name, int employeeId, Role role)
        {
            Employee employee = new Employee
            {
                Name = name,
                EmployeeID = employeeId,
                Role = role
            };

            _employeeRepository.AddEmployee(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}
