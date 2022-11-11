using System;
using ISPan.Utility;
using System.Data.SqlClient;
using System.Data;

namespace Exec3_MaintainUsers
{
	public class CrudHelper
	{
		public static void Insert(string sql, SqlParameter[] param)
		{
			try
			{
				var dbHelper = new SqlDbHelper("default");
				dbHelper.ExecuteNonQuery(sql, param);
				Console.WriteLine("已成功記錄");
			}
			catch (Exception ex)
			{

				Console.WriteLine($"失敗,原因為:{ex.Message}");
			}
		}
		public static void Delete(string sql, SqlParameter[] param)
		{
			try
			{
				var dbHelper = new SqlDbHelper("default");
				dbHelper.ExecuteNonQuery(sql, param);
				Console.WriteLine("已刪除記錄");
			}
			catch (Exception ex)
			{

				Console.WriteLine($"失敗,原因為:{ex.Message}");
			}
		}
		public static void Update(string sql, SqlParameter[] param)
		{
			try
			{
				var dbHelper = new SqlDbHelper("default");
				dbHelper.ExecuteNonQuery(sql, param);
				Console.WriteLine("已更新記錄");
			}
			catch (Exception ex)
			{

				Console.WriteLine($"失敗,原因為:{ex.Message}");
			}
		}
		public static DataTable Select(string sql, SqlParameter[] param)
		{
			var dbHelper = new SqlDbHelper("default");
			try
			{
				dbHelper = new SqlDbHelper("default");
				Console.WriteLine("已讀取記錄");

			}
			catch (Exception ex)
			{

				Console.WriteLine($"失敗,原因為:{ex.Message}");
			}
			return dbHelper.SelectTable(sql, param);
		}
	}
}
