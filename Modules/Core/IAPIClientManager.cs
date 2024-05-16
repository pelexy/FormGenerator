using System;
using System.Threading.Tasks;

namespace Ripple.API.Modules.Core
{
    public interface IApiClientManager
    {
        Task<TOutput> Send<TOutput, TInput>(Func<string, TInput, Task<TOutput>> taskFunc, TInput dto);
        Task<TOutput> Send<TOutput, TInput>(Func<string, TInput, Task<TOutput>> taskFunc, TInput dto, bool retry);


        Task<TOutput> Send<TOutput>(Func<string, object[], Task<TOutput>> taskFunc, params object[] args);

        Task<TOutput> Send<TOutput>(Func<string, Task<TOutput>> taskFunc);

        Task<TOutput> Send<TOutput>(Func<Task<TOutput>> taskFunc);
    }
}

