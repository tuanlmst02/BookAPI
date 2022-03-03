using BookAPI.Models;

namespace BookAPI.Responsitories
{
    public interface IBookResponsitory
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int id);
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}
