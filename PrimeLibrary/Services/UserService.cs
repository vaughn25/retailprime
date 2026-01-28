using System;
using System.Collections.Generic;
using System.Text;
using Prime.Library.Domain;
using Prime.Library.Domain.Exceptions;
using Prime.Models;

namespace Prime.Library.Services
{
    public class UserService
    {
        public UserService() 
        { 
            if(HttpGlobals.HttpClient is null)
                throw new HttpClientException("Please initialize the HttpClient before using the UserService.");
        }

        public async Task<UserModel> GetUser(string username, string password)
        {
            var encryptedPassword = PrimeSecurityService.Encrypt(password);
            var endpoint = $"api/users/{username}/{encryptedPassword}";
            var response = await HttpGlobals.HttpClient.GetAsync(endpoint);

            if(!response.IsSuccessStatusCode)
                throw new ApiException($"Error retrieving user: {response.ReasonPhrase}");
            
            var userJson = await response.Content.ReadAsStringAsync();
            var user = System.Text.Json.JsonSerializer.Deserialize<UserModel>(userJson, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return user ?? throw new UserException("User not found.");
        }
    }
}
