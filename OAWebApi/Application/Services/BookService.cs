using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using Infrastructure.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book != null)
            {
                _bookRepository.Delete(book);
            }
        }
    }
}