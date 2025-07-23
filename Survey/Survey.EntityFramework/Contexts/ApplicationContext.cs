
using Microsoft.Extensions.Logging; 
using System;                      


namespace Survey.EntityFramework.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Survey.ServiceDefaults.Constants;
    using Survey.ServiceDefaults.Models;

    public class ApplicationContext : DbContext
    {
        public DbSet<AnalysisResultModel> AnalysisResults { get; set; }
        public DbSet<AnswerVariantModel> AnswerVariants { get; set; }
        public DbSet<MetricModel> Metrics { get; set; }
        public DbSet<QueryModel> Queries { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<SurveyModel> Surveys { get; set; }
        public DbSet<ContactModel> Users { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        optionsBuilder
            .UseNpgsql(
                Addresses.POSTGRES_ADDRESS,
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorCodesToAdd: null
                    );
                })
            .UseLoggerFactory(loggerFactory)
            .EnableSensitiveDataLogging()
            .UseLowerCaseNamingConvention();
    }
}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalysisResultModel>()
                        .HasOne(a => a.Query)
                        .WithOne(q => q.AnalysisResult)
                        .HasForeignKey<QueryModel>(q => q.AnalysisResultModelId);
        }
    }
}