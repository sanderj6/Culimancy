using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Helpers;
using Culimancy.Common.HttpModels;
using Culimancy.Common.Models;
using Dapper;
using Data.Search;
using GenericInterfaces.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Storage
{
    public class RecipeRepository
    {
        private ILogger _logger;
        private string connectionStringMain;
        private string connectionStringUser;

        public RecipeRepository(IConfiguration config, ILoggerFactory loggerFactory)
        {
            // Load the Connection String from the config
            _logger = loggerFactory.CreateLogger<RecipeRepository>();
            connectionStringMain = "Host=culimancy-dev.cccfv62sr8ci.us-east-2.rds-preview.amazonaws.com;Username=sanderj6;Password=Youngcakes12;Database=culimancy_dev";
            //connectionStringUser = config.GetConnectionString("PostgresUserConnection");
            connectionStringUser += "Database=";
        }
        public NpgsqlConnection Connection => new NpgsqlConnection(connectionStringMain);
        public async Task<RecipeModel> Add(RecipeModel recipe)
        {
            try
            {
                using (var dbConnection = new NpgsqlConnection(connectionStringMain))
                {
                    await dbConnection.OpenAsync();
                    var result = await dbConnection.QueryFirstAsync<RecipeModel>(@"SELECT * FROM ""Recipes_AddOrUpdate""" +
                        "(@Name,@WebsiteURL,@SourceName,@ImageURL,@Calories)",
                        new { Name = recipe.Name, WebsiteURL = recipe.Website, SourceName = recipe.Source, ImageURL = recipe.Image, Calories = recipe.Calories });
                    return result;
                }
            }
            catch (NpgsqlException e)
            {
                _logger.LogError(e, "Failed to add recipe.");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add recipe.");
                throw;
            }
        }
        public async Task<string> Add(string ingredient)
        {
            try
            {
                using (var dbConnection = new NpgsqlConnection(connectionStringMain))
                {
                    await dbConnection.OpenAsync();
                    var result = await dbConnection.QueryFirstAsync<string>(@"SELECT * FROM ""Ingredients_AddOrUpdate""" +
                                                                                 "(@Ingredient)",
                        new { Ingredient = ingredient });
                    return result;
                }
            }
            catch (NpgsqlException e)
            {
                _logger.LogError(e, "Failed to add recipe.");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add recipe.");
                throw;
            }
        }
        public async Task<IEnumerable<RecipeModel>> Get(string item)
        {
            try
            {
                using (var dbConnection = new NpgsqlConnection(connectionStringMain))
                {
                    await dbConnection.OpenAsync();
                    var result = await dbConnection.QueryAsync<RecipeModel>(@"SELECT * FROM ""Recipes_Get""" +
                        "(@Name)",
                        new { Name = item });
                    return result;
                }
            }
            catch (NpgsqlException e)
            {
                _logger.LogError(e, "Failed to add recipe.");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add recipe.");
                throw;
            }
        }
    }
}