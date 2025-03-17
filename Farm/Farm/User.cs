using SQLite;

namespace Farm
{
    public class User
    {
        // Primary key with auto-increment
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Username must be unique and not null
        [Unique, NotNull]
        public string Username { get; set; }

        // Password must not be null
        [NotNull]
        public string Password { get; set; }

        // Email (optional, can be null)
        public string Email { get; set; }
    }
}