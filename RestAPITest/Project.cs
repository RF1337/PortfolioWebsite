namespace PortfolioRestAPI
{
    public class Project
    {
        public int Project_ID { get; set; }
        public string Title { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public string Link { get; set; } = string.Empty;

        public Project(int id, string title, string description, string link)
        {
            Project_ID = id;
            Title = title;
            Description = description;
            Link = link;
        }
    }
}
