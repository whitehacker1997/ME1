namespace Global.Security
{
    public class CustomePasswordHasher
    {
        public string HashPassword(string password,
                                   string salt)
            => HashHelper.ComputeSaltedHash(password: password,
                                                salt: salt);

        public bool VerifyHashedPassword(string hashedPassword,
                                         string providedPassword,
                                         string salt)
        {
            if (string.Equals(hashedPassword,
                              HashHelper.ComputeSaltedHash(password: providedPassword,
                                                           salt: salt),
                                                           StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }
    }
}
