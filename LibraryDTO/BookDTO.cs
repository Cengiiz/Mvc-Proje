using LibraryBLL.Concrete;
using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDTO
{
    public class BookDTO
    {
        public int Identity { get; set; }

        public int? Authorldentity { get; set; }

        public int? CategoryIdentity { get; set; }

        public string Name { get; set; }

        public DateTime? PublishYear { get; set; }

        public int? Status { get; set; }

        public byte? StockQuantity { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string CategoryName { get; set; }
        public static class Converter
        {
            public static BookDTO toDto(Book book)
            {
                BookManager bookManager = new BookManager();
                BookDTO bookDTO = new BookDTO();
                bookDTO.Identity = book.Identity;
                bookDTO.Name = book.Name;
                bookDTO.AuthorName = bookManager.GetbyId(book.Identity).Author.Name;
                bookDTO.AuthorSurname= bookManager.GetbyId(book.Identity).Author.Surname;
                bookDTO.CategoryName = bookManager.GetbyId(book.Identity).Category.CategoryName;
                bookDTO.PublishYear = book.PublishYear;
                bookDTO.Status = book.Status;
                bookDTO.StockQuantity = book.StockQuantity;

                return bookDTO;

            }
            public static Book toEntity(BookDTO bookDTO)
            {
                Book book = new Book();
                book.Identity = bookDTO.Identity;
                book.Name = bookDTO.Name;
                book.Authorldentity = bookDTO.Authorldentity;
                book.CategoryIdentity = bookDTO.CategoryIdentity;
                book.PublishYear = bookDTO.PublishYear;
                book.Status = bookDTO.Status;
                book.StockQuantity = bookDTO.StockQuantity;

                return book;

            }
            public static List<BookDTO> toBDtoList(List<Book> book)
            {
                return book.ConvertAll(x => new BookDTO
                {
                    Name = x.Name,
                    AuthorName = x.Author.Name,
                    AuthorSurname = x.Author.Surname,
                    CategoryName = x.Category.CategoryName,
                    PublishYear = x.PublishYear,
                    Status = x.Status,
                    StockQuantity = x.StockQuantity

                });
            }
        }

    }
}
