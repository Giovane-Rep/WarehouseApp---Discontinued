namespace WarehouseApp.MVC.Models {
    public class Employee {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Sector { get; set; }
        public string Delegation { get; set; }
        public bool Active { get; set; }
        public int LoginId { get; set ; }
        public Login Login { get; set; }
        public ICollection<Requisition> Requisitions { get; set; }
        public ICollection<Login> Logins { get; set; }
    }
}
