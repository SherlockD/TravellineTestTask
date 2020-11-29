namespace SecureResultCleanerLibrary.Sources.Extensions
{
    public static class SecureStringExtensions
    {
        public static string GetSecureString(this string inputString, char key)
        {
            return new string(key, inputString.Length);
        }
    }
}
