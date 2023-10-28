namespace WarehouseApp.MVC.Models {
    public class Employee {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Sector { get; set; }
        public string Delegation { get; set; }
        public bool Active { get; set; }
        public Login Login { get; set; }
        public ICollection<RequisitionEmployee> RequisitionEmployees { get; set; }
        public ICollection<Login> Logins { get; set; }
    }
}
