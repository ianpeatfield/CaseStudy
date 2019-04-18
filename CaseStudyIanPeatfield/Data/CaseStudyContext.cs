namespace CaseStudyIanPeatfield
{
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections;

    public partial class CaseStudyContext : DbContext
    {
        public CaseStudyContext()
            : base("name=CaseStudyContext")
        {
            
            Database.SetInitializer(new CaseStudyContextInitializer());
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationResult>().HasKey(x => x.Id);

            modelBuilder.Entity<ApplicationResult>()
               .HasMany(x => x.Applications);
        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<ApplicationResult> ApplicationResults { get; set; }

    }

    public class CaseStudyContextInitializer : CreateDatabaseIfNotExists<CaseStudyContext>
    {
        protected override void Seed(CaseStudyContext context)
        {
            
   
   
            context.ApplicationResults.Add(new ApplicationResult { Id = 1, Message = "The applicant is under 18 the message ‘no credit cards are available’ was shown", ShortDescription="No Credit Card" });
            context.ApplicationResults.Add(new ApplicationResult { Id = 2, Message = "The applicant is over 18 and has an annual income over £30000 they were shown a Barclaycard credit card", ShortDescription= "Barclay Card" });
            context.ApplicationResults.Add(new ApplicationResult { Id = 3, Message = "Applicant £30,000 or less and was shown a Vanquis Card" , ShortDescription= "Vanquis Card" });
            base.Seed(context);
        }
    }
}
