using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Helpers;
using Culimancy.Common.HttpModels;
using Culimancy.Common.Models;
using Data.Search;
using GenericInterfaces.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Storage;

namespace GenericInterfaces.Search
{
    public class SearchGI : ISearchGI
    {
        private IConfiguration _config;
        private ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private readonly HttpContext _httpContext;
        private IHttpClientFactory _httpClientFactory;

        public SearchGI(IConfiguration config, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<SearchGI>();
            _config = config;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public SpoonacularResponseModel AskQuestion(string search)
        {
            try
            {
                //var searchEngine = DIExtensions.GetServiceByType(_httpContext.RequestServices.GetServices<ISearch>(), typeof(SearchEngine));
                SearchEngine searchEngine = new SearchEngine(_config,_loggerFactory, _httpClientFactory);
                var recipes = searchEngine.AskQuestion(search);

                return recipes;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to find food!");
                return new SpoonacularResponseModel();
            }
        }
        public List<EdamamRecipe> GetRecipes(string search)
        {
            try
            {
                //var searchEngine = DIExtensions.GetServiceByType(_httpContext.RequestServices.GetServices<ISearch>(), typeof(SearchEngine));
                SearchEngine searchEngine = new SearchEngine(_config, _loggerFactory, _httpClientFactory);
                var recipes = searchEngine.GetRecipes(search);

                return recipes;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to find food!");
                return new List<EdamamRecipe>();
            }
        }

        public List<RecipeModel> GetRecipes(string search, string website)
        {
            SearchEngine searchEngine = new SearchEngine(_config, _loggerFactory, _httpClientFactory);
            var recipes = searchEngine.GetRecipes(search, website);

            return recipes;
        }

        //Repository
        public async Task<RecipeModel> AddRecipe(RecipeModel recipe)
        {
            RecipeRepository repo = new RecipeRepository(_config, _loggerFactory);
            var response = await repo.Add(recipe);

            return response;
        }
        public async Task<string> AddIngredient(string ingredient)
        {
            RecipeRepository repo = new RecipeRepository(_config, _loggerFactory);
            var response = await repo.Add(ingredient);

            return response;
        }
        public async Task<List<RecipeModel>> GetRecipeByKeyword(string keyword)
        {
            RecipeRepository repo = new RecipeRepository(_config, _loggerFactory);
            var response = await repo.Get(keyword);

            return response.ToList();
        }

    }
}