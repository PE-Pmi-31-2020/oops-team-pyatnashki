using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;

namespace FiveOursDAL.ConnectionString
{
    public class Connection
    {
        public string ConnectionString { get; set; }


        public static string ReadConnectionString()
        {
            var jsonString = File.ReadAllText(@"settings.json");
            var connection =  JsonSerializer.Deserialize<Connection>(jsonString);
            return connection.ConnectionString;
        }
    }
}
