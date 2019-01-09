using System;
using System.Collections.Generic;
using System.Text;
using Data.EntityModels;

namespace Data
{
    public interface IUser
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Add(User newUser);

        void Remove(int id);

    }
}
