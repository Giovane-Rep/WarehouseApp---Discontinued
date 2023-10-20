namespace WarehouseApp.Domain.Entities {
    public class Requisition {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool Active { get; set; }
        public ICollection<RequisitionEmployee> RequisitionEmployees { get; set; }
        public ICollection<RequisitionMaterial> RequisitionMaterials { get; set; }
    }
}
