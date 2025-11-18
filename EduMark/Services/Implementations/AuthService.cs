using EduMark.Data;
using EduMark.Services.Interfaces;
using SQLite;

namespace EduMark.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AppDb _db;
        private readonly IEmailService _emailService;

        public AuthService(AppDb db, IEmailService emailService)
        {
            _db = db;
            _emailService = emailService;
        }

        // Register a new teacher + SEND OTP
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
                PasswordHash = hashedPassword,
                IsVerified = false
            };

            await _db.Connection.InsertAsync(teacher);

            // Generate OTP
            string otp = new Random().Next(100000, 999999).ToString();

            var otpEntry = new EmailOtp
            {
                Email = email,
                Otp = otp,
                Expiry = DateTime.UtcNow.AddMinutes(10)
            };

            await _db.Connection.InsertAsync(otpEntry);

            // Send email
            await _emailService.SendOtpAsync(email, otp);

            return true;
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            var entry = await _db.Connection.Table<EmailOtp>()
                .Where(o => o.Email == email && o.Otp == otp)
                .FirstOrDefaultAsync();

            if (entry == null || entry.Expiry < DateTime.UtcNow)
                return false;

            // Mark teacher verified
            var teacher = await _db.Connection.Table<Teacher>()
                .Where(t => t.Email == email)
                .FirstOrDefaultAsync();

            teacher!.IsVerified = true;
            await _db.Connection.UpdateAsync(teacher);

            await _db.Connection.DeleteAsync(entry);

            return true;
        }

        public async Task<Teacher?> LoginAsync(string email, string password)
        {
            var teacher = await _db.Connection.Table<Teacher>()
                .Where(t => t.Email == email)
                .FirstOrDefaultAsync();

            if (teacher == null)
                return null;

            if (!teacher.IsVerified)
                return null;

            bool verified = BCrypt.Net.BCrypt.Verify(password, teacher.PasswordHash);
            return verified ? teacher : null;
        }
    }
}
