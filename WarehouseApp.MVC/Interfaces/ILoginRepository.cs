using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Interfaces {
    public interface ILoginRepository {
        Login GetLogin(int loginId);
        ICollection<Login> GetLogins();
        bool LoginExists(int loginId);
        bool UserLoginExists(string userLogin);
        bool UserPasswordExists(string password);
        bool UpdateLogin(Login login);
        bool DeleteLogin(Login login);
        bool Save();
    }
}
