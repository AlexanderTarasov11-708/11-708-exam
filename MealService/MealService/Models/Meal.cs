using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealService.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
    }
}
