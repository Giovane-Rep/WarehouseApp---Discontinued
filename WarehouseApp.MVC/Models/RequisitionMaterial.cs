namespace WarehouseApp.MVC.Models {
    public class RequisitionMaterial {
        public int RequisitionId { get; set; }
        public int MaterialId { get; set; }
        public int QuantityRequested { get; set; }
        public Requisition Requisition { get; set; }
        public Material Material { get; set; }
    }
}
