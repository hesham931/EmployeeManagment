using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Modual
{
    public class GetInformationEmployee : IRepesetoryEmployee
    {
        private List<Employee> _employee;
        public GetInformationEmployee()
        {
            _employee = new List<Employee>()
            {
                new Employee{
                    Id = 1,
                    Name = "Hesham",
                    Department = Dept.It,
                    Email = "heshammosa135@gmail.com",
                    Status = "active"
                },
                new Employee{
                    Id = 2,
                    Name = "Hosam",
                    Department = Dept.Hr,
                    Email = "hosammosa135@gmail.com",
                    Status = "active"
                },
                new Employee{
                    Id = 3,
                    Name = "Ali",
                    Department = Dept.CustomerService,
                    Email = "Ali135@gmail.com",
                    Status = "active"
                },
                new Employee{
                    Id = 4,
                    Name = "Mohammad",
                    Department = Dept.selling,
                    Email = "mohammad135@gmail.com",
                    Status = "active"
                },
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employee.FirstOrDefault<Employee>(el => el.Id == id);
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employee;
        }
        public Employee AddNew(Employee employee)
        {
            if (_employee.Count() > 0)
                employee.Id = _employee.Max(em => em.Id) + 1;
            else
                employee.Id = 1;
            employee.Status = "Hold";

            _employee.Add(employee);
            return employee;
        }
        public Employee EditEmployee(Employee employee)
        {
            foreach(Employee el in _employee)
            {
                if(el.Id == employee.Id)
                {
                    el.Name = employee.Name;
                    el.Department = employee.Department;
                    el.Email = employee.Email;
                }
            }
            return employee;
        }
        public Employee DeleteEmployee(Employee employee)
        {
            _employee.Remove(employee);
            return employee;
        }
    }
}