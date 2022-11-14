using Microsoft.EntityFrameworkCore;
using FAQ.common;

namespace FAQ.Data
{
    public class FaqDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx


        public FaqDBContext(DbContextOptions<FaqDBContext> options) : base(options)
        {
        }

        private string connectionString;

        public FaqDBContext()
        {
            connectionString = Utils.GetConfig("ConnectionStrings:PostgreSQLDatabase");
        }

        public virtual DbSet<FAQ.data.Entity.im_Faq> im_Faq { get; set; }
        public virtual DbSet<FAQ.data.Entity.im_Faq_Translation> im_Faq_Translation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
