using System.Web.Mvc;
using FluentAssertions;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.ViewModels;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        private string _titleHeader;
        [OneTimeSetUp]
        public void TestSetup()
        {
            _titleHeader= "Geography Questions";
        }

        [TestCase]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = _titleHeader;
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert
            result.Should().NotBeNull();
            result.QuestionnaireTitle.ShouldBeEquivalentTo(expectedTitle);

        }

        [TestCase]
        public void ActionReturnTypeShouldBeQuestionnaireViewModel()
        {
            //Arrange
          
            var questionnaireController = new QuestionnaireController();

            //Act
            var typeOfIndexActionName = questionnaireController.Index().ViewData.Model.GetType().Name;

            //Assert -Check if return type is correct
            typeOfIndexActionName.Should().Be("QuestionnaireViewModel");
        }

        [TestCase]
        public void IndexActionShouldHaveFourQuestionsAndOneTitle()
        {
            //Arrange

            var questionnaireController = new QuestionnaireController();

            //Act
            var returnedModel = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;

            //Assert -Check if return type is correct
            returnedModel.Questions.Should().NotBeNullOrEmpty();
            returnedModel.Questions.Count.ShouldBeEquivalentTo(4);
            returnedModel.QuestionnaireTitle.Should().NotBeNull();
            returnedModel.QuestionnaireTitle.Should().NotBeEmpty(); //this would fail if it was a list so title is only one entity
            returnedModel.QuestionnaireTitle.Should().BeOfType<string>();

        }
      

        [TestCase]
        public void ShouldGetQuestionsAsync()
        {
            //Arrange

            var questionnaireController = new QuestionnaireController();

            //Act
            var responseModel = (QuestionnaireViewModel)questionnaireController.IndexAsync().Result.ViewData.Model;

            //Assert -Check if return type is correct
            responseModel.Questions.Should().NotBeNullOrEmpty();
     
        }

        [TestCase]
        public void TypesShouldMatchForIndexAsync()
        {
            //Arrange

            var questionnaireController = new QuestionnaireController();

            //Act
            var responseType =questionnaireController.IndexAsync().Result.ViewData.Model.GetType().Name;

            //Assert -Check if return type is correct
            responseType.Should().Be("QuestionnaireViewModel");

        }


        [TestCase]
        public void IndexAsyncShouldHaveFourQuestionsAndOneTitle()
        {
            //Arrange

            var questionnaireController = new QuestionnaireController();

            //Act
            var returnedModel = (QuestionnaireViewModel)questionnaireController.IndexAsync().Result.ViewData.Model;

            //Assert -Check if return type is correct
            returnedModel.Questions.Should().NotBeNullOrEmpty();
            returnedModel.Questions.Count.ShouldBeEquivalentTo(4);
            returnedModel.QuestionnaireTitle.Should().NotBeNull();
            returnedModel.QuestionnaireTitle.Should().NotBeEmpty(); //this would fail if it was a list so title is only one entity
            returnedModel.QuestionnaireTitle.Should().BeOfType<string>();

        }

    }
}