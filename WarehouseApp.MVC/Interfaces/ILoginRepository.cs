using WarehouseApp.Domain.Entities;

namespace WarehouseApp.MVC.Interfaces {
    public interface ILoginRepository {
        ICollection<Login> GetLogins();
        Login GetLoginOfAEmployee(int employeeId);
        bool LoginExists(string login);
        bool CreateLogin(Login login);
        bool UpdateLogin(Login login);
        bool DeleteLogin(Login login);
        bool Save();
    }
}
