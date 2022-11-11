namespace FAQAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.im_Faq_Translation", "FaqId", "dbo.im_Faq");
            DropIndex("dbo.im_Faq_Translation", new[] { "FaqId" });
            AlterColumn("dbo.im_Faq_Translation", "FaqId", c => c.Int());
            CreateIndex("dbo.im_Faq_Translation", "FaqId");
            AddForeignKey("dbo.im_Faq_Translation", "FaqId", "dbo.im_Faq", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.im_Faq_Translation", "FaqId", "dbo.im_Faq");
            DropIndex("dbo.im_Faq_Translation", new[] { "FaqId" });
            AlterColumn("dbo.im_Faq_Translation", "FaqId", c => c.Int(nullable: false));
            CreateIndex("dbo.im_Faq_Translation", "FaqId");
            AddForeignKey("dbo.im_Faq_Translation", "FaqId", "dbo.im_Faq", "Id", cascadeDelete: true);
        }
    }
}
