using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PairingTest.Web.Models
{
    public class Question
    {
        public string QuestionText  { get; set; }
        [DataType(DataType.MultilineText)]
        public string QuestionAnswer { get; set; }
    }
}