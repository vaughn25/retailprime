using System;
using System.Collections.Generic;
using System.Text;
using Prime.Library.Domain;
using Prime.Library.Domain.Exceptions;
using Prime.Models;

namespace Prime.Library.Services
{
    public interface IUserService
    {
        Task<UserModel> GetByUsernamePassword(string username, string password);
        Task<IEnumerable<UserModel>> GetUsers();
    }
    public class UserService : IUserService
    {
        public UserService()
        {
            if (HttpGlobals.HttpClient is null)
                throw new HttpClientException("Please initialize the HttpClient before using the UserService.");
        }

        public async Task<UserModel> GetByUsernamePassword(string username, string password)
        {
            var encryptedPassword = PrimeSecurityService.Encrypt(password);
            var endpoint = $"api/users/{username}/{encryptedPassword}";
            var response = await HttpGlobals.HttpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new ApiException($"Error retrieving user: {response.ReasonPhrase}");

            var userJson = await response.Content.ReadAsStringAsync();
            var user = System.Text.Json.JsonSerializer.Deserialize<UserModel>(userJson, HttpGlobals.SerializerOptions);
            return user ?? throw new UserException("User not found.");
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var endpoint = "api/users";
            var response = await HttpGlobals.HttpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
                throw new ApiException($"Error retrieving users: {response.ReasonPhrase}");

            var usersJson = await response.Content.ReadAsStringAsync();
            var users = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<UserModel>>(usersJson, HttpGlobals.SerializerOptions);
            return users ?? throw new UserException("No users found.");
        }
    }
}
