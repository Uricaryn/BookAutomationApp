using _80_MVC_IdentityCustomize.Contexts;
using _80_MVC_IdentityCustomize.Models;
using _80_MVC_IdentityCustomize.Models.Enums;
using _80_MVC_IdentityCustomize.Models.VMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _80_MVC_IdentityCustomize.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BookService(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<BookListVM>> GetUserBookAsync(string userId)
        {
            return await _context.Books
         .Where(b => b.AppUserId == userId)
         .Select(x => new BookListVM
         {
             Id = x.Id,
             Title = x.Title,
             Author = x.Author,
             Status = x.Status,
             CreatedDate = x.CreatedDate
         })
         .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetBookByNameAsync(string bookName)
        {
            return await _context.Books
                .Where(x => x.Title.Contains(bookName))
                .ToListAsync();
        }

        public async Task<List<Book>> GetBookByStatus(Status status)
        {
            return await _context.Books
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public bool AddBook(BookCreateVM book, string userId)
        {
            var result = new Book() 
            { 
                AppUserId = userId,
                Title = book.Title,
                Author = book.Author,
                Status = book.Status,
                Description = book.Description,
            };
            _context.Books.Add(result);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<bool> BookExistAsync(int id)
        {
            return await _context.Books.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> UpdateBookAsync(BookEditVM bookEditVM, string userId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookEditVM.Id && b.AppUserId == userId);
            if (book == null)
            {
                return false;
            }

            book.Title = bookEditVM.Title;
            book.Author = bookEditVM.Author;
            book.Status = bookEditVM.Status;
            book.Description = bookEditVM.Description;

            _context.Books.Update(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookAsync(int id, string userId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id && b.AppUserId == userId);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BookListVM>> GetUserBookAsync(string userId, string searchString = null)
        {
            var query = _context.Books.Where(b => b.AppUserId == userId).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString));
            }

            return await query.Select(x => new BookListVM
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Status = x.Status,
                CreatedDate = x.CreatedDate
            }).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetFilteredAndSortedBooksAsync(string userId, string searchString, string statusFilter, string sortOrder)
        {
            var books = await _context.Books.Where(b => b.AppUserId == userId).ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!String.IsNullOrEmpty(statusFilter) && Enum.TryParse<Status>(statusFilter, out var status))
            {
                books = books.Where(b => b.Status == status).ToList();
            }

            books = sortOrder switch
            {
                "title_asc" => books.OrderBy(b => b.Title).ToList(),
                "title_desc" => books.OrderByDescending(b => b.Title).ToList(),
                "date_asc" => books.OrderBy(b => b.CreatedDate).ToList(),
                "date_desc" => books.OrderByDescending(b => b.CreatedDate).ToList(),
                _ => books.ToList(),
            };

            return books;
        }
    }
}
