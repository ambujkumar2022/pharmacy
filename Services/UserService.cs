using pharmacy.Models;
using System.Text.Json;

namespace pharmacy.Services
{
    public class UserService
    {
        private readonly string filePath = "users.json";
        public List<Users> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<Users>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Users>>(json) ?? new List<Users>();
        }
        public void SaveAll(List<Users> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(filePath, json);
        }
    }
}
