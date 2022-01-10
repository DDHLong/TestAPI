using System;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Discpline> Discplines { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Specialty> Specialities { get; set; }
        public DbSet<CandidateSpecialty> CandidateSpecialties { get; set; }
        public DbSet<CandidateJobType> CandidateJobTypes { get; set; }
        public DbSet<JobJobType> JobJobTypes { get; set; }

    }
}
