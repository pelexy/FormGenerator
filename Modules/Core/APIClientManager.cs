using System;

using Refit;
using System.Text.Json;
using System.Threading.Tasks;
using Polly;
using System.Text.Json.Serialization;

namespace Ripple.API.Modules.Core
{
    public interface IErrorResponse
    {
        string Message { get; }
    }

    public abstract class ApiClientManager : IApiClientManager
    {
        private static readonly int NUMBER_OF_RETRIES = 1;


        protected abstract Task<string> GetToken();

        public static async Task<T> FallbackAsync<T>(Func<Task<T>> action, bool retry = true)
        {
            try
            {

                if (retry)
                {
                    var result = await Policy
                     .Handle<Exception>()
                     .RetryAsync(NUMBER_OF_RETRIES)
                     .ExecuteAsync(async () => await action())
                     .ConfigureAwait(false);

                    return result;
                }
                return await action().ConfigureAwait(false);
            }


            catch (ApiException ex)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var errorResponse = JsonSerializer.Deserialize<T>(ex.Content!, options);
                if (errorResponse != null)
                {
                    if (errorResponse is IErrorResponse response)
                    {
                        throw new AppException(response.Message);
                    }
                }
                throw new AppException(ex.Message);
            }
            catch (Exception ex)
            {

                throw new AppException(ex.Message);
            }

        }

        public async Task<TOutput> Send<TOutput, TInput>(Func<string, TInput, Task<TOutput>> taskFunc, TInput dto)
        {
            var token = await GetToken();
            return await FallbackAsync<TOutput>(async () => await taskFunc($"Bearer {token}", dto));

        }
        public async Task<TOutput> Send<TOutput, TInput>(Func<string, TInput, Task<TOutput>> taskFunc, TInput dto, bool retry)
        {
            var token = await GetToken();
            return await FallbackAsync<TOutput>(async () => await taskFunc($"Bearer {token}", dto), retry);

        }


        public async Task<TOutput> Send<TOutput>(Func<string, object[], Task<TOutput>> taskFunc, params object[] args)
        {
            var token = await GetToken();
            return await FallbackAsync<TOutput>(async () => await taskFunc($"Bearer {token}", args));
        }

        public async Task<TOutput> Send<TOutput>(Func<string, Task<TOutput>> taskFunc)
        {
            var token = await GetToken();
            return await FallbackAsync<TOutput>(async () => await taskFunc($"Bearer {token}"));
        }

        public async Task<TOutput> Send<TOutput>(Func<Task<TOutput>> taskFunc)
        {
            return await FallbackAsync<TOutput>(async () => await taskFunc());
        }

    }
}

