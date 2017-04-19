using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PairingTest.CommonUtilities.ApiAccess.Base
{
    public class JsonRestRequest : RestRequest
    {
        public JsonRestRequest(string route) : base(route)
        {
            RequestFormat = DataFormat.Json;
        }
        public JsonRestRequest(string route, Method httpMethod) : base(route, httpMethod)
        {
            RequestFormat = DataFormat.Json;
        }
    }
}
