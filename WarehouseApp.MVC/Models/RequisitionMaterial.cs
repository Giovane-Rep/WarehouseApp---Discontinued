namespace WarehouseApp.Domain.Entities {
    public class RequisitionMaterial {
        public int RequisitionId { get; set; }
        public int MaterialId { get; set; }
        public Requisition Requisition { get; set; }
        public Material Material { get; set; }
    }
}
