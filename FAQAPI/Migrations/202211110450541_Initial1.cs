namespace FAQAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.im_Faq", "Question", c => c.String());
            AlterColumn("dbo.im_Faq", "Answer", c => c.String());
            AlterColumn("dbo.im_Faq_Translation", "Question", c => c.String());
            AlterColumn("dbo.im_Faq_Translation", "Answer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.im_Faq_Translation", "Answer", c => c.String(nullable: false));
            AlterColumn("dbo.im_Faq_Translation", "Question", c => c.String(nullable: false));
            AlterColumn("dbo.im_Faq", "Answer", c => c.String(nullable: false));
            AlterColumn("dbo.im_Faq", "Question", c => c.String(nullable: false));
        }
    }
}
