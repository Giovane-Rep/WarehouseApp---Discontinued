namespace WarehouseApp.MVC.Models {
    public class Category {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
