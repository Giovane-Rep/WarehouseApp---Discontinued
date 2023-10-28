namespace WarehouseApp.MVC.Models {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MaterialCategory> MaterialCategories { get; set; }
    }
}
