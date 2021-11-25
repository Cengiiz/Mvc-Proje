using LibraryBLL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryDTO;
using static LibraryDTO.AuthorDTO;
using PagedList;
using PagedList.Mvc;
using static Core.StatusEnum;

namespace LibraryWebSite.Controllers
{
    public class AuthorController : Controller
    {
        
        AuthorManager authorManager = new AuthorManager();
        // GET: Author
        public ActionResult Author(string search,int sayfa = 1)
        {
            List<AuthorDTO> dgr=authorManager.GetbySearchkey(search,0).Select(Converter.toDto).ToList();
            var plist = dgr.ToPagedList(sayfa, 5);
            return View(plist);
        }
        [HttpGet]
        public ActionResult NewAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAuthor(AuthorDTO p1)
        {
            p1.Status = (int?)Status.Active;
            authorManager.Add(Converter.toEntity(p1));
            return RedirectToAction("Author");
        }
        public ActionResult AuthorDelete(int id)
        {
            
            authorManager.Delete(id);
            return RedirectToAction("Author");
        }
        public ActionResult GetAuthor(int id)
        {
            var authr =Converter.toDto(authorManager.GetbyId(id));
            return View("GetAuthor", authr);
        }
        public ActionResult GetBookbyAuthor(int id,int sayfa=1)
        {
            List<BookDTO> dgr =Converter.ToDtoList(authorManager.GetbyBook(id));
            var plist = dgr.ToPagedList(sayfa, 5);
            return View("GetBookbyAuthor",plist);
        }
        public ActionResult Update(AuthorDTO p1)
        {
            authorManager.Update(Converter.toEntity(p1));
            return RedirectToAction("Author");
        }

    }
}