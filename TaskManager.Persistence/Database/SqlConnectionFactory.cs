using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TaskManager.Persistence.Database
{
	public sealed class SqlConnectionFactory : ISqlConnectionFactory
	{
		private readonly string _connectionString;

		public SqlConnectionFactory(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("DefaultConnection")!;
		}

		public async Task<IDbConnection> CreateConnectionAsync()
		{
			var connection = new SqlConnection(_connectionString);

			await connection.OpenAsync();

			return connection;
		}
	}
}
