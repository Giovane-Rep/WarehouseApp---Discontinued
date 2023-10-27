//using WarehouseApp.Domain.Entities;
//using WarehouseApp.Infra.Data.DataContext;

//namespace WarehouseApp.MVC {
//    public class Seed {
//        private readonly DataContext _context;

//        public Seed(DataContext context) {
//            _context = context;
//        }

//        public void SeedDataContext() {
//            if (!_context.RequisitionEmployees.Any()) {
//                var requisitionEmployees = new List<RequisitionEmployee>() {
//                    new RequisitionEmployee() {
//                        Requisition = new Requisition() {
//                            Name = "Solicitação de Materiais",
//                            Description = "Solicitação materiais para uso em escritório",
//                            OpeningDate = new DateTime(1990, 1, 1),
//                            ClosingDate = new DateTime(1990, 1, 1),
//                            Active = true,
//                            RequisitionMaterials = new List<RequisitionMaterial>() {
//                                new RequisitionMaterial {
//                                    Material = new Material() {
//                                        Name = "Caneta",
//                                        Description = "Caneta Esferográfica",
//                                        MaterialsInStock = 25,
//                                        FabricationDate = new DateTime(1990, 1, 1),
//                                        DueDate = new DateTime(1990, 1, 1),
//                                        EntrieDate = new DateTime(1990, 1, 1),
//                                        OutputDate = new DateTime(1990, 1, 1),
//                                        MaterialCategories = new List<MaterialCategory>() {
//                                            new MaterialCategory() {
//                                            Category = new Category() {Name = "Material de Escritório"}
//                                            }
//                                        }
//                                    }
//                                },
//                                new RequisitionMaterial {
//                                    Material = new Material() {
//                                        Name = "Lápis",
//                                        Description = "Lápis 2B",
//                                        MaterialsInStock = 8,
//                                        FabricationDate = new DateTime(1990, 1, 1),
//                                        DueDate = new DateTime(1990, 1, 1),
//                                        EntrieDate = new DateTime(1990, 1, 1),
//                                        OutputDate = new DateTime(1990, 1, 1),
//                                        MaterialCategories = new List<MaterialCategory>() {
//                                            new MaterialCategory() {
//                                            Category = new Category() {Name = "Material de Escritório"}
//                                            }
//                                        }
//                                    }
//                                }
//                            }
//                        },
//                        Employee = new Employee() {
//                            Name = "Pedro",
//                            Email = "pedro@email.com",
//                            Sector = "TI",
//                            Delegation = "Admin",
//                            Active = true,
//                            Login = new Login() {
//                                UserLogin = "pedro@email.com",
//                                Password = "12345678",
//                            }
//                        }
//                    }
//                };
//                _context.RequisitionEmployees.AddRange(requisitionEmployees);
//                _context.SaveChanges();
//            }
//        }
//    }
//}
