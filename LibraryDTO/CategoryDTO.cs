using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? Status { get; set; }
        public static class Converter
        {
            public static CategoryDTO toDto(Category category)
            {
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.CategoryId = category.CategoryId;
                categoryDTO.CategoryName = category.CategoryName;
                categoryDTO.Status = category.Status;
                return categoryDTO;
            }
            public static Category toEntity(CategoryDTO categoryDTO)
            {
                Category category = new Category();
                category.CategoryId = categoryDTO.CategoryId;
                category.CategoryName = categoryDTO.CategoryName;
                category.Status = categoryDTO.Status;
                return category;
            }
            public static List<BookDTO> toDtoList(List<Book> book)
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
            public static List<CategoryDTO> toCDtoList(List<Category> categories)
            {
                return categories.ConvertAll(x => new CategoryDTO
                {
                    CategoryName=x.CategoryName,
                    Status=x.Status
                });
            }

        }

    }
}
