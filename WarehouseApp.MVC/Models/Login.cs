namespace WarehouseApp.MVC.Models {
    public class Login {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
