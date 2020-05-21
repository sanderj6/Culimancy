using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Culimancy.Common.HttpModels
{
    public class RootObject
    {
        public int count { get; set; }
        public IngredientDB[] tags { get; set; }
    }
    public class IngredientDB
    {
        public string name { get; set; }
        public int products { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public int known { get; set; }
        //public string[] sameAs { get; set; }
    }


}
