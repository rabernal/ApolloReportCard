using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApolloReportCard.Models
{
    public class CriteriaModel
    {
        public int Id { get; set; }
        [Display(Name = "Criteria Name")]
        public string Name { get; set; }
        [Display(Name = "Q1")]
        public string QuarterOneGrade { get; set; }
        [Display(Name = "Q1 Comment")]
        public string QuarterOneComments { get; set; }
        [Display(Name = "Q2")]
        public string QuarterTwoGrade { get; set; }
        [Display(Name = "Q2 Comment")]
        public string QuarterTwoComments { get; set; }
        [Display(Name = "Q3")]
        public string QuarterThreeGrade { get; set; }
        [Display(Name = "Q3 Comment")]
        public string QuarterThreeComments { get; set; }
        [Display(Name = "Q4")]
        public string QuarterFourGrade { get; set; }
        [Display(Name = "Q4 Comment")]
        public string QuarterFourComments { get; set; }
    }
}