using Npgsql;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace PortfolioRestAPI
{
    public class DALManager
    {
        // Dependency injecting the IConfiguration
        private readonly IConfiguration _config;
        public DALManager(IConfiguration configuration)
        {
            _config = configuration;
        }

        // Creating a method named GetProject which returns a List of Project(s)
        public List<Project> GetProject()
        {
            // Creating a list to hold the content
            List<Project> _tmpProjects = new List<Project>();
            // Using an NpgsqlConnection which uses the parameters from the ConnectionString in my IConfiguration
            using (NpgsqlConnection connection = new NpgsqlConnection(_config["ConnectionString"]))
            {
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        // Telling the command what connection it should use
                        command.Connection = connection;
                        // What is the text that it should use
                        command.CommandText = "SELECT * FROM project";
                        // Opening the connection
                        connection.Open();

                        // Using a DataReader that reads the command
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {   // While the reader is reading
                            while (reader.Read())
                            {   // Add the projects with it's parameters to the list
                                _tmpProjects.Add(new Project(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                            }
                        }
                    }
                }
                catch (NpgsqlException e)
                {   // Catch a NpgsqlException
                    Debug.WriteLine("An NPG error occurred: " + e.Message);
                }
                catch (Exception ex)
                {   // Catch any other errors
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {   // Close the connection
                    connection.Close();
                }
            }
            // Return the list
            return _tmpProjects;
        }
    }
}
