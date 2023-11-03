using WarehouseApp.MVC.Data;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Repositories {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) {
            _context = context;
        }
        public bool EmployeeExists(int employeeId) {
            return _context.Employees.Any(e => e.Id == employeeId);
        }
        public Employee GetEmployee(int employeeId) {
            return _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
        }
        public ICollection<Employee> GetEmployees() {
            return _context.Employees.ToList();
        }
        public ICollection<Requisition> GetRequisitionsByEmployee(int employeeId) {
            return _context.Requisitions.Where(e => e.EmployeeId == employeeId).ToList();
        }
        public Login GetLoginOfAEmployee(int employeeId) {
            return _context.Employees.Where(e => e.Id == employeeId).Select(l => l.Login).FirstOrDefault();
        }
        public int GetLoginIdByEmployee(int employeeId) {
            return _context.Employees.Where(e => e.Id == employeeId).Select(e => e.LoginId).FirstOrDefault();
        }
        public bool CreateEmployee(Employee employee) {
            var login = new Login { UserLogin = employee.Email, Password = "" };

            employee.Login = login;

            _context.Employees.Add(employee);
            return Save();
        }
        public bool UpdateEmployee(Employee employee) {
            _context.Employees.Update(employee);
            return Save();
        }
        public bool DeleteEmployee(Employee employee) {
            var loginEmployee = _context.Logins.Where(e => e.Id == employee.LoginId).FirstOrDefault();

            _context.Logins.Remove(loginEmployee);

            _context.Employees.Remove(employee);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
