namespace WarehouseApp.Domain.Entities {
    public class MaterialCategory {
        public int MaterialId { get; set; }
        public int CategoryId { get; set; }
        public Material Material { get; set; }
        public Category Category { get; set; }
    }
}
