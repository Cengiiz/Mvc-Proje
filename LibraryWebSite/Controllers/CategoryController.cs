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
using static LibraryDTO.CategoryDTO;

namespace LibraryWebSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager();
        public ActionResult Category(string search,int sayfa = 1)
        {

            List<CategoryDTO> dgr = categoryManager.GetbySearchkey(search,0).Select(Converter.toDto).ToList();
            var plist = dgr.ToPagedList(sayfa, 5);
            return View(plist);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(CategoryDTO p1)
        {
            p1.Status = (int?)Status.Active;
            categoryManager.Add(Converter.toEntity(p1));
            return RedirectToAction("Category");
        }
        public ActionResult CategoryDelete(int id)
        {
            categoryManager.Delete(id);
            return RedirectToAction("Category");
        }
        public ActionResult GetCategory(int id)
        {
            var ctgr = Converter.toDto(categoryManager.GetbyId(id));
            return View("GetCategory", ctgr);
        }
        public ActionResult GetBookByCategory(int id,int sayfa=1)
        {
            List<BookDTO> dgr = Converter.toDtoList(categoryManager.GetbyBook(id));
            var plist = dgr.ToPagedList(sayfa, 5);
            return View("GetBookByCategory",plist);
        }
        public ActionResult Update(CategoryDTO category)
        {
            categoryManager.Update(Converter.toEntity(category));
            return RedirectToAction("Category");
        }
    }
}