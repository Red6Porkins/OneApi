using Newtonsoft.Json;
using SDK.Contracts;
using SDK.Responses;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace SDK
{
    public class OneApi : IOneApi
    {
        private const string BaseUri = "https://the-one-api.dev/v2/";
        private string AuthKey { get; set; }
        private IHttpClientFactory HttpClientFactory { get; init; }
        private List<QueryParameter> Params { get; set; }
        private string QueryString { get; set; }

        public OneApi(IHttpClientFactory httpClientFactory)
        {

            HttpClientFactory = httpClientFactory;
        }
        public void Configure(string authKey)
        {
            AuthKey = authKey;
        }

        private async Task<T> GETAsync<T>(string Uri, CancellationToken cancellationToken = default)
        {
            var httpClient = HttpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetStringAsync(new Uri($"{BaseUri}{Uri}"), cancellationToken);
            return JsonConvert.DeserializeObject<T>(response);
        }

        public OneApi AddPreFilter(QueryParameter Param)
        {
            if (Params == null)
            {
                Params = new List<QueryParameter> { Param };
            }
            else
            {
                Params.Add(Param);
            }

            return this;
        }
               
        public async Task<List<T>> RetrieveAll<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T: new()
        {
            QueryString = FilterBuilder.BuildQueryString(Params);
            var returnList = new List<T>();
            var response = await GETAsync<BaseResponse<List<T>>>($"{typeof(T).Name}?{QueryString}", cancellationToken);

            returnList.AddRange(response.Docs);

            if (response.Pages > 1)
            {
                int currentPage = response.Page;
                while (currentPage < response.Pages)
                {
                    response = await GETAsync<BaseResponse<List<T>>>($"{typeof(T).Name}?{QueryString}&page={currentPage + 1}", cancellationToken);
                    currentPage = response.Page;
                    returnList.AddRange(response.Docs);                    
                }
            }

            if (predicate != null)
            {
                IQueryable<T> queryable = returnList.AsQueryable();
                return queryable.Where(predicate).ToList();
            }
            else
            {
                return returnList;
            }
        }
    }
}