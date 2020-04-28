using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Culimancy.Common.Models
{
    public class IngredientModel : BaseModel
    {
        public string Name { get; set; }

    }
}