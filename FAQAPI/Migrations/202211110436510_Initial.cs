namespace FAQAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.im_Faq",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                        Language = c.String(maxLength: 5),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.im_Faq_Translation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Answer = c.String(nullable: false),
                        Language = c.String(maxLength: 5),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        FaqId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.im_Faq", t => t.FaqId, cascadeDelete: true)
                .Index(t => t.FaqId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.im_Faq_Translation", "FaqId", "dbo.im_Faq");
            DropIndex("dbo.im_Faq_Translation", new[] { "FaqId" });
            DropTable("dbo.im_Faq_Translation");
            DropTable("dbo.im_Faq");
        }
    }
}
