﻿using WarehouseApp.Domain.Entities;
using WarehouseApp.Infra.Data.DataContext;
using WarehouseApp.MVC.Interfaces;

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
        public bool CreateEmployee(Employee employee) {
            _context.Employees.Add(employee);
            return Save();
        }
        public bool UpdateEmployee(Employee employee) {
            _context.Employees.Update(employee);
            return Save();
        }
        public bool DeleteEmployee(Employee employee) {
            _context.Employees.Remove(employee);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
