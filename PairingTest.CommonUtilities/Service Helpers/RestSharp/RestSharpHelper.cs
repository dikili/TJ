using System;
using System.Xml.Linq;
using PairingTest.CommonUtilities.Service_Helpers.RestSharp.Interfaces;
using RestSharp;

namespace PairingTest.CommonUtilities.Service_Helpers.RestSharp
{
    public class RestSharpHelper : IRestSharpHelper
    {
        private RestClient _client;
        private RestRequest _request;

        public void InitializeNewRequest(string baseUrl, string requestUri)
        {
            _client = new RestClient(baseUrl);
            _request = new RestRequest(requestUri);
        }

        public string GetStringContent()
        {
            try
            {
                if (_request == null)
                    return string.Empty;

                return _client.Execute(_request).Content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public XDocument GetXmlContent()
        {
            try
            {
                if (_request == null)
                    return new XDocument();

                return XDocument.Parse(_client.Execute(_request).Content);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddQueryStringParamter(string key, string value)
        {
            _request.AddParameter(key, value);
        }

        public void ReplaceUrlSegment(string key, string value)
        {
            _request.AddUrlSegment(key, value);
        }

        public void AddRequestHeader(string key, string value)
        {
            _request.AddHeader(key, value);
        }
    }
}
