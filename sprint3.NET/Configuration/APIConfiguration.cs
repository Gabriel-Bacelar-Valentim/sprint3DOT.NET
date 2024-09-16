namespace sprint3.NET.Configuration
{
    public class APIConfiguration
    {
        public SwaggerInfo Swagger { get; set; }

        public OracleFIAPServiceConnection OracleFIAP { get; set; }

        public class OracleFIAPServiceConnection
        {
            public string Host { get; set; }

            public string UserID { get; set; }

            public string Password { get; set; }

            public int Port { get; set; }

            public string SID { get; set; }


            public string ConnectionString
            {
                get { return $"Data Source={Host}:{Port}/{SID};User ID={UserID};Password={Password};"; }
            }
        }

        public class SwaggerInfo
        {
            public string Title { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
