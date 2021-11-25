using LibraryBLL.Concrete;
using LibraryDTO;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Core.StatusEnum;
using static LibraryDTO.BookDTO;

namespace LibraryWebSite.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        BookManager bookManager = new BookManager();
        CategoryManager categoryManager = new CategoryManager();
        AuthorManager authorManager = new AuthorManager();
        public ActionResult Book(string search,int sayfa = 1)
        {
            List<BookDTO> dgr = bookManager.GetbySearchkey(search,0).Select(Converter.toDto).ToList();
            var plist = dgr.ToPagedList(sayfa, 5);
            return View(plist); ;
        }
        [HttpGet]
        public ActionResult NewBook()
        {
            List<SelectListItem> dgr = (from i in authorManager.GetAll()
                                        select new SelectListItem
                                        {
                                            Text = i.Name+" "+i.Surname,
                                            Value = i.AuthorsId.ToString()
                                        }).ToList();
            ViewBag.autr = dgr;
            List<SelectListItem> dgrr = (from i in categoryManager.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = i.CategoryName,
                                             Value = i.CategoryId.ToString()
                                         }).ToList();
            ViewBag.ctgr = dgrr;
            return View();
        }
        [HttpPost]
        public ActionResult NewBook(BookDTO p1)
        {

            p1.Status = (int?)Status.Active;
            bookManager.Add(Converter.toEntity(p1));
            return RedirectToAction("Book");
        }
        public ActionResult BookDelete(int id)
        {
            bookManager.Delete(id);
            return RedirectToAction("Book");
        }
        public ActionResult GetBook(int id)
        {
            List<SelectListItem> dgr = (from i in authorManager.GetAll()
                                        select new SelectListItem
                                        {
                                            Text = i.Name,
                                            Value = i.AuthorsId.ToString()
                                        }).ToList();
            ViewBag.autr = dgr;
            List<SelectListItem> dgrr = (from i in categoryManager.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = i.CategoryName,
                                             Value = i.CategoryId.ToString()
                                         }).ToList();
            ViewBag.ctgr = dgrr;
            var book =Converter.toDto(bookManager.GetbyId(id));
            return View("GetBook", book);
        }
        public ActionResult Update(BookDTO book)
        {
            bookManager.Update(Converter.toEntity(book));
            return RedirectToAction("Book");
        }
    }
}