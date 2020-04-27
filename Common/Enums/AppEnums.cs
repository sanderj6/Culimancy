using System;

namespace Common.Enums
{
    public static class AppEnums
    {
        public enum DietType
        {
            Paleo = 0,
            Vegan = 1,
            Keto = 2,
            GlutenFree = 3,
            SouthBeach = 4,
            Mediterranean = 5,
            RawFood = 6,
            Atkins = 7,
            Zone = 8,
            Candida = 9,
            Vegetarian = 10
        }
        public enum FoodSensitivity
        {
            Gluten = 0,
            Dairy = 1,
            Cashew = 2,
            Nuts = 3
        }
        public enum Website
        {
            AllFoods = 0,
            FoodNetwork = 1,
            ThugKitchen = 2,
            Other = 3
        }
        public enum Measurements
        {
            Teaspoon = 0,
            Tablespoon = 1,
            Cup = 2,
            Pint = 3,
            Quart = 4,
            Gallon = 5,
            Ounce = 6,
            Pound = 7,
            Milliliter = 8,
            Inch = 9,
            CubicCentimeter = 10
        }
    }
}
