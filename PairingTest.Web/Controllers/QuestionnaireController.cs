using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.CommonUtilities.ApiAccess;
using PairingTest.Web.Models;
using PairingTest.Web.ViewModels;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        /* ASYNC ACTION METHOD... IF REQUIRED... */


        //just in case I have implemented asynchronous version of the action method as well..
        //below asynchronous method had been tested to be working

        [HttpGet]
        public async Task<ViewResult> IndexAsync()
        {
            var resultAsync =await GeographyQuestionsAccess.GetGeographyQuestionsAsync<Questionnairre>();

            List<Question> questionList = new List<Question>();
            foreach (var questionText in resultAsync.QuestionsText)
            {
                Question newQuestion = new Question { QuestionText = questionText };
                questionList.Add(newQuestion);
            }
            QuestionnaireViewModel questionnaireViewModel = new QuestionnaireViewModel
            {
                QuestionnaireTitle = resultAsync.QuestionnaireTitle,
                Questions = questionList
            };
            return View("Index", questionnaireViewModel);
        }

        [HttpGet]
        public ViewResult Index()
        {
            var result = GeographyQuestionsAccess.GetGeographyQuestions<Questionnairre>();

            List<Question> questionList = new List<Question>();
            foreach (var questionText in result.QuestionsText)
            {
                Question newQuestion = new Question { QuestionText = questionText };
                questionList.Add(newQuestion);
            }
            QuestionnaireViewModel questionnaireViewModel = new QuestionnaireViewModel
            {
                QuestionnaireTitle = result.QuestionnaireTitle,
                Questions = questionList
            };
            return View(questionnaireViewModel);
        }

        [HttpPost]
        public ActionResult ProcessSurvey(QuestionnaireViewModel questionnairre)
        {
            // for the time being no calculation has been made 
            return RedirectToAction("Index");

        }
    }
}
