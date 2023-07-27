using DemoAPI27062023.Models;
using DemoAPI27062023.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI27062023.Repository.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Employee GetEmployeeById(int id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.ID == id);

           return emp;

        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public Employee PostEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }
        public Employee DeleteEmployee(int Id)
        {

           var emp= dbContext.Employees.SingleOrDefault(e =>e.ID==Id);
            if(emp!=null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return emp;
            }
            
            return null;
        }
        public Employee UpdateEmployee(Employee emp)
        {
            var ee = dbContext.Employees.SingleOrDefault(e => e.ID == emp.ID);
            
            if(ee !=null)
            {
                ee.First_Name = emp.First_Name;
                ee.Last_Name = emp.Last_Name;
                ee.Email = emp.Email;
                ee.Address = emp.Address;
                ee.Mobile = emp.Mobile;
                dbContext.Employees.Update(ee);
                dbContext.SaveChanges();
                return emp;
            }
            else
            {
                return null;
            }
            
            
        }
    }
}
