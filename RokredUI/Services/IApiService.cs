using System;
using System.Collections.Generic;
using RokredUI.Models;

namespace RokredUI.Services
{
    public interface IApiService
    {
        IObservable<IEnumerable<Opinion>> GetAll();
    }
}