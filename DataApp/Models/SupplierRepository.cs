using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            //return context.Suppliers.Include(s => s.Products);

            /* IEnumerable<Supplier> data = context.Suppliers.ToArray();
             foreach (Supplier s in data) {
                 context.Entry(s).Collection(e => e.Products)
                     .Query()
                     .Where(p => p.Price > 50)
                     .Load();
             }
             return data;*/


            // two queries required for this example
            //context.Products.Where(p => p.Supplier != null && p.Price > 50).Load();
            //return context.Suppliers;

            return context.Suppliers.Include(p => p.Products);
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
