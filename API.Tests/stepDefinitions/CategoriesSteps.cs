using System;
using TechTalk.SpecFlow;
using API.src.api;
using API.src.api.clients;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace CategoriesSteps
{
    [Binding]
    public class StepDefinitions
    {
        private static string endpoint;
        private static RestResponse currentResponse;
        private JObject parsedResponse;

        private APIHelper helper = new APIHelper();

        public StepDefinitions(){}
        
        [Given(@"^there is a (.*) API endpoint$")]
        public void setAPIendpoint(String endpointName)
        {
           endpoint = helper.getEndpoint(endpointName);
        }
        
        [When(@"^a GET request is made to a (.*)$")]
        public void processRequestResponse(string categoryId)
        {
            using(var _client = new CategoriesAPIClient(endpoint)){
                currentResponse = _client.GetCategoryById(categoryId);
                parsedResponse = helper.parseToJObject(currentResponse.Content);
            }
        
        }   


        [Then(@"^the status code is (.*)$")]
        public void verifyStatusCode(int statusCode)
        {
            switch(statusCode){
                case 200:
                    Assert.AreEqual(System.Net.HttpStatusCode.OK, currentResponse.StatusCode);
                    break;
                default:
                    Assert.Fail("Please provide a valid Status Code to verify");
                    break;
                
            }
        }

        [Then(@"^the name property is (.*)$")]
        public void verifyName(string expectedName)
        {
           string actualName = (string)parsedResponse["Name"];
           Assert.AreEqual(expectedName, actualName);
        }

        [Then(@"^the category (.*) relist$")]
        public void verifyCategoryCanRelist(string canRelist)
        {
            var canActuallyRelist = (bool)parsedResponse["CanRelist"];
            if (canRelist.Equals("can")){
                Assert.IsTrue(canActuallyRelist);
            }else{
                Assert.IsFalse(canActuallyRelist);
            }
        }
 
        [Then(@"^the promotions element contains (.*) with description (.*)$")]
        public void verifyPromotionProperties(string expctedPromotionName, string expectedPromotionDescription)
        {
            var expectedPromotion = new {
                Name = expctedPromotionName, Description = expectedPromotionDescription
            }; 
            var actualPromotions = (
                from promotions in parsedResponse["Promotions"]
                select new {
                    Name = (string)promotions["Name"],
                    Description = (string)promotions["Description"]
                }
            ).ToList();
            CollectionAssert.Contains(actualPromotions, expectedPromotion);
        }

    }
}