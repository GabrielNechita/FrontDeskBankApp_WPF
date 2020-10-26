using System.Data.SqlClient;
using System.Data.SQLite;

namespace DAL
{
    public class Configurations
    {
        public static SQLiteConnection GetConnectionString()
        {
            return new SQLiteConnection(@"Data Source=MyDatabase.sqlite;");
        }
    }
}
