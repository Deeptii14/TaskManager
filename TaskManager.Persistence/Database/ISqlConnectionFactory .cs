using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TaskManager.Persistence.Database
{
	public interface ISqlConnectionFactory
	{
		Task<IDbConnection> CreateConnectionAsync();
	}
}
