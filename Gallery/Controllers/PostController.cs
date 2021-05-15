using Gallery.Data;
using Gallery.Models;

using Gallery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gallery.Controllers
{
    public class PostController : Controller
    {
       
        private readonly IPost _Post;
        private ApplicationDbContext _db;
        public PostController(IPost Post, ApplicationDbContext db)
        
        {
            _Post = Post;
            _db = db;
           
        }
        public IActionResult Index()
        {
        

            var ordered = _db.Posts.OrderByDescending(x => x.CreatedDate);
            return View(ordered.Include(a => a.Images).ToList());

          

        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post model, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
             
                _Post.Add(model, photo);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            else
            {
                Post model = _Post.GetPost(ID);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? ID)
        {
            _Post.Remove(ID);
            return RedirectToAction("Index");
        }
      
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            return View(_Post.GetPost(ID));
        }
        
        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            var model = _Post.GetPost(ID);
            return View(model);
          
        }
        [HttpPost]
        public IActionResult Edit(Post model, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
              
                _Post.Add(model, photo);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
