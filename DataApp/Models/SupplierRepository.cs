using System.Collections.Generic;

namespace DataApp.Models
{
    public interface ISupplierRepository
    {
        Supplier Get(long id);
        IEnumerable<Supplier> GetAll();
        void Create(Supplier newDataObject);
        void Update(Supplier changedDataObject);
        void Delete(long id);
    }
    public class SupplierRepository : ISupplierRepository {
        private EFDatabaseContext context;

        public SupplierRepository(EFDatabaseContext ctx) => context = ctx;

        public Supplier Get(long id) {
            return context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll() {
            return context.Suppliers;
        }

        public void Create(Supplier newDataObject) {
            context.Add(newDataObject);
            context.SaveChanges();
        }

        public void Update(Supplier chagedDataObject) {
            context.Update(chagedDataObject);
            context.SaveChanges();
        }

        public void Delete(long id) {
            context.Remove(Get(id));
            context.SaveChanges();
        }

    }
}
