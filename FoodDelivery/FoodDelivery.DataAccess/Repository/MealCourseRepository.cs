using FoodDelivery.DataAccess.Repository.IRepository;
using FoodDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DataAccess.Repository
{
    public class MealCourseRepository : Repository<MealCourse>, IMealCourseRepository
    {
        private ApplicationDbContext _db;

        public MealCourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(MealCourse obj)
        {
            _db.MealCourses.Update(obj);
        }
    }
}
