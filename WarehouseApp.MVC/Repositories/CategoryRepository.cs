﻿using Microsoft.EntityFrameworkCore;
using WarehouseApp.MVC.Data;
using WarehouseApp.MVC.Interfaces;
using WarehouseApp.MVC.Models;

namespace WarehouseApp.MVC.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) {
            _context = context;
        }
        public bool CategoryExists(int categoryId) {
            return _context.Categories.Any(c => c.Id == categoryId);
        }
        public ICollection<Category> GetCategories() {
            return _context.Categories.ToList();
        }
        public Category GetCategory(int categoryId) {
            return _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }
        public ICollection<Material> GetMaterialsByCategory(int categoryId) {
            return _context.Materials.Where(c => c.CategoryId == categoryId).ToList();
        }
        public bool CreateCategory(Category category) {
            _context.Add(category);
            return Save();
        }
        public bool UpdateCategory(Category category) {
            _context.Update(category);
            return Save();
        }
        public bool DeleteCategory(Category category) {
            var categoryMaterials = _context.Categories.Include(c => c.Materials)
                .FirstOrDefault(c => c.Id == category.Id);

            _context.Materials.RemoveRange(categoryMaterials.Materials);
            


            _context.Remove(category);
            return Save();
        }
        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
