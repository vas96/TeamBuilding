using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBtest.Models;

namespace TBtest.Controllers
{
    public class HomeController : Controller
    {
        private Models.TbContext _db;
        public HomeController(Models.TbContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Projects()
        {
            PostModel postModel = new PostModel
            {
                Users = _db.Users.ToList(),
                Projects = _db.Projects.ToList(),
                LikedPrjs = _db.LikedPrjs.ToList()
            };
            return View(postModel);
        }
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

            project.PrjLikeCounter = 0;
            project.PrjCreatedDate = DateTime.Now;
            project.User = user;
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return RedirectToAction("Projects");
        }
        public async Task<IActionResult> FullPost(int? id)
        {
            if (id != null)
            {
                Project project = await _db.Projects.Include("User").FirstOrDefaultAsync(p => p.ProjectId == id);
                User user = await _db.Users.FirstOrDefaultAsync(p => p.UserId == project.UserId);
                var i = project.User.UserId;
                if (project != null)
                return View(project);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Project post = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project post)
        {
            _db.Projects.Update(post);
            await _db.SaveChangesAsync();

            return RedirectToAction("Projects");
        }

        public async Task<IActionResult> Like(int? id)
        {
            if (id != null)
            {
                Project post = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
                if (post != null) {
                    post.PrjLikeCounter = post.PrjLikeCounter + 1;
                    User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);                 
                    var like = new LikedPrj { Project = post, User = user };
                    _db.LikedPrjs.Add(like);
                    _db.Projects.Update(post);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Projects");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> UnLike(int? id)
        {
            if (id != null)
            {
                Project post = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
                if (post != null)
                {
                    post.PrjLikeCounter = post.PrjLikeCounter - 1;
                    User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                    _db.LikedPrjs.RemoveRange(_db.LikedPrjs.Where(c => c.Project.ProjectId == post.ProjectId && c.User.UserId == user.UserId));
                    _db.Projects.Update(post);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Projects");
                }
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Project post = await _db.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
                if (post != null)
                    return View(post);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Project post = new Project { ProjectId = id.Value };
                _db.Entry(post).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return RedirectToAction("Projects");
            }
            return NotFound();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
