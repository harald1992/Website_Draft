using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Data.EntityModels;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _DbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _DbContext.Users;
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(User => User.Id == id);
        }

        public void Add(User newUser)
        {
            _DbContext.Add(newUser);
            _DbContext.SaveChanges();
        }

        public void Remove(User userToDelete)
        {
            _DbContext.Remove(userToDelete);
            _DbContext.SaveChanges();
        }

        public string GetName(int id)
        {
            return GetById(id).Name;
        }
    }
}
