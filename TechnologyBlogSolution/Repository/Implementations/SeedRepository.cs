using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Seed;
using TechnologyBlogSolution.Models.Users;
using TechnologyBlogSolution.Repository.Contracts;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class SeedRepository : ISeedRepository
    {
        private readonly TechnologyBlogDbContext dbContext;

        public SeedRepository(TechnologyBlogDbContext technologyBlogDbContext)
        {
            this.dbContext = technologyBlogDbContext;
        }
   
        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void SeedData(SeedDataDto seedData)
        {
            List<string> authorsIds = this.dbContext.Users.Select(u => u.Id).ToList();
            int maxRandom = authorsIds.Count;
            Random rnd = new Random();

            List<Subject> subjects = new List<Subject>(new Subject[seedData.NumberOfSubjects])
             .Select(s => new Subject()
             {
                 Timestamp = DateTime.Now,
                 Name = "Seeded subject name",
                 Description = "Seeded subject description",
                 Posts = new List<Post>(new Post[seedData.NumberOfPosts])
                         .Select(p => new Post()
                         {
                             Name = "Some post name",
                             Author_Id = authorsIds.ElementAt(rnd.Next(0, maxRandom)),
                             Content = "Some post content",
                             Timestamp = DateTime.Now,
                             Comments = new List<Comment>(new Comment[seedData.NumberOfComments])
                                            .Select(c => new Comment()
                                            {
                                                Author_Id = authorsIds.ElementAt(rnd.Next(0,maxRandom)),
                                                Content = "some comment content",
                                                Timestamp = DateTime.Now
                                            }).ToList(),                        
                         }).ToList()
             }).ToList();

            this.dbContext.Subjects.AddRange(subjects);
        }

        public void SeedUsers(SeedUsersDto seedUsers)
        {
            for (int i = 0; i < seedUsers.NumberOfUsers; i++)
            {
                Random random = new Random();

                string guidString = Guid.NewGuid().ToString();
                User user = new User()
                {
                    UserName = guidString,
                    Email = guidString + "@gmail.com",
                    DateOfBirth = DateTime.Now
                };

                this.dbContext.Users.Attach(user);
                this.dbContext.Entry(user).State = System.Data.Entity.EntityState.Added;
            }
        }
    }
}