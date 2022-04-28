#region Imports
using EmployeeAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace EmployeeAPI.Contracts
{
    public interface IEmployeeBusiness
    {
        Task<List<Employee>> GetEmployee();
        Task<Employee> GetEmployee(int Id);
        Task<bool> AddEmployee(Employee emp);
        Task<bool> UpdateEmployee(int id, Employee emp);
        Task<bool> DeleteEmployee(int id);
    }
}
