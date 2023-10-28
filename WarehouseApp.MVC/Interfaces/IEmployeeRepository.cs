using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Interfaces {
    public interface IEmployeeRepository {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        ICollection<Requisition> GetRequisitionsByEmployee(int employeeId);
        bool EmployeeExists(int employeeId);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}
