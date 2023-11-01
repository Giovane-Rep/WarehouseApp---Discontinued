using WarehouseApp.MVC.Data;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Repositories {
    public class LoginRepository : ILoginRepository {
        private readonly DataContext _context;

        public LoginRepository(DataContext context) {
            _context = context;
        }
        public bool LoginExists(int loginId) {
            return _context.Logins.Any(l => l.Id == loginId);
        }
        public bool UserLoginExists(string userLogin) {
            return _context.Logins.Any(ul => ul.UserLogin == userLogin);
        }
        public bool UserPasswordExists(string password) {
            return _context.Logins.Any(p => p.Password == password);
        }
        public Login GetLogin(int loginId) {
            return _context.Logins.Where(l => l.Id == loginId).FirstOrDefault();
        }
        public ICollection<Login> GetLogins() {
            return _context.Logins.ToList();
        }
        public bool CreateLogin(Login login) {
            _context.Logins.Add(login);
            return Save();
        }
        public bool UpdateLogin(Login login) {
            _context.Logins.Update(login);
            return Save();
        }
        public bool DeleteLogin(Login login) {
            _context.Logins.Remove(login);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
