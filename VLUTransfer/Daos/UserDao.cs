using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public List<User> getUsers()
        {
            return myDb.users.OrderByDescending(x => x.userId).ToList();
        }

        public User getUserById(int id)
        {
            return myDb.users.Where(u => u.userId == id).FirstOrDefault();
        }

        public void changeStatus(int id)
        {
            var user = getUserById(id);
            user.status = user.status == 1 ? 0 : 1;
            myDb.SaveChanges();
        }
        public void register(User user)
        {
            myDb.users.Add(user);
            myDb.SaveChanges();
        }

        public User checkLogin(string email, string password)
        {
            var objUser = myDb.users.Where(u => u.email == email && u.password == password ).FirstOrDefault();

            return objUser;

        }

        public void updateProfile(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.userId == user.userId);
            obj.status = user.status;
            obj.phoneNumber = user.phoneNumber;
            obj.email = user.email;
            obj.fullName = user.fullName;
            obj.address = user.address;
            obj.studentId = user.studentId;
            myDb.SaveChanges();
        }
        public bool checkEmailExist(string email)
        {
            var objUser = myDb.users.Where(u => u.email == email).FirstOrDefault();
            if (objUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string md5(string password)
        {
            MD5 md = MD5.Create();
            byte[] inputString = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md.ComputeHash(inputString);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x"));
            }
            return sb.ToString();
        }
        public User getUserByEmail(string email)
        {
            var obj = myDb.users.Where(u => u.email == email).FirstOrDefault();
            return obj;
        }
    }
}