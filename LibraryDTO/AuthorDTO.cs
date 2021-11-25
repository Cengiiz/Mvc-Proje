using LibraryDAL.Entities;
using System.Collections.Generic;

namespace LibraryDTO
{
    public class AuthorDTO
    {
        public int AuthorsId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Status { get; set; }

        public static class Converter
        {
            public static AuthorDTO toDto(Author author)
            {
                AuthorDTO authorDTO = new AuthorDTO();
                authorDTO.AuthorsId = author.AuthorsId;
                authorDTO.Name = author.Name;
                authorDTO.Surname = author.Surname;
                authorDTO.Status = author.Status;
                return authorDTO;
            }
            public static Author toEntity(AuthorDTO authorDTO)
            {
                Author author = new Author();
                author.AuthorsId = authorDTO.AuthorsId;
                author.Name = authorDTO.Name;
                author.Surname = authorDTO.Surname;
                author.Status = authorDTO.Status;
                return author;
            }
            public static List<BookDTO> ToDtoList(List<Book> book)
            {
                return book.ConvertAll(x => new BookDTO
                {
                        Name=x.Name,
                        AuthorName=x.Author.Name,
                        AuthorSurname=x.Author.Surname,
                        CategoryName=x.Category.CategoryName,
                        PublishYear=x.PublishYear,
                        Status=x.Status,
                        StockQuantity=x.StockQuantity
                });
            }
            public static List<AuthorDTO> toADtoList(List<Author> authors)
            {
                return authors.ConvertAll(x=>new AuthorDTO
                {
                    Name=x.Name,
                    Status=x.Status,
                    Surname=x.Surname,
                });
            }
        }

    }
}
