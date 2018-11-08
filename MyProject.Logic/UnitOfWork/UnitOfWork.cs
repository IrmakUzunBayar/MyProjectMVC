using MyProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Logic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private bool disposed = false;

        public UnitOfWork(MyContext context)
        {
            Database.SetInitializer<MyContext>(null);
            _context = context;
        }
        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //    }
        //}

        public MyContext GetContext()
        {
            return _context;
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //ex loglanabilir...     
                throw new ArgumentException();
            }
        }
    }
}
