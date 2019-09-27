using ppedv.Personeverwaltung.Domain;
using ppedv.Personeverwaltung.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context)
        {
            this.context = context;
        }
        private readonly EFContext context;



        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item); // Set<T> nimmt sich das richtige DBSet heraus
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetByID<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void Update<T>(T item) where T : Entity
        {
            var loadedItem = GetByID<T>(item.ID); // Element nochmal aus der DB laden
            if (loadedItem != null) // item existiert noch in der DB
                context.Entry(loadedItem).CurrentValues.SetValues(item); 
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
