using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PairingTest.CommonUtilities.ApiAccess;
using PairingTest.CommonUtilities.Service_Helpers.RestSharp;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
     [TestFixture]
    public class WebAPIIntegrationTests
    {
        //check if end point is active and working
        [TestCase]
        public void WebApiGetQuestionsEndPointTest()
        {
            //Arrange
            var _client = new RestSharpHelper();
            _client.InitializeNewRequest("http://localhost:8080", "/api/questions");

            //Act
            var result = _client.GetStringContent();

            //Assert

            JObject o = JObject.Parse(result);
            o["QuestionnaireTitle"].ShouldBeEquivalentTo("Geography Questions");
            o["QuestionsText"][0].ShouldBeEquivalentTo("What is the capital of Cuba?");
            o["QuestionsText"][1].ShouldBeEquivalentTo("What is the capital of France?");
            o["QuestionsText"][2].ShouldBeEquivalentTo("What is the capital of Poland?");
            o["QuestionsText"][3].ShouldBeEquivalentTo("What is the capital of Germany?");

        }

        [TestCase]
        public void WebApiGetQuestionsIntegrationTest()
        {
       
            //Act
            var result = GeographyQuestionsAccess.GetGeographyQuestions();
            var questionnaire=JsonConvert.DeserializeObject<Questionnaire>(result);

            //Assert

            questionnaire.QuestionnaireTitle.ShouldBeEquivalentTo("Geography Questions");
            questionnaire.QuestionsText[0].ShouldBeEquivalentTo("What is the capital of Cuba?");
            questionnaire.QuestionsText[1].ShouldBeEquivalentTo("What is the capital of France?");
            questionnaire.QuestionsText[2].ShouldBeEquivalentTo("What is the capital of Poland?");
            questionnaire.QuestionsText[3].ShouldBeEquivalentTo("What is the capital of Germany?");

        }
    }
}
