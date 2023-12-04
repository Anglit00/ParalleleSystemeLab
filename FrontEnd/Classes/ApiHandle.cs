using System.Text.Json;
using FrontEnd.Models;

namespace FrontEnd.Classes
{
    public class ApiHandle
    {
        public const string Url = "https://localhost:7150";
        public async Task<List<FoodModel>> GetAllFood()
        {
            try
            {
                using (HttpClient client = new())
                {
                    client.Timeout = new(0,0,10);
                    var response= await client.GetAsync(Url+"/api/DB");
                    string json = await response.Content.ReadAsStringAsync();
                    FoodModel[] foodModel = Newtonsoft.Json.JsonConvert.DeserializeObject<FoodModel[]>(json);
                    if (foodModel == null) return new();
                    return foodModel.ToList();
                }
            }
            catch (Exception e)
            {
                return new();
            }
        }
    }
}
