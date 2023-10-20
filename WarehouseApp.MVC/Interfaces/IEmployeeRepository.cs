﻿using WarehouseApp.Domain.Entities;

namespace WarehouseApp.MVC.Interfaces {
    public interface IEmployeeRepository {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        bool EmployeeExists(int employeeId);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}