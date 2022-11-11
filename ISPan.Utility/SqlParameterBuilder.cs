using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISPan.Utility
{
	public class SqlParameterBuilder
	{
		private List<SqlParameter> parameters = new List<SqlParameter>(); //用集合,因為不知道會新增幾筆
		public SqlParameterBuilder AddNVarchar(string name, int length, string content)
		{
			var param = new SqlParameter(name, System.Data.SqlDbType.NVarChar, length)
			{ Value = content };
			parameters.Add(param);

			return this;
		}

		public SqlParameterBuilder AddInt(string name, int content)
		{
			var param = new SqlParameter(name, System.Data.SqlDbType.Int)
			{ Value = content };
			parameters.Add(param);

			return this;
		}
		public SqlParameterBuilder AddDateTime(string name, string content)
		{
			var param = new SqlParameter(name, System.Data.SqlDbType.DateTime)
			{ Value = Convert.ToDateTime(content)};
			parameters.Add(param);

			return this;
		}
		public SqlParameterBuilder AddBool(string name, bool content)
		{
			var param = new SqlParameter(name, System.Data.SqlDbType.Bit)
			{ Value = content };
			parameters.Add(param);

			return this;
		}
		public SqlParameter[] Build()
		{
			return parameters.ToArray();
		}
	}

}
