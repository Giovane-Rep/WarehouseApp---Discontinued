using WarehouseApp.MVC.Data;
using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Repositories {
    public class RequisitionRepository : IRequisitionRepository {
        private readonly DataContext _context;

        public RequisitionRepository(DataContext context) {
            _context = context;
        }

        public bool RequisitionExists(int requisitionId) {
            return _context.Requisitions.Any(r => r.Id == requisitionId);
        }
        public Requisition GetRequisition(int requisitionId) {
            return _context.Requisitions.Where(r => r.Id == requisitionId).FirstOrDefault();
        }
        public ICollection<Requisition> GetRequisitions() {
            return _context.Requisitions.ToList();
        }
        public ICollection<Material> GetMaterialsByRequisition(int requisitionId) {
            return _context.RequisitionMaterials.Where(r => r.RequisitionId == requisitionId).Select(m => m.Material).ToList();
        }
        public bool CreateRequisition(int employeeId, ICollection<Material> materialsOfARequisition, Requisition requisition) {
 
            var requisitionMaterial = new RequisitionMaterial();

            foreach (Material item in materialsOfARequisition) {
                var material = _context.Materials.Where(m => m.Id == item.Id).FirstOrDefault();

                requisitionMaterial.Requisition = requisition;
                requisitionMaterial.Material = material;

                _context.Add(requisitionMaterial);
            }

            requisition.EmployeeId = employeeId;

            _context.Add(requisition);

            return Save();
        }
        public bool UpdateRequisition(Requisition requisition) {
            _context.Update(requisition);
            return Save();
        }
        public bool DeleteRequisition(Requisition requisition) {
            _context.Remove(requisition);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
