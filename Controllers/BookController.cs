using LibraryManagementSystemForPatika.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemForPatika.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            var bookListViewModel = Repository.Books.Select(b => new BookListViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorName = Repository.Authors.FirstOrDefault(a => a.Id == b.AuthorId && a.IsDeleted!=true)?.FullName,
                Genre =b.Genre,
                PublishDate=b.PublishDate,
                ISBN=b.ISBN,
                CopiesAvailable=b.CopiesAvailable
            }).ToList();
            return View(bookListViewModel);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = Repository.Books.FirstOrDefault(b=>b.Id== id);
            var author = Repository.Authors.FirstOrDefault(a=>a.Id==book.AuthorId);
            var bookDetailsViewModel = new BookDetailsViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = author.IsDeleted != true?author.FullName:"",//if author is not deleted than gets the full name 
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,
                AuthorBookCount =author.IsDeleted!=true?Repository.Books.Count(b => b.AuthorId == book.AuthorId):0 // if author is not deleted then gives the author's book number.
            };
            return View(bookDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = Repository.Books.FirstOrDefault(b=>b.Id== id);
            Repository.Books.Remove(book);
            return RedirectToAction("List", "Book");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = Repository.Books.FirstOrDefault(b=>b.Id == id);
            ViewBag.Authors = Repository.Authors.Select(a => new AuthorListViewModel
            {
                Id = a.Id,
                FullName = a.FullName,
                IsDeleted=a.IsDeleted
            }).Where(a => a.IsDeleted != true).ToList();//Since the deletion process in the authors section works as a soft delete, it is now checked using a where clause.
            var bookEditViewModel = new BookEditViewModel
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable,
            };
            return View(bookEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(BookEditViewModel bookEditViewModel) 
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = Repository.Authors.Select(a => new AuthorListViewModel
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    IsDeleted = a.IsDeleted
                }).Where(a => a.IsDeleted != true).ToList();//Since the deletion process in the authors section works as a soft delete, it is now checked using a where clause.
                return View(bookEditViewModel);
            }
            var book = Repository.Books.FirstOrDefault(a=>a.Id==bookEditViewModel.Id);
            book.Title = bookEditViewModel.Title;
            book.AuthorId=bookEditViewModel.AuthorId;
            book.PublishDate=bookEditViewModel.PublishDate;
            book.Genre=bookEditViewModel.Genre;
            book.ISBN=bookEditViewModel.ISBN;
            book.CopiesAvailable=bookEditViewModel.CopiesAvailable;
            return RedirectToAction("List", "Book");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Authors = Repository.Authors.Select(a => new AuthorListViewModel
            {
                Id = a.Id,
                FullName = a.FullName,
                IsDeleted=a.IsDeleted
            }).Where(a => a.IsDeleted != true).ToList();//Since the deletion process in the authors section works as a soft delete, it is now checked using a where clause.
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookAddViewModel bookAddViewModel) 
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Authors = Repository.Authors.Select(a => new AuthorListViewModel
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    IsDeleted = a.IsDeleted
                }).Where(a => a.IsDeleted != true).ToList();//Since the deletion process in the authors section works as a soft delete, it is now checked using a where clause.
                return View(bookAddViewModel);
            }
            var bookId = Repository.Books.Max(b => b.Id) + 1;
            var newBook = new Book
            {
                Id = bookId,
                Title = bookAddViewModel.Title,
                AuthorId = bookAddViewModel.AuthorId,
                Genre = bookAddViewModel.Genre,
                PublishDate = bookAddViewModel.PublishDate,
                ISBN = bookAddViewModel.ISBN,
                CopiesAvailable = bookAddViewModel.CopiesAvailable,
            };
            Repository.Books.Add(newBook);
            return RedirectToAction("List", "Book");
        }
    }
}
