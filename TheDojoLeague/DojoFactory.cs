using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using TheDojoLeague.Models;
using Microsoft.Extensions.Options;
using DojoLeague;

namespace TheDojoLeague.Factory
{
    public class DojoFactory
    {
        private MySqlOptions _options;
        public DojoFactory(IOptions<MySqlOptions> config)
        {
            _options = config.Value;
        }
        internal IDbConnection Connection
        {
            get 
            {
                return new MySqlConnection(_options.ConnectionString);
            }
        }

        // Dojos Methods
        public Dojos FindDojoById(long id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = 
                @"
                SELECT * FROM dojos WHERE id = @Id;
                SELECT * FROM ninjas WHERE dojo_id = @Id;
                ";
                using(var multi = dbConnection.QueryMultiple(query, new {Id=id}))
                {
                    Dojos dojo = multi.Read<Dojos>().Single();
                    dojo.ninjas = multi.Read<Ninjas>().ToList();
                    return dojo;
                }
            }
        }
        public void Banish(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = 5 WHERE Id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void Recruit(int dojoid, int ninjaid)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = {dojoid} WHERE Id = {ninjaid}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void CreateDojo(Dojos item)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = 
                @"
                    INSERT INTO dojos (name, location, extra, created_at, updated_at) 
                    VALUES (@name, @location, @extra, NOW(), NOW())
                ";
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Dojos> FindAllDojos()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojos>("SELECT * FROM dojos");
            }
        }


        // Ninjas Methods
        public IEnumerable<Ninjas> NinjasWithDojos()
        {
            using(IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id = dojos.Id";
                dbConnection.Open();
                IEnumerable<Ninjas> myNinjas = dbConnection.Query<Ninjas, Dojos, Ninjas>(query, (ninjas, dojos) => {ninjas.dojo = dojos; return ninjas;});
                return myNinjas;
            }
        }
        public void CreateNinja(Ninjas item)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var query = 
                @"
                    INSERT INTO ninjas (name, level, dojo_id, description, created_at, updated_at) 
                    VALUES (@name, @level, @dojo_id, @description, NOW(), NOW())
                ";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Ninjas> FindAllNinjas()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninjas>("SELECT * FROM ninjas");
            }
        }
        public Ninjas GetNinjaById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id = dojos.Id WHERE ninjas.Id = {id}";
                dbConnection.Open();
                var ninja = dbConnection.Query<Ninjas, Dojos, Ninjas>(query, (ninjas, dojos) => {ninjas.dojo = dojos; return ninjas;});
                return ninja.Single();
            }
        }
        public IEnumerable<Ninjas> RogueNinjas()
        {
            using(IDbConnection dbConnection = Connection)
            {
                var query = "SELECT * FROM ninjas WHERE dojo_id = 5";
                dbConnection.Open();
                return dbConnection.Query<Ninjas>(query).ToList();
            }
        }

    }
}