using Gallery.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.Services
{
    public interface IPost
    {
        IEnumerable<Post> GetPosts { get; }
        Post GetPost(int? ID);
        void Add(Post _Post, IFormFile photo);
        void Remove(int? ID);
    }
}
