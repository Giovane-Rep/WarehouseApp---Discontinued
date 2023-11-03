﻿namespace WarehouseApp.MVC.Dto {
    public class RequisitionDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityRequested { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool Active { get; set; }
        public int EmployeeId { get; set; }
    }
}
