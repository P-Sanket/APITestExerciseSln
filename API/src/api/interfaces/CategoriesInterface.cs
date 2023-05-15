using RestSharp;

namespace API.src.api.interfaces
{
    public interface ICategoriesInterface
    {
        RestResponse GetCategoryById(string categoryId);
    }
}