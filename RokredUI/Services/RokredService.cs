using System;
using System.Collections.Generic;
using Refit;
using RokredUI.Models;

namespace RokredUI.Services
{
    public interface IRokredApi
    {
        [Get("/getallcategories")]
        IObservable<IEnumerable<Category>> GetCategories();
    }
    
    public interface IRokredService
    {
        IObservable<IEnumerable<Category>> GetCategories();
    }
    public class RokredService : IRokredService
    {
        private const string BaseUrl = "https://localhost:5001/api/rokred";
        
        private readonly IRokredApi _rokRedApi;

        public RokredService()
        {
            _rokRedApi = RestService.For<IRokredApi>(BaseUrl);
        }

        public IObservable<IEnumerable<Category>> GetCategories()
        {
            return  _rokRedApi.GetCategories();
        }
    }
}