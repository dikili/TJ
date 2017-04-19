using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PairingTest.CommonUtilities.ApiAccess.Base;
using PairingTest.CommonUtilities.Service_Helpers.RestSharp;
using RestSharp;

namespace PairingTest.CommonUtilities.ApiAccess
{
    //all geography (may be) related questions centralized api wrapper class 
    public class GeographyQuestionsAccess
    {
       
        public static T GetGeographyQuestions<T>() where T : new()
        {
            var req = new JsonRestRequest("api/questions", Method.GET); 
            return RestSharpClient.Execute<T>(req);
        }

        public static async Task<T> GetGeographyQuestionsAsync<T>() where T : new()
        {
            var req = new JsonRestRequest("api/questions", Method.GET);
            return await RestSharpClient.ExecuteAsyn<T>(req);
        }

        public static string GetGeographyQuestions()
        {
            var req = new JsonRestRequest("api/questions",Method.GET);
            return RestSharpClient.Execute(req);
        }
    }
}
