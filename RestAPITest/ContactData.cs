namespace PortfolioRestAPI
{
    // Class named ContactData which is used for the ISendService method
    public class ContactData
    {
        public string Mail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
