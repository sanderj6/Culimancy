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
            connectionStringMain = "Host=localhost;Username=postgres;Password=Youngcakes12;Database=Culimancy";
            //connectionStringUser = config.GetConnectionString("PostgresUserConnection");
            connectionStringUser += "Database=";
        }
        public NpgsqlConnection Connection => new NpgsqlConnection(connectionStringMain);
        public async Task<RecipeModel> Add(RecipeModel item)
        {
            try
            {
                using (var dbConnection = new NpgsqlConnection(connectionStringMain))
                {
                    await dbConnection.OpenAsync();
                    var result = await dbConnection.QueryFirstAsync<RecipeModel>(@"SELECT * FROM ""Recipe_Add""" +
                        "(@Name)",
                        new { Name = item.Name });
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
                    var result = await dbConnection.QueryAsync<RecipeModel>(@"SELECT * FROM ""Recipe_Get""" +
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