using System.Text;
using System.Text.Json;
using FrontEnd.Models;

namespace FrontEnd.Classes
{
    public class ApiHandle
    {
        private static IConfiguration _configuration; // Making the configuration static

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration; // Set the static configuration
        }

        public static string Url => _configuration?.GetConnectionString("BackendApiUrl") ?? string.Empty;

        public async Task<List<FoodModel>> GetAllFood()
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                {
                    var response = await client.GetAsync($"{Url}/api/DB");
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var foodModel = Newtonsoft.Json.JsonConvert.DeserializeObject<FoodModel[]>(json);

                    return foodModel?.ToList() ?? new List<FoodModel>();
                }
            }
            catch (Exception e)
            {
                return new List<FoodModel>();
            }
        }

        public async Task<FoodModel> GetFoodById(int id)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                {
                    var response = await client.GetAsync($"{Url}/api/DB/{id}");
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var foodModel = Newtonsoft.Json.JsonConvert.DeserializeObject<FoodModel>(json);

                    return foodModel;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> CreateFood(FoodModel model)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"{Url}/api/DB", content);
                    response.EnsureSuccessStatusCode();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFood(int id, FoodModel model)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"{Url}/api/DB/{id}", content);
                    response.EnsureSuccessStatusCode();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFood(int id)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                {
                    var response = await client.DeleteAsync($"{Url}/api/DB/{id}");
                    response.EnsureSuccessStatusCode();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

}
