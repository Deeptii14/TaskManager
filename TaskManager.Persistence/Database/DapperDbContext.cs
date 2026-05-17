using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TaskManager.Persistence.Database
{
	public class DapperDbContext
	{
		private readonly IConfiguration _configuration;

		public DapperDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IDbConnection CreateConnection()
		{
			return new SqlConnection(
				_configuration.GetConnectionString("DefaultConnection"));
		}
	}
}
