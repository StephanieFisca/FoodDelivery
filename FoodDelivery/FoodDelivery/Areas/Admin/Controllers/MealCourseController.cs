using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Repository.IRepository;
using FoodDelivery.Models;
using FoodDelivery.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MealCourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MealCourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<MealCourse> objMealCourseList = _unitOfWork.MealCourse.GetAll();
            return View(objMealCourseList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MealCourse obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MealCourse.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "MealCourse created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            var MealCourseFromDbFirst = _unitOfWork.MealCourse.GetFirstOrDefault(u => u.Id == id);

            if (MealCourseFromDbFirst == null)
            {
                return NotFound();
            }
            return View(MealCourseFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MealCourse obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MealCourse.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "MealCourse edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var MealCourseFromDbFirst = _unitOfWork.MealCourse.GetFirstOrDefault(u => u.Id == id);

            if (MealCourseFromDbFirst == null)
            {
                return NotFound();
            }
            return View(MealCourseFromDbFirst);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.MealCourse.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.MealCourse.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "MealCourse deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
