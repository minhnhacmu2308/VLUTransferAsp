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

        public List<Post> getHome(int status)
        {
            return myDb.posts.Where(x => x.status == status).ToList();
        }

        public List<Post> GetPosts()
        {
            return myDb.posts.ToList();
        }
    }
}