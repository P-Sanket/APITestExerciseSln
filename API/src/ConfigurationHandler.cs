using Microsoft.Extensions.Configuration;

namespace API
{
    public class ConfigurationHandler
    {
        public ConfigurationHandler(){}

        public Dictionary<string, string> ConfigHandler(){
            
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("apiEndpoints.json").Build();

            Dictionary<string, string>? baseSettings = config.GetRequiredSection("BaseSettings").Get<Dictionary<string,string>>();
            Dictionary<string, string>? endpoints = config.GetRequiredSection("Endpoints").Get<Dictionary<string,string>>();

            return baseSettings!
                    .Concat(endpoints!)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}