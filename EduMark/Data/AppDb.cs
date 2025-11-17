using SQLite;
using System.IO;

namespace EduMark.Data
{
    public class AppDb
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDb()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "edumark.db");
            _db = new SQLiteAsyncConnection(dbPath);

            // Create all tables
            _db.CreateTableAsync<Teacher>().Wait();
            _db.CreateTableAsync<Class>().Wait();
            _db.CreateTableAsync<Student>().Wait();
            _db.CreateTableAsync<Mark>().Wait();
            _db.CreateTableAsync<Term>().Wait();
            _db.CreateTableAsync<Year>().Wait();
            _db.CreateTableAsync<TimetableSlot>().Wait();
            _db.CreateTableAsync<EmailOtp>().Wait();
        }

        public SQLiteAsyncConnection Connection => _db;
    }
}
