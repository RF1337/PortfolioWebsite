/*using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Web.Helpers;

namespace PortfolioRestAPI
{
    public class SMSService : ISendService
    {
        public void SendData(ContactData contactData)
        {
            // Creating a new dictionary with the body data that should be used in the POST request
            var data = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", "+4541334735" },
                {"password", "FmUYujAu" }
            };
            // Creating a new HttpClient instance with the name client
            using HttpClient client = new HttpClient();
            // Setting the Accept header of the client to specify that it should be in JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Sends a POST request to the URL and saves the result in the variable "response"
            HttpResponseMessage response = client.PostAsync("https://api.suresms.com/json/token", new FormUrlEncodedContent(data)).Result;
            var jsonResponse = response.Content.ReadAsStringAsync().Result;

            // Creating a token variable that parses the jsonResponse,
            // and then retrieves the value of the access_token property as a string
            string? token = JObject.Parse(jsonResponse).Value<string>("access_token");
            Console.WriteLine($"Token: {token}");
        }
    }
}
*/