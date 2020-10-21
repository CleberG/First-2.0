using First2._0.Infra.Context;
using First2._0.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First2._0.Tests.Integration.Utils
{
    [Collection("Sequential")]
    public abstract class IntegrationTestsBase : IClassFixture<CustomWebAppFactory<Startup>>
    {
        private readonly CustomWebAppFactory<Startup> _appFactory;
        protected readonly HttpClient Client;
        protected readonly MainContext _context;
        private List<ValidationErrorResponse> _validationErrorResponses;

        protected IntegrationTestsBase(CustomWebAppFactory<Startup> appFactory)
        {
            _appFactory = appFactory;
            Client = appFactory.CreateClient(new WebApplicationFactoryClientOptions());

            _context = appFactory.Db;

            Client.BaseAddress = new Uri("https://localhost:5001/");
        }

        protected async Task<List<ValidationErrorResponse>> GetErrosOnCreate<T>(T requestModel, string route)
        {
            var serializedUser = JsonConvert.SerializeObject(requestModel);
            var response = await Client.PostAsync($"/api/{route}",
                new StringContent(serializedUser, Encoding.UTF8, "application/json"));
            _validationErrorResponses = await response.Content.ReadAsAsync<List<ValidationErrorResponse>>();
            return _validationErrorResponses;
        }

        protected async Task<HttpResponseMessage> GetEntity(Guid id, string route)
        {
            return await Client.GetAsync($"/api/{route}/{id}");
        }

        protected async Task<HttpResponseMessage> CreateEntity<T>(T requestModel, string route)
        {
            var serializedUser = JsonConvert.SerializeObject(requestModel);
            var body = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            return Client.PostAsync($"/api/{route}", body).Result;
        }

        protected async Task<ApiResponse<U>> CreateEntity<T, U>(T requestModel, string route)
        {
            var serializedUser = JsonConvert.SerializeObject(requestModel);
            var body = new StringContent(serializedUser, Encoding.UTF8, "application/json");
            var response = Client.PostAsync($"/api/{route}", body).Result;
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<U>(content);

            return new ApiResponse<U>
            {
                ContentAsString = content,
                Data = data,
                StatusCode = response.StatusCode
            };
        }

        protected async Task<HttpStatusCode> DeleteEntity(Guid id, string route)
        {
            var response = await Client.DeleteAsync($"/api/{route}/{id}");
            return response.StatusCode;
        }

        protected async Task<HttpStatusCode> DeleteEntityList(List<Guid> list, string route)
        {
            var serializedList = JsonConvert.SerializeObject(list);
            var response = await Client.PutAsync($"/api/{route}",
                new StringContent(serializedList, Encoding.UTF8, "application/json"));
            return response.StatusCode;
        }

        protected async Task<HttpStatusCode> UpdateEntity<T>(T requestModel, Guid? id, string route)
        {
            var serializedUser = JsonConvert.SerializeObject(requestModel);
            var response = await Client.PutAsync($"/api/{route}/{id}",
                new StringContent(serializedUser, Encoding.UTF8, "application/json"));
            return response.StatusCode;
        }
    }
}
