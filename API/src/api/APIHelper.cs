using Newtonsoft.Json.Linq;

namespace API.src.api
{
    public class APIHelper 
    {
        public APIHelper(){}

        public string getEndpoint(string endpointToGet){

            return readAPIEndpointConfig(endpointToGet);

        }

        private string readAPIEndpointConfig(string endpointToRead){
            ConfigurationHandler apiConfig = new ConfigurationHandler();
            var apiSettings = apiConfig.ConfigHandler();

            return apiSettings["basePath"] + apiSettings["version"] + apiSettings[endpointToRead];
        
        }

        public JObject parseToJObject(string stringToParse){
            JObject parsedJson = JObject.Parse(stringToParse);
            return parsedJson;
        }

    }
}