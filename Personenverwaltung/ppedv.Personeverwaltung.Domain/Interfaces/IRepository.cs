using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personeverwaltung.Domain.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        void Update<T>(T item) where T : Entity;
        T GetByID<T>(int id) where T : Entity;
        IEnumerable<T> GetAll<T>() where T : Entity;
    }
}
