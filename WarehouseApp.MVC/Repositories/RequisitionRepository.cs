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
            return _context.RequisitionMaterials.Where(r => r.Requisition.Id == requisitionId).Select(m => m.Material).ToList();
        }
        public void AddMaterialToRequisition(int requisitionId, int materialId) {
            var requisition = _context.Requisitions.Find(requisitionId);
            var material = _context.Materials.Find(materialId);

            var materialRequisition = new RequisitionMaterial {
                RequisitionId = requisition.Id,
                MaterialId = material.Id
            };

            _context.RequisitionMaterials.Add(materialRequisition);
        }
        public void RemoveMaterialOfRequisition(int requisitionId, int materialId) {
            var materialOfARequisition = _context.RequisitionMaterials.Where(r => r.RequisitionId == requisitionId).FirstOrDefault(m => m.MaterialId == materialId);

            _context.RequisitionMaterials.RemoveRange(materialOfARequisition);
        }
        public bool CreateRequisition(int employeeId, Requisition requisition) {
            requisition.EmployeeId = employeeId;

            _context.Add(requisition);

            return Save();
        }
        public bool UpdateRequisition(Requisition requisition) {
            _context.Update(requisition);
            return Save();
        }
        public bool DeleteRequisition(Requisition requisition) {
            var requisitionMaterials = _context.RequisitionMaterials.Where(rm => rm.RequisitionId == requisition.Id);

            _context.RequisitionMaterials.RemoveRange(requisitionMaterials);
            

            _context.Remove(requisition);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
