using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Practice.Models
{
    public class Notice
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExamDate { get; set; }
        public string ExamSubject { get; set; }
        public string ExamSyllabus { get; set; }
    }
}