using Proyecto2_2.Models;
using SQLite;
using Proyecto2_2.View;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Proyecto2_2.Controller
{
    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(String dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Signature>().Wait();
        }

        public Task<List<Signature>> GetSignatureAsync()
            
        {
            return _database.Table<Signature>().ToListAsync();
        }

        public Task<int> SaveSignatureAsync(Signature signature)
        {
            if (signature.Id != 0)
            {
                return _database.UpdateAsync(signature);
            }
            else
            {
                return _database.InsertAsync(signature);
            }
        }

    }
}


