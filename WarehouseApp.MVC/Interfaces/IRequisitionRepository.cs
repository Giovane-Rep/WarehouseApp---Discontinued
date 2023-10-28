using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Interfaces {
    public interface IRequisitionRepository {
        ICollection<Requisition> GetRequisitions();
        Requisition GetRequisition(int requisitionId);
        ICollection<Material> GetMaterialsByRequisition(int requisitionId);
        bool RequisitionExists(int requisitionId);
        bool CreateRequisition(int employeeId, int materialId, Requisition requisition);
        bool UpdateRequisition(Requisition requisition);
        bool DeleteRequisition(Requisition requisition);
        bool Save();
    }
}
