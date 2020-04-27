using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Common.Models
{
    public class GuestModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string CMSId { get; set; }
        public List<AppEnums.DietType> DietTypes { get; set; }
        public List<AppEnums.FoodSensitivity> FoodSensitivities { get; set; }
        public List<RecipeModel> RecipeHistory { get; set; }

    }
}