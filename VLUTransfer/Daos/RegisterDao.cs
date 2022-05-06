using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VLUTransfer.Models;

namespace VLUTransfer.Daos
{
    public class RegisterDao
    {
        DBContext myDb = new DBContext();
        
        public Register checkExist(int userId, int postId)
        {
            return myDb.registers.FirstOrDefault(x => x.postId == postId && x.userId == userId);
        }
        public void Add(Register register)
        {
            myDb.registers.Add(register);
            myDb.SaveChanges();
        }
    }
}