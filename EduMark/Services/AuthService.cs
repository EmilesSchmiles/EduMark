using EduMark.Data;
using BCrypt.Net;
using SQLite;

namespace EduMark.Services
{
    public class AuthService
    {
        private readonly AppDb _db;

        public AuthService(AppDb db)
        {
            _db = db;
        }

        // Register a new teacher
        public async Task<bool> RegisterTeacherAsync(string fullName, string email, string password)
        {
            var existing = await _db.Connection.Table<Teacher>()
                .Where(t => t.Email == email)
                .FirstOrDefaultAsync();

            if (existing != null)
                return false;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var teacher = new Teacher
            {
                FullName = fullName,
                Email = email,
                PasswordHash = hashedPassword
            };

            await _db.Connection.InsertAsync(teacher);
            return true;
        }

        // Login
        public async Task<Teacher?> LoginAsync(string email, string password)
        {
            var teacher = await _db.Connection.Table<Teacher>()
                .Where(t => t.Email == email)
                .FirstOrDefaultAsync();

            if (teacher == null)
                return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password, teacher.PasswordHash);
            return verified ? teacher : null;
        }
    }
}
