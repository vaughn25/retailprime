using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Prime.Library.Services;

namespace Prime.Tests
{
    public class UserTests
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;

        public UserTests()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _userService = new UserService();
        }

        [Fact]
        public void GetUsers_ReturnsListOfUsers_ShouldPass()
        {
            var data = _userService.GetUsers();
        }
    }
}
