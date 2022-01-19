using DapperExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CodeChallenge.Data
{
    public class StringRepresentationRepository : IStringRepresentationRepository
    {
        private readonly IConfiguration _config;

        public StringRepresentationRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Insert(StringRepresentation data)
        {
            var connectionString = _config["ConnectionStrings:StringRepresentationDB"];

            using var dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            var result = dbConnection.Insert(data);
        }
    }
}
