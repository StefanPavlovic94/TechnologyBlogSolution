using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public int CountUsers()
        {
            return this.userRepository.CountUsers();
        }
    }
}