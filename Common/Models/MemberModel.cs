using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Culimancy.Common.Models
{
    public class MemberModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public List<AppEnums.DietType> DietTypes { get; set; }
        public List<AppEnums.FoodSensitivity> FoodSensitivities { get; set; }
        public List<RecipeModel> FavoriteRecipes { get; set; }
        public List<string> RecentSearches { get; set; }
    }
}