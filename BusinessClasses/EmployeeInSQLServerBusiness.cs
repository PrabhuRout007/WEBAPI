#region Imports

using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Contracts;
using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRocords;

#endregion

namespace EmployeeAPI.Business
{
    public class EmployeeInSQLServerBusiness : IEmployeeBusiness
    {
        private readonly AppDbContext _context;
        public EmployeeInSQLServerBusiness(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddEmployee(Employee emp)
        {
            var result = _context.Add(emp);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public Task<List<Employee>> GetEmployee()
        {
            var data = _context.Employees.ToList();
            return Task.FromResult(data);
        }

        public  Task<Employee> GetEmployee(int Id)
        {
            var data = _context.Employees.Where(obj => obj.Id == Id).FirstOrDefault();
            return Task.FromResult(data);
        }
        public  Task<bool> UpdateEmployee(int id, Employee emp)
        {
            var ExistingData = _context.Employees.Where(obj => obj.Id == emp.Id).FirstOrDefault();
            if (ExistingData != null)
            {
                if (emp.Name != null)
                {
                    ExistingData.Name = emp.Name;
                }
            }
            var result = _context.Update(ExistingData);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public  Task<bool> DeleteEmployee(int Id)
        {
            var ExistingData = _context.Employees.Where(obj => obj.Id == Id).FirstOrDefault();
            if (ExistingData != null)
            {
                _context.Remove(ExistingData);
            }
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
