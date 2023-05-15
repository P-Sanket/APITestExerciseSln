using API.src.api.interfaces;
using RestSharp;

namespace API.src.api.clients
{
    public class CategoriesAPIClient : ICategoriesInterface, IDisposable {
        readonly RestClient _client;

        public CategoriesAPIClient(string endpoint){
            var options = new RestClientOptions(endpoint);
            _client = new RestClient(options){};
        }

        public RestResponse GetCategoryById(string categoryId){
            var request = new RestRequest();
            request.Resource = string.Format("{0}/Details.json", categoryId);
            
            var response = _client.Execute<RestResponse>(request);
            return response;
        }

        public void Dispose(){
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}