using WarehouseApp.Domain.Entities;

namespace WarehouseApp.MVC.Interfaces {
    public interface ICategoryRepository {
        ICollection<Category> GetCategories();
        ICollection<Material> GetMaterialsByCategory(int categoryId);
        Category GetCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
