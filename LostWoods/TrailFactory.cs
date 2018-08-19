using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostWoods.Models;
using Microsoft.Extensions.Options;


namespace LostWoods.Factory
{
    public class TrailFactory
    {
         private MySqlOptions _options;
        public TrailFactory(IOptions<MySqlOptions> config)
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
        public IEnumerable<Trails> AllTrails()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trails>("SELECT * FROM trails");
            }
        }
        public Trails GetTrailById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trails>("SELECT * FROM trails WHERE id = @id", new {Id = id}).FirstOrDefault();
            }
        }
        public void AddTrail(Trails trail)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = $@"INSERT INTO trails (name, description, trail_length, elevation, lat, lng) 
                VALUES (@name, @description, @trail_length, @elevation, @lat, @lng)";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
    }
}