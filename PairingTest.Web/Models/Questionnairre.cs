using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PairingTest.Web.Models
{
    public class Questionnairre
    {
        public string QuestionnaireTitle { get; set; }
        public List<string> QuestionsText { get; set; }
    }
}