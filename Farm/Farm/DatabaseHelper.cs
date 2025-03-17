using Farm;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Farm
{
    public class DatabaseHelper
    {
        private static SQLiteAsyncConnection _database;

        // Singleton pattern for database connection
        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (_database == null)
                {
                    // Set the database path
                    var databasePath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

                    // Initialize the database connection
                    _database = new SQLiteAsyncConnection(databasePath);

                    // Create the User table if it doesn't exist
                    _database.CreateTableAsync<User>().Wait();
                }
                return _database;
            }
        }
    }
}