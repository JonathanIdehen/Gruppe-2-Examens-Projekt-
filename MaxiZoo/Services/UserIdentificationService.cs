using MaxiZoo.Models;
using MaxiZoo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Services
{
    public class UserIdentificationService
    {
        private readonly EmployeeRepository _employeeRepository;

        public UserIdentificationService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee? IdentifyUser(int employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }
        // bruger EmployeeRepositoriet til at slå brugeren op.
    }
}
