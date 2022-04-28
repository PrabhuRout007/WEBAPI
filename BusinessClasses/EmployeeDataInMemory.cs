#region Imports

using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Contracts;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace EmployeeAPI.Business
{
    public class EmployeeDataInMemory : IEmployeeBusiness
    {
        private List<Employee> emplist;
        public EmployeeDataInMemory()
        {
            emplist = new();
        }

        public Task<bool> AddEmployee(Employee emp)
        {
            emp.Id = emplist.Count+1;
            emplist.Add(emp);
            return Task.FromResult(true);
        }

        public Task<List<Employee>> GetEmployee()
        {
            return Task.FromResult(emplist);
        }

        public  Task<Employee> GetEmployee(int Id)
        {
            return Task.FromResult(emplist.Where(obj=>obj.Id== Id).FirstOrDefault());
        }
        public  Task<bool> UpdateEmployee([FromHeader] int id, Employee emp)
        {
            var empdata = emplist.Where(obj => obj.Id == id).FirstOrDefault();
            empdata = emp;
            return Task.FromResult(true);
        }

        public  Task<bool> DeleteEmployee([FromHeader] int Id)
        {
            var empdata = emplist.Where(obj => obj.Id == Id).FirstOrDefault();
            if (empdata != null)
            {
                emplist.Remove(empdata);
            }
            return Task.FromResult(true);
        }
    }
}
