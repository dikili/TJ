using System.Collections.Generic;
using PairingTest.Web.Models;

namespace PairingTest.Web.ViewModels
{
    public class QuestionnaireViewModel
    {
        public string QuestionnaireTitle { get; set; }
        public IList<Question> Questions { get; set; }
    }
}