using Npgsql;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace PortfolioRestAPI
{
    public class DALManager
    {
        private readonly IConfiguration _config;

        public DALManager(IConfiguration configuration)
        {
            _config = configuration;
        }

        public List<Project> GetProject()
        {
            List<Project> _tmpProjects = new List<Project>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_config["ConnectionString"]))
            {
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM project";

                        connection.Open();

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _tmpProjects.Add(new Project(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            }
                        }
                    }
                }
                catch (NpgsqlException e)
                {
                    Debug.WriteLine("An NPG error occurred: " + e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return _tmpProjects;
        }




       


    }
}
