using _80_MVC_IdentityCustomize.Models;
using _80_MVC_IdentityCustomize.Models.Enums;
using _80_MVC_IdentityCustomize.Models.VMs;

namespace _80_MVC_IdentityCustomize.Services
{
    public interface IBookService
    {
        bool AddBook(BookCreateVM book, string userId);
        Task<bool> UpdateBookAsync(BookEditVM bookEditVM, string userId);
        Task<bool> DeleteBookAsync(int id, string userId);
        Task<bool> BookExistAsync(int id);
        bool Delete(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<List<Book>> GetBookByNameAsync(string bookName);
        Task<List<Book>> GetBookByStatus(Status status);
        Task<List<BookListVM>> GetUserBookAsync(string userId);
        Task<IEnumerable<Book>> GetFilteredAndSortedBooksAsync(string userId, string searchString, string statusFilter, string sortOrder);
        bool UpdateBook(Book book);
    }
}