using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PairingTest.CommonUtilities.Service_Helpers.RestSharp.Interfaces
{
    public interface IRestSharpHelper
    {
        void InitializeNewRequest(string baseUrl, string requestUri);
        void AddQueryStringParamter(string key, string value);
        void ReplaceUrlSegment(string key, string value);
        void AddRequestHeader(string key, string value);
        string GetStringContent();
        XDocument GetXmlContent();
    }
}
