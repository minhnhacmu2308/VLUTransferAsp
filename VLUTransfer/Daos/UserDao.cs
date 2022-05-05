using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VLUTransfer.Models;

namespace VLUTransfer.Daos
{
    public class UserDao
    {
        DBContext myDb = new DBContext();


        public List<User> getAll()
        {
            return myDb.users.OrderByDescending(x => x.userId).ToList();
        }

        public void update(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.userId == user.userId);
            obj.status = user.status;
            myDb.SaveChanges();
        }

        public List<User> getHome(int status)
        {
            return myDb.users.Where(x => x.status == status).ToList();
        }
    }
}