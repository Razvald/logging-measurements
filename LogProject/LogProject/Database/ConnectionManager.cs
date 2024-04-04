namespace LogProject.Database
{
    public static class ConnectionManager
    {
        private static string _connectionString;

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
