using ApolloReportCard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApolloReportCard.EntetyDBContext
{
    public class ApolloDB : DbContext
    {
        public ApolloDB() : base("name=DefaultConnection")
        {

        }
        public DbSet<CriteriaModel> Criteria { get; set; }
    }
}