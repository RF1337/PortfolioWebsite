namespace PortfolioRestAPI.Models
{
    // Project class that will be set to the data from the database
    public class Project
    {
        public int ProjectID { get; }
        public string Title { get; }
        public string Description { get; }
        public string Link { get; }

        // Creating a constructor so the DALManager's NpgsqlReader can read the parameters of a project object
        public Project(int id, string title, string description, string link)
        {
            ProjectID = id;
            Title = title;
            Description = description;
            Link = link;
        }
    }
}
