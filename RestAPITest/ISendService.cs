namespace PortfolioRestAPI
{
    // Creating my ISendService interface which has a method for SendData that uses the 
    // ContactData class as a parameter
    public interface ISendService
    {
        void SendData(ContactData contactData);
    }
}
