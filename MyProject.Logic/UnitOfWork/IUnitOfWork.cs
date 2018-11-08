using MyProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Logic.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        MyContext GetContext();
    }
}
