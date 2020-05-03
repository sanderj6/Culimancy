using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Culimancy.Common.Models;
using Npgsql;

namespace Storage
{
    // Generic Interface for CRUD operations on a DB Repository
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(T item);
        Task<T> GetByValue(string value);
        Task<IEnumerable<T>> GetAllByValue(string value);
        Task<T> GetByID(int id);
        Task<IEnumerable<T>> GetAll();
        NpgsqlConnection Connection { get; }
    }
}