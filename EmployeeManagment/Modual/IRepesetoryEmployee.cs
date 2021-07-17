using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Modual
{
    public interface IRepesetoryEmployee
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployee();
        Employee AddNew(Employee employee);
        Employee EditEmployee(Employee employee);
        Employee DeleteEmployee(Employee employee);
    }
}
