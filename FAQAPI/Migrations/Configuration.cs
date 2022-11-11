namespace FAQAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FAQAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FAQAPI.Data.FAQAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FAQAPI.Data.FAQAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.im_Faq.AddOrUpdate(x => x.Id,
                new im_Faq { Id = 1, Question = "What's Your Name?", Answer = "I'm Hinh", Language = "en", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq { Id = 2, Question = "How are you?", Answer = "I'm fine", Language = "en", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq { Id = 3, Question = "How old are you?", Answer = "I'm 20", Language = "en", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );

            context.im_Faq_Translation.AddOrUpdate(x => x.Id,
                new im_Faq_Translation { Id = 1, FaqId = 1, Question = "Ten ban la gi?", Answer = "Toi la Ngo Xuan Hinh", Language = "vn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 2, FaqId = 1, Question = "123?", Answer = "321", Language = "cn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 3, FaqId = 1, Question = "456?", Answer = "654", Language = "jp", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 3, FaqId = 1, Question = "456?", Answer = "654", Language = "en", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );
            context.im_Faq_Translation.AddOrUpdate(x => x.Id,
                new im_Faq_Translation { Id = 4, FaqId = 2, Question = "2?", Answer = "2", Language = "vn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 5, FaqId = 2, Question = "2?", Answer = "2", Language = "cn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 6, FaqId = 2, Question = "2?", Answer = "2", Language = "jp", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 6, FaqId = 2, Question = "2?", Answer = "2", Language = "en", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );
            context.im_Faq_Translation.AddOrUpdate(x => x.Id,
                new im_Faq_Translation { Id = 7, FaqId = 3, Question = "3?", Answer = "3", Language = "vn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 8, FaqId = 3, Question = "3?", Answer = "3", Language = "cn", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 9, FaqId = 3, Question = "3?", Answer = "3", Language = "jp", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new im_Faq_Translation { Id = 9, FaqId = 3, Question = "3?", Answer = "3", Language = "en", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );
        }
    }
}