﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Culimancy.Common.HttpModels;
using Culimancy.Common.Models;
using RestSharp;

namespace Data.Search
{
    public class SearchEngine : ISearch
    {
        private IConfiguration _config;
        private ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private IHttpClientFactory _httpClientFactory;
        public SearchEngine(IConfiguration config, ILoggerFactory loggerFactory, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<SearchEngine>();
            _httpClientFactory = httpClientFactory;
        }
        //Method to get the rebates per vehicle and store. Returns a list of rebates, and a compatability list for the ID of each rebate.
        public SpoonacularResponseModel AskQuestion(string search)
        {
            SpoonacularResponseModel spoonResponse = new SpoonacularResponseModel();

            try
            {
                //Add query to Spoonacular URL
                string longurl = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/quickAnswer?";
                var uriBuilder = new UriBuilder(longurl);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["q"] = search;
                uriBuilder.Query = query.ToString();
                longurl = uriBuilder.ToString();

                //var client2 = new RestClient("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/quickAnswer?q=How%20much%20vitamin%20c%20is%20in%202%20apples%253F");
                var client = new RestClient(longurl);
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "34d5d6ceb9msh8dbc51d6a03bd09p1e7952jsndc6dd745ae88");

                IRestResponse response = client.Execute(request);

                //msg.EnsureSuccessStatusCode();

                spoonResponse = JsonConvert.DeserializeObject<SpoonacularResponseModel>(response.Content);
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to find recipes! {e}. Data: {search}");
            }

            return spoonResponse;
        }

        public async Task<List<EdamamRecipe>> GetRecipes(string search)
        {
            EdamamResponseModel edamamResponse = new EdamamResponseModel();
            List<EdamamRecipe> searchResults = new List<EdamamRecipe>();

            try
            {
                //Add query to Spoonacular URL
                string longurl = "https://api.edamam.com/search?";
                var uriBuilder = new UriBuilder(longurl);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["q"] = search;
                query["app_id"] = "feb60dd7";
                query["app_key"] = "62bfd3c9dcb85d7d65c2a8d30bc5509a";
                uriBuilder.Query = query.ToString();
                longurl = uriBuilder.ToString();

                var client = new RestClient(longurl);
                var request = new RestRequest(Method.GET);

                IRestResponse response = await client.ExecuteAsync(request);

                //msg.EnsureSuccessStatusCode();
                edamamResponse = JsonConvert.DeserializeObject<EdamamResponseModel>(response.Content);
                searchResults = edamamResponse.hits.Select(x => x.recipe).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to find recipes! {e}. Data: {search}");
            }

            return searchResults;
        }
        public List<RecipeModel> GetRecipes(string search, string website)
        {
            List<RecipeModel> searchResults = new List<RecipeModel>();
            List<string> headers = new List<string>();
            try
            {
                var web = new HtmlAgilityPack.HtmlWeb();
                var doc = web.Load("https://www.bonappetit.com/recipe/chicken-tikka-masala");
                var headerNames = doc.DocumentNode.SelectNodes("//li[@class='ingredient']")?.ToList();
                var name = doc.DocumentNode.SelectSingleNode("//a[@name='top']").InnerText;
                var image = doc.DocumentNode.SelectSingleNode("//img[@class='ba-picture--fit']");
                var imagesrc = image.Attributes["srcset"].Value.Split(" ")[0];

                foreach (var item in headerNames)
                {
                    headers.Add(item.InnerText);
                }

                searchResults.Add(new RecipeModel()
                {
                    Name = name,
                    Image = imagesrc,
                    Website = "https://www.bonappetit.com/recipe/chicken-tikka-masala",
                    Source = "Bon-Appetit",
                    //Calories = result.calories,
                    Ingredients = headers
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to find recipes! {e}. Data: {search}");
            }

            return searchResults;
        }
    }
}