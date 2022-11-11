using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPan.Utility
{
	public class SqlDbHelper
	{
		private string connString; //保存在外避免被修改
		/// <summary>
		/// 連結資料庫
		/// </summary>
		/// <param name="connectedKey">App.Config內幫資料庫取的名字</param>
		public SqlDbHelper(string connectedKey)
		{
			connString = System.Configuration.ConfigurationManager.
						ConnectionStrings[connectedKey].ConnectionString;
		}
		/// <summary>
		/// ExecuteNonQuery 用來執行delete,Insert,Update沒回傳值的SQL
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="param"></param>
		public void ExecuteNonQuery(string sql, SqlParameter[]param) 
		{
			using (var conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open(); //確定有指令才開啟資料庫 脫離using則關閉

				cmd.Parameters.AddRange(param);
				cmd.ExecuteNonQuery(); 
			}
		}
		public DataTable SelectTable(string sql, SqlParameter[] param)
		{
			using (var conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand(sql, conn);
				conn.Open();
				if (param != null)
				{
					cmd.Parameters.AddRange(param);
				}
				SqlDataAdapter adapter = new SqlDataAdapter(cmd);

				DataSet dataSet = new DataSet();
				adapter.Fill(dataSet, "virtualTable");
				return dataSet.Tables["virtualTable"];
			}
		}

	}
}
