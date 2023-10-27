using WarehouseApp.Domain.Entities;

namespace WarehouseApp.MVC.Interfaces {
    public interface IMaterialRepository {
        ICollection<Material> GetMaterials();
        Material GetMaterial(int materialId);
        bool MaterialExists(int materialId);
        bool CreateMaterial(int categoryId, Material material);
        bool UpdateMaterial(Material material);
        bool DeleteMaterial(Material material);
        bool Save();
    }
}
