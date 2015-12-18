namespace ApolloReportCard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CriteriaModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        QuarterOneGrade = c.String(),
                        QuarterOneComments = c.String(),
                        QuarterTwoGrade = c.String(),
                        QuarterTwoComments = c.String(),
                        QuarterThreeGrade = c.String(),
                        QuarterThreeComments = c.String(),
                        QuarterFourGrade = c.String(),
                        QuarterFourComments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CriteriaModels");
        }
    }
}
