using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VLUTransfer.Models;

namespace VLUTransfer.Daos
{
    public class PostDao
    {
        DBContext myDb = new DBContext();


        public List<Post> getAll()
        {
            return myDb.posts.OrderByDescending(x => x.createdAt).ToList();
        }

        public Post GetDetail(int id)
        {
            return myDb.posts.FirstOrDefault(x => x.postId == id);
        }

        public void add(Post post)
        {
            myDb.posts.Add(post);
            myDb.SaveChanges();
        }

        public void update(Post post)
        {
            var obj = myDb.posts.FirstOrDefault(x => x.postId == post.postId);
            obj.status = post.status;
            myDb.SaveChanges();
        }

        public void approve(int id)
        {
            var obj = myDb.registers.FirstOrDefault(x => x.registeId == id);
            obj.status = 1;
            myDb.SaveChanges();
        }

        public Register getRe(int id)
        {
            return myDb.registers.FirstOrDefault(x => x.registeId == id);
        }

        public List<Post> getHome(int status)
        {
            return myDb.posts.Where(x => x.status == status).ToList();
        }

        public List<Post> GetPosts()
        {
            return myDb.posts.Where(x => x.status == 1).ToList();
        }

        public List<Post> SearchByName(int page, int pagesize, string name)
        {
            return myDb.posts.Where(x => x.status ==1 &&  x.title.Contains(name)).ToList().Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }

        public int GetNumberRoomByName(string name)
        {
            int total = myDb.posts.Where(x => x.status == 1 &&  x.title.Contains(name)).ToList().Count;
            int count = 0;
            count = total / 5;
            if (total % 5 != 0)
            {
                count++;
            }
            return count;
        }

        public List<Post> GetList(int page, int pagesize)
        {
            return myDb.posts.Where(x => x.status == 1).ToList().Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }

        public int GetNumber()
        {
            int total = myDb.posts.Where(x => x.status == 1).ToList().Count;
            int count = 0;
            count = total / 5;
            if (total % 5 != 0)
            {
                count++;
            }
            return count;
        }

        public List<Post> getPostUser(int id, int page, int pageSize)
        {
            return myDb.posts.Where(p => p.userId == id).OrderByDescending(u => u.postId).ToList().
                  Skip((page - 1) * pageSize).Take(pageSize).ToList(); ;
        }

        public int getNumberPostUser(int id)
        {
            int total = myDb.posts.Where(p => p.userId == id).ToList().Count;
            int count = 0;
            count = total / 4;
            if (total % 4 != 0)
            {
                count++;
            }
            return count;
        }

        public List<Register> getPostUserRegister(int id, int page, int pageSize)
        {
            return myDb.registers.Where(p => p.userId == id).OrderByDescending(u => u.dateRegister).ToList().
                  Skip((page - 1) * pageSize).Take(pageSize).ToList(); ;
        }

        public int getNumberPostUserRegister(int id)
        {
            int total = myDb.registers.Where(p => p.userId == id).ToList().Count;
            int count = 0;
            count = total / 4;
            if (total % 4 != 0)
            {
                count++;
            }
            return count;
        }

        public List<Register> getPostRegister(int id, int page, int pageSize)
        {
            return myDb.registers.Where(p => p.postId == id).OrderByDescending(u => u.dateRegister).ToList().
                  Skip((page - 1) * pageSize).Take(pageSize).ToList(); ;
        }

        public int getNumberPostRegister(int id)
        {
            int total = myDb.registers.Where(p => p.postId == id).ToList().Count;
            int count = 0;
            count = total / 4;
            if (total % 4 != 0)
            {
                count++;
            }
            return count;
        }
    }
}