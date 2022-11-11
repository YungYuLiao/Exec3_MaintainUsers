using System;
using ISPan.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace Exec3_MaintainUsers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Insert
			string sql1 = @"Insert into Users(Name, Account, Password, DateOfBirth, Height) 
			                        values (@Name, @Account, @Password, @DateOfBirth, @Height)";
			var param1 = new SqlParameterBuilder()
							.AddNVarchar("Name", 50, "Elle")
							.AddNVarchar("Account", 50, "101")
							.AddNVarchar("Password", 50, "101")
							.AddDateTime("DateOfBirth", "1992.7.05")
							.AddInt("Height", 172).Build();
			CrudHelper.Insert(sql1, param1);
			//Delete
			string sql2 = @"Delete from Users where Id=@Id";
			var param2 = new SqlParameterBuilder()
							.AddInt("Id", 3).Build();
			CrudHelper.Delete(sql2, param2);

			//Update
			string sql3 = @"Update Users set Name=@Name, Account=@Account, Password=@Password
                                           , DateOfBirth=@DateOfBirth, Height=@Height
                                             where Id=@Id";
			var param3 = new SqlParameterBuilder()
							.AddNVarchar("Name", 50, "Cathy")
							.AddNVarchar("Account", 50, "789")
							.AddNVarchar("Password", 50, "987")
							.AddDateTime("DateOfBirth", "1993.1.18")
							.AddInt("Height", 172)
							.AddInt("Id", 4).Build();
			CrudHelper.Update(sql3, param3);

			//Select
			string sql4 = @"select id, name from Users where Id=@Id";
			var param4 = new SqlParameterBuilder().AddInt("Id", 1).Build();
			DataTable users = CrudHelper.Select(sql4, param4);
			foreach (DataRow row in users.Rows)
			{
				int id = row.Field<int>("id");
				string name = row.Field<string>("name");
				Console.WriteLine($"id={id},name={name}");
			}
		}
	}
}
