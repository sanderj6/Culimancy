
using System.Collections.Generic;
using System.Threading.Tasks;
using Culimancy.Common.HttpModels;

namespace Data.Search
{
    public interface ISearch
    {
        List<EdamamRecipe> GetRecipes(string search);
        SpoonacularResponseModel AskQuestion(string search);
    }
}