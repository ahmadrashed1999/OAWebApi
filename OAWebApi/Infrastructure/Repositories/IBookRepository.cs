using Domain;

namespace Domain.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        Book GetById(int id);
        IEnumerable<Book> GetAll();
    }
}