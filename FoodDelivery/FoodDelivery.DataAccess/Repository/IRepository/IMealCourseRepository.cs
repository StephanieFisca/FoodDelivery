using FoodDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DataAccess.Repository.IRepository
{
    public interface IMealCourseRepository : IRepository<MealCourse>
    {
        void Update(MealCourse obj);
    }
}
