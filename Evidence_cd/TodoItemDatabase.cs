using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence_cd
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;
        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
            database.CreateTableAsync<TodoItemUser>().Wait();
        }
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }
        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0"); // klasické SQL
        }
        public Task<List<TodoItem>> GetItemsNotDoneAsync2(long price)
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE Price = " + price); // klasické SQL
        }
        public Task<List<TodoItemUser>> GetItemsNotDoneAsyncUser()
        {
            return database.QueryAsync<TodoItemUser>("SELECT * FROM [TodoItemUser]"); // klasické SQL
        }
        public Task<List<TodoItemUser>> GetItemsNotDoneAsyncUser2(string username)
        {
            return database.QueryAsync<TodoItemUser>("SELECT * FROM [TodoItemUser] WHERE Username=" + username); // klasické SQL
        }
        public Task<List<TodoItem>> GetItemsNotDoneAsyncOrderByAlphabet()
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] ORDER BY Album ASC");
        }
        public Task<List<TodoItem>> GetItemsNotDoneAsyncOrderByPrice()
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] ORDER BY Price ASC");
        }
        public Task<TodoItem> GetItemAsync(int id)
        {
            return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync(); // LINQ syntaxe
        }
        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsyncUser(TodoItemUser user)
        {
            if (user.ID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }
        public Task<int> DeleteItemAsync(TodoItem item)
        {
            return database.DeleteAsync(item);
        }
        public Task<int> DeleteItemAsyncUser(TodoItemUser user)
        {
            return database.DeleteAsync(user);
        }
        public Task<List<TodoItemUser>> Truncate()
        {
            return database.QueryAsync<TodoItemUser>("DELETE FROM [TodoItemUser]");
        }
    }

}
