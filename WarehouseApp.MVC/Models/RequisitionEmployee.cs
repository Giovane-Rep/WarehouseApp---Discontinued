namespace WarehouseApp.MVC.Models {
    public class RequisitionEmployee {
        public int RequisitionId { get; set; }
        public int EmployeeId { get; set; }
        public Requisition Requisition { get; set; }
        public Employee Employee { get; set; }
    }
}
