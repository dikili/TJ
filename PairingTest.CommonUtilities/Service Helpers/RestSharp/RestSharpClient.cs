using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace PairingTest.CommonUtilities.Service_Helpers.RestSharp
{
    internal class RestSharpClient
    {
        //if run from the tests or application is in test mode then use the test url
        private static string baseUrl = ConfigurationManager.AppSettings["TestMode"] == "1" ? ConfigurationManager.AppSettings["TestBaseUrl"]: ConfigurationManager.AppSettings["BaseUrl"];

        private static readonly RestClient Client = new RestClient(baseUrl);

        internal static T Execute<T>(RestRequest req) where T : new()
        {
            var response = Client.Execute<T>(req);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.ErrorException != null)
            {
                throw response.ErrorException;

            }
            
            T data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
         }
        //if we need to make asyn call this is ready to be used
        internal static async Task<T> ExecuteAsyn<T>(RestRequest req) where T : new()
        {
          
            var response =await Client.ExecuteTaskAsync<T>(req);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            T data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }
        internal static string Execute(RestRequest req)
        {
          //  Client.BaseUrl=new System.Uri(ConfigurationManager.AppSettings["QuestionnaireServiceUri"]);
            var response = Client.Execute(req);


            if (response.StatusCode == HttpStatusCode.BadRequest || response.ErrorException != null)
            {
                throw response.ErrorException;

            }
            string data =response.Content;

            return data;
        }
    }
}
