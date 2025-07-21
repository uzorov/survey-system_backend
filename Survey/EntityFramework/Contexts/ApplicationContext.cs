// <file>
//     <project="Survey.EntityFramework">
//     <author>"FIREWORKS"</author>
//     <date>"21/07/2025 12:34"</date>
// </file>

namespace Survey.EntityFramework.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Survey.ServiceDefaults.Models;

    public class ApplicationContext : DbContext
    {
        public DbSet<AnalysisResultModel> AnalysisResults => Set<AnalysisResultModel>();
        public DbSet<AnswerVariantModel> AnswerVariants => Set<AnswerVariantModel>();
        public DbSet<MetricModel> Metrics => Set<MetricModel>();
        public DbSet<QueryModel> Queries => Set<QueryModel>();
        public DbSet<QuestionModel> Questions => Set<QuestionModel>();
        public DbSet<SurveyModel> Surveys => Set<SurveyModel>();
        public DbSet<UserModel> Users => Set<UserModel>();

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Data Source=helloapp.db");
        }
    }
}