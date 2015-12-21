using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApolloReportCard.Models
{
    public class CriteriaViewList
    {
        public string myCriteria { get; set; }

        public List<string> Criteria = new List<string>();
        
        public List<string> getCriteria()
        {
            Criteria.Add("Quality");
            Criteria.Add("proficiency");
            Criteria.Add("Productivity");
            Criteria.Add("Dedication");
            Criteria.Add("Performance");
            return Criteria;
        }
    }

    
}