
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;
using Culimancy.Common.HttpModels;

namespace Data.Search
{
    public interface ISearch
    {
        Task<EdamamResponseModel> GetRecipes(string search);
        Task<SpoonacularResponseModel> AskQuestion(string search);
    }
}