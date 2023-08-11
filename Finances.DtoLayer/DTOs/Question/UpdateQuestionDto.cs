using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DtoLayer.DTOs.Question
{
    public class UpdateQuestionDto
    {
        public int QuestionID { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionDescription { get; set; }
    }
}
