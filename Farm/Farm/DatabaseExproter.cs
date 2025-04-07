using Xamarin.Essentials;
using System;
using System.IO;
using System.Threading.Tasks;

public static class DatabaseExporter
{
    public static async Task ShareDatabaseFileAsync()
    {
        try
        {
            // Get the path to the database
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

            // Check if the file exists
            if (File.Exists(dbPath))
            {
                // Share the database file using Xamarin.Essentials
                await Share.RequestAsync(new ShareFileRequest
                {
                    Title = "Share SQLite Database",
                    File = new ShareFile(dbPath)
                });
            }
            else
            {
                Console.WriteLine("Database file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sharing database file: {ex.Message}");
        }
    }
}
