using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ImageProfiles.Representation
{
	public class DatabaseManager
	{
		private static readonly Lazy<DatabaseManager> Lazy = new Lazy<DatabaseManager>(
			() => new DatabaseManager(), LazyThreadSafetyMode.ExecutionAndPublication);

		public static DatabaseManager Instance => Lazy.Value;
		public readonly string Server;
		public readonly string Database;
		private readonly string _connectionString;

		private DatabaseManager()
		{
			Server = @"(LocalDb)\LocalDBDemo";
			Database = "DemoDB";
			_connectionString = $"Data Source={Server};Initial Catalog={Database};Integrated Security=true;";
		}

		public DataTable ExecuteSelect(string query)
		{
			var table = new DataTable();
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var sqlDataAdapter = new SqlDataAdapter(query, connection))
				{
					sqlDataAdapter.Fill(table);
				}
			}

			return table;
		}

		public int ExecuteInsert(string query)
		{
			return ExecuteInsertOrUpdate(query);
		}

		public int ExecuteUpdate(string query)
		{
			return ExecuteInsertOrUpdate(query);
		}

		private int ExecuteInsertOrUpdate(string query)
		{
			int rowsAffected;
			using (var connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (var sqlCommand = new SqlCommand(query, connection))
				{
					rowsAffected = sqlCommand.ExecuteNonQuery();
				}
			}

			return rowsAffected;
		}
	}
}