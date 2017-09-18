using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojoLeague.Models;
 
namespace dojoLeague.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;
        public NinjaFactory()
        {
            //Change the "Database" name to match the database you are using
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=dojoLeague;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Ninja item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO ninjas (name, level, description, dojo_id) VALUES (@name, @level, @description, @dojo_id)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja, Dojo, Ninja>("SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id = dojos.id", (Ninja, Dojo) => {Ninja.dojo = Dojo; return Ninja; });
            }
        }
        public Ninja FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public Ninja UpdateDojo(int id, int dojo_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("UPDATE ninjas SET dojo_id = @Dojo_id WHERE id = @Id", new { Id = id , Dojo_id = dojo_id}).FirstOrDefault();
            }
        }
    }
}