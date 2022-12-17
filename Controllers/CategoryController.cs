using _NET.Data;
using _NET.Models;
using Microsoft.AspNetCore.Mvc;
namespace _NET.Controllers;
public class CategoryController : Controller
{
  private readonly ApplicationDbContext _db;
  public CategoryController(ApplicationDbContext db)
  {
    _db = db;
  }
  public IActionResult Index() {
    IEnumerable<Category> objCategoryList = _db.Categories;
    return View(objCategoryList);
  }
  // GET
  public IActionResult Create() {
    return View();
  }
  // POST
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create(Category obj) {
    if(ModelState.IsValid) {
      _db.Categories.Add(obj);
      _db.SaveChanges();
      TempData["created"] = "Category created successfully";
      return RedirectToAction("Index");
    }
    return View(obj);
  }
  // GET
  public IActionResult Edit(int? id) {
    if(id==null || id==0) {
      return NotFound();
    }
    var categoryFromDb = _db.Categories.Find(id);
    // var categoryFromFirst = _db.Categories.FirstOrDefault(u => u.Id==id);
    // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id==id);
    if(categoryFromDb==null) {
      return NotFound();
    }
    return View(categoryFromDb);
  }
  // POST
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(Category obj) {
    if(ModelState.IsValid) {
      _db.Categories.Update(obj);
      _db.SaveChanges();
      TempData["updated"] = "Category updated successfully";
      return RedirectToAction("Index");
    }
    return View(obj);
  }
  // GET
  public IActionResult Delete(int? id) {
    if(id==null || id==0) {
      return NotFound();
    }
    var categoryFromDb = _db.Categories.Find(id);
    // var categoryFromFirst = _db.Categories.FirstOrDefault(u => u.Id==id);
    // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id==id);
    if(categoryFromDb==null) {
      return NotFound();
    }
    return View(categoryFromDb);
  }
  // POST
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public IActionResult DeletePost(int? id) {
    var obj = _db.Categories.Find(id);
    if(obj==null) {
      return NotFound();
    }
    _db.Categories.Remove(obj);
    _db.SaveChanges();
    TempData["deleted"] = "Category deleted successfully";
    return RedirectToAction("Index");
  }
}