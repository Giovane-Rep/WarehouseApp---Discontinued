using WarehouseApp.MVC.Data;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Repositories {
    public class MaterialRepository : IMaterialRepository {
        private readonly DataContext _context;

        public MaterialRepository(DataContext context) {
            _context = context;
        }
        public bool MaterialExists(int materialId) {
            return _context.Materials.Any(m => m.Id == materialId);
        }
        public ICollection<Material> GetMaterials() {
            return _context.Materials.ToList();
        }
        public Material GetMaterial(int materialId) {
            return _context.Materials.Where(m => m.Id == materialId).FirstOrDefault();
        }
        public bool CreateMaterial(int categoryId, Material material) {
            material.CategoryId = categoryId;

            _context.Add(material);

            return Save();
        }
        public bool UpdateMaterial(Material material) {
            _context.Update(material);
            return Save();
        }
        public bool DeleteMaterial(Material material) {
            _context.Remove(material);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
