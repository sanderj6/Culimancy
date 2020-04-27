using Newtonsoft.Json;
using System;

namespace Common.Models
{
    public abstract class BaseModel
    {
        public bool IsDataValid { get; set; }
        public string DataValidMsg { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}