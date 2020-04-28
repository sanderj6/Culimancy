using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Culimancy.Common.Models
{
    public class RecipeModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public float Calories { get; set; }
        public List<string> Ingredients { get; set; }
        public List<AppEnums.DietType> DietTypes { get; set; }
        public List<AppEnums.FoodSensitivity> FoodSensitivities { get; set; }

    }
}