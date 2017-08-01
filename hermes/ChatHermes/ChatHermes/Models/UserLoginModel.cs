using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChatHermes.Models
{
    public class LoginModel
    {
        [Required]
        public string UN { get; set; }
        public string PW { get; set; }

        public bool CanEnter(string name, string pass)
        {
            using (var connection = new SqlConnection())
            {
                string command = @"SELECT [UserName] FROM [dbo].[User] " + @"WHERE [UserName] = @u AND [Password] = @p";
                var cmd = new SqlCommand(command, connection);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = name;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = Helpers.SHA1.Encode(pass);
                connection.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }

    }
}