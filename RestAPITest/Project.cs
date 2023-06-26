namespace PortfolioRestAPI
{
    // Project class that will be set to the data from the database
    public class Project
    {
        public int ProjectID { get; set; }
        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public string Link { get; set; } = string.Empty;

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
