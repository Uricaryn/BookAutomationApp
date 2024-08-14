using _80_MVC_IdentityCustomize.Models;
using _80_MVC_IdentityCustomize.Models.Enums;
using _80_MVC_IdentityCustomize.Models.VMs;
using _80_MVC_IdentityCustomize.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace _80_MVC_IdentityCustomize.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly UserManager<AppUser> _userManager;

        public BookController(IBookService bookService, UserManager<AppUser> userManager)
        {
            _bookService = bookService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchString, string statusFilter, string sortOrder)
        {
            var userId = _userManager.GetUserId(User);

            var books = await _bookService.GetFilteredAndSortedBooksAsync(userId, searchString, statusFilter, sortOrder);

            var bookListVM = books.Select(book => new BookListVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Status = book.Status,
                CreatedDate = book.CreatedDate,
                Description = book.Description
            }).ToList();

            // Populate the status list using the Status enum
            var statuses = Enum.GetValues(typeof(Status))
                                .Cast<Status>()
                                .Select(s => new SelectListItem
                                {
                                    Value = s.ToString(),
                                    Text = s.ToString()
                                }).ToList();

            var bookFilterVM = new BookFilterVM
            {
                CurrentFilter = searchString,
                StatusFilter = statusFilter,
                CurrentSort = sortOrder,
                Books = bookListVM,
                Statuses = statuses,
                TitleSort = sortOrder == "title_asc" ? "title_desc" : "title_asc",
                DateSortParam = sortOrder == "date_asc" ? "date_desc" : "date_asc"
            };

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentStatus"] = statusFilter;
            ViewData["TitleSortParam"] = bookFilterVM.TitleSort;
            ViewData["DateSortParam"] = bookFilterVM.DateSortParam;
            ViewData["Statuses"] = statuses;

            return View(bookFilterVM.Books);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookCreateVM book)
        {
            var userId = _userManager.GetUserId(User);
            var success = _bookService.AddBook(book, userId);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = _userManager.GetUserId(User);
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookEditVM = new BookEditVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Status = book.Status,
            };

            return View(bookEditVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditVM bookEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookEditVM);
            }

            var userId = _userManager.GetUserId(User);
            var success = await _bookService.UpdateBookAsync(bookEditVM, userId);

            if (success)
            {
                return RedirectToAction("Index");
            }

            return View(bookEditVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null || book.AppUserId != userId)
            {
                return NotFound();
            }

            var bookDeleteVM = new BookDeleteVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            };

            return View(bookDeleteVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            var success = await _bookService.DeleteBookAsync(id, userId);

            if (success)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null || book.AppUserId != userId)
            {
                return NotFound();
            }

            var bookDetailsVM = new BookDetailsVM
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Status = book.Status,
                CreatedDate = book.CreatedDate,
                Description = book.Description
            };

            return View(bookDetailsVM);
        }
    }
}
