using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Enums;

namespace Culimancy.Common.HttpModels
{
    public class SpoonacularResponseModel
    {
        public string answer { get; set; }
        public string image { get; set; }
        public string type { get; set; }
    }
}