using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPF_KOZ_LAB1.Models;

namespace WPF_KOZ_LAB1.ViewModels
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EntityFrameworkRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public class ApplicationStorage : IStorage
    {
        private readonly Laba1Context _context;

        public ApplicationStorage(Laba1Context context)
        {
            _context = context;
            BronRepository = new EntityFrameworkRepository<Bron>(_context);
            ClientRepository = new EntityFrameworkRepository<Client>(_context);
            InventoryRepository = new EntityFrameworkRepository<Inventory>(_context);
            SkidkaRepository = new EntityFrameworkRepository<Skidka>(_context);
            TypeRepository = new EntityFrameworkRepository<Type_t>(_context);
            ZakazRepository = new EntityFrameworkRepository<Zakaz>(_context);
            ZakazSkidkaRepository = new EntityFrameworkRepository<ZakazSkidka>(_context);
        }

        public IRepository<Bron> BronRepository { get; }
        public IRepository<Client> ClientRepository { get; }
        public IRepository<Inventory> InventoryRepository { get; }
        public IRepository<Skidka> SkidkaRepository { get; }
        public IRepository<Type_t> TypeRepository { get; }
        public IRepository<Zakaz> ZakazRepository { get; }
        public IRepository<ZakazSkidka> ZakazSkidkaRepository { get; }
    }


}
