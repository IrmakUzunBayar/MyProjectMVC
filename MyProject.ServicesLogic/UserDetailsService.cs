using MyProject.Common.ViewModels;
using MyProject.Data.Context;
using MyProject.Data.Models;
using MyProject.Logic.Repository;
using MyProject.Logic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ServicesLogic
{
    public class UserDetailsService : IRepository<UserDetailsVM>
    {
        UnitOfWork uow;
        MyContext context;
        Repository<UserDetails> _udRepo;

        public UserDetailsService()
        {
            context = new MyContext();
            uow = new UnitOfWork(context);
            _udRepo = new Repository<UserDetails>(context);
        }

        public void Create(UserDetailsVM entity)
        {
            _udRepo.Create(ConvertVMToEntity(entity));
            uow.SaveChanges();
        }

        public void Delete(UserDetailsVM entity)
        {
            _udRepo.Delete(ConvertVMToEntity(entity));
            uow.SaveChanges();
        }

        public List<UserDetailsVM> GetAll()
        {
            return _udRepo.GetAll().Select(x => new UserDetailsVM()
            {
                //ApplicationUserId = x.ApplicationUserId,
                LastName = x.LastName,
                Name = x.Name,
                UserDetailId = x.UserDetailId
            }).ToList();
        }

        public UserDetailsVM GetById(int id)
        {
            var gelen = _udRepo.GetById(5);
            return ConvertEntityToVM(gelen);
        }

        public void Update(UserDetailsVM entity)
        {
            _udRepo.Update(ConvertVMToEntity(entity));
            uow.SaveChanges();
        }

        UserDetailsVM ConvertEntityToVM(UserDetails e)
        {
            return new UserDetailsVM()
            {
                //ApplicationUserId = e.ApplicationUserId,
                Name = e.Name,
                LastName = e.LastName,
                UserDetailId = e.UserDetailId
            };
        }

        UserDetails ConvertVMToEntity(UserDetailsVM e)
        {
            return new UserDetails()
            {           
                //ApplicationUserId = e.ApplicationUserId,
                Name = e.Name,
                LastName = e.LastName,
                UserDetailId = e.UserDetailId
            };
        }
    }
}
