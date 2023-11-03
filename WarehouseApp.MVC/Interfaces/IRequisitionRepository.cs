using WarehouseApp.MVC.Dto;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Interfaces {
    public interface IRequisitionRepository {
        ICollection<Requisition> GetRequisitions();
        Requisition GetRequisition(int requisitionId);
        ICollection<Material> GetMaterialsByRequisition(int requisitionId);
        void AddMaterialToRequisition(int requisitionId, int materialId);
        void RemoveMaterialOfRequisition(int requisitionId, int materialId);
        bool RequisitionExists(int requisitionId);
        bool CreateRequisition(int employeeId, Requisition requisition);
        bool UpdateRequisition(Requisition requisition);
        bool DeleteRequisition(Requisition requisition);
        bool Save();
    }
}
