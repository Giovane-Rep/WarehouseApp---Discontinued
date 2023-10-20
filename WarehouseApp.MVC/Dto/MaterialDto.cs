namespace WarehouseApp.MVC.Dto {
    public class MaterialDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaterialsInStock { get; set; }
        public DateTime FabricationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime EntrieDate { get; set; }
        public DateTime OutputDate { get; set; }
    }
}
