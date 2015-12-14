using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApolloReportCard.Models
{
    public class CriteriaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuarterOneGrade { get; set; }
        public string QuarterOneComments { get; set; }
        public string QuarterTwoGrade { get; set; }
        public string QuarterTwoComments { get; set; }
        public string QuarterThreeGrade { get; set; }
        public string QuarterThreeComments { get; set; }
        public string QuarterFourGrade { get; set; }
        public string QuarterFourComments { get; set; }
    }
}