using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BabyBook.Model
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Baby>().Wait();
            _database.CreateTableAsync<FirstMoments>().Wait();
        }

        #region Baby
        public Task<List<Baby>> GetBaby(int id)
        {
            return _database.Table<Baby>()
                .ToListAsync();
        }

        public Task<int> SavePersonAsync(Baby baby)
        {
            return _database.InsertAsync(baby);
        }
        #endregion
    }
}
