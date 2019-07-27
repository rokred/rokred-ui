using System;
using System.Collections.Generic;
using Refit;
using RokredUI.Models;

namespace RokredUI.Services
{
    public class ApiService : IApiService
    {
        private const string BaseUrl = "http://rokred.azurewebsites.net/api/rokred";
        
        private readonly IRokredApi _rokRedApi;

        public ApiService()
        {
            _rokRedApi = RestService.For<IRokredApi>(BaseUrl);
        }

        public IObservable<IEnumerable<Opinion>> GetAll()
        {
            return _rokRedApi.GetAll();
        }
    }
}