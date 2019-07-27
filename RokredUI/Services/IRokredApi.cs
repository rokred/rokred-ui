using System;
using System.Collections.Generic;
using Refit;
using RokredUI.Models;

namespace RokredUI.Services
{
    public interface IRokredApi
    {
        [Get("/getall")]
        IObservable<IEnumerable<Opinion>> GetAll();
    }
}