using LibraryManagementSystemForPatika.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemForPatika.Controllers
{
    public class AuthorController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            var authorListViewModel = Repository.Authors.Select(b => new AuthorListViewModel
            {
                Id = b.Id,
                FirstName = b.FirstName,
                LastName = b.LastName,
                DateOfBirth = b.DateOfBirth,
                IsDeleted = b.IsDeleted,
                BookCount = Repository.Books.Count(a => a.AuthorId == b.Id)
            }).Where(b => b.IsDeleted != true).ToList();
            return View(authorListViewModel);
        }
    
        [HttpGet]
        public IActionResult Details(int id) {
            var author = Repository.Authors.FirstOrDefault(a=> a.Id == id);
            var authorDetailsViewModel = new AuthorDetailsViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                BookCount = Repository.Books.Count(b => b.AuthorId == id),
                Books = Repository.Books.Where(c => c.AuthorId == id).ToList()
            };
            return View(authorDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = Repository.Authors.FirstOrDefault(a=>a.Id == id);
            var authorEditViewModel = new AuthorEditViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
            };
            return View(authorEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel authorEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(authorEditViewModel);
            }
            var author = Repository.Authors.FirstOrDefault(a=>a.Id==authorEditViewModel.Id);
            author.FirstName = authorEditViewModel.FirstName;
            author.LastName = authorEditViewModel.LastName;
            author.DateOfBirth= authorEditViewModel.DateOfBirth;
            return RedirectToAction("List", "Author");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = Repository.Authors.FirstOrDefault(b=>b.Id==id);
            //Repository.Authors.Remove(author); id hatası dolayısıyla soft delete geçildi
            author.IsDeleted = true;
            return RedirectToAction("List", "Author");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AuthorAddViewModel authorAddViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(authorAddViewModel);
            }
            var authorId = Repository.Authors.Max(a => a.Id) + 1;
            var newAuthor = new Author
            {
                Id = authorId,
                FirstName = authorAddViewModel.FirstName,
                LastName = authorAddViewModel.LastName,
                DateOfBirth = authorAddViewModel.DateOfBirth,
                IsDeleted=false
            };
            Repository.Authors.Add(newAuthor);
            return RedirectToAction("List", "Author");
        }
    }
}
