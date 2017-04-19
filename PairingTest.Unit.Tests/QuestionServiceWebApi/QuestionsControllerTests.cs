using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {

        private string _expectedTitle;
        private Questionnaire _expectedQuestionnaire;

        [OneTimeSetUp]
        public void TestSetup()
        {
            // set the initial test data 
            _expectedTitle = "My expected questions";
            _expectedQuestionnaire = new Questionnaire
            {
                QuestionnaireTitle = _expectedTitle,
                QuestionsText = new List<string> {"Explain the 4 principles of Object Oriented Programming?", "What are the impacts of industrial pollution to our Earth?", "How many weeks are there in a year?"}
            };
        }
        [Test]
        public void ShouldGetTitle()
        {
            //Arrange
            var expectedQuestions = _expectedQuestionnaire;
            var fakeQuestionRepository = new FakeQuestionRepository() {ExpectedQuestions = expectedQuestions};
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            questions.QuestionnaireTitle.Should().NotBeNullOrEmpty();
            questions.QuestionnaireTitle.ShouldBeEquivalentTo(_expectedTitle);
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedQuestions = _expectedQuestionnaire;
            var fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = expectedQuestions };
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert

            questions.QuestionsText[0].ShouldBeEquivalentTo("Explain the 4 principles of Object Oriented Programming?");
            questions.QuestionsText[1].ShouldBeEquivalentTo("What are the impacts of industrial pollution to our Earth?");
            questions.QuestionsText[2].ShouldBeEquivalentTo("How many weeks are there in a year?");

        }
    }
}