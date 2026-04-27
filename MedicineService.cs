using pharmacy.Models;
using System.Text.Json;

namespace pharmacy
{
    public class MedicineService
    {
        private readonly string filePath = "medicines.json";
        public List<Medicine> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<Medicine>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Medicine>>(json);
        }

        public void SaveAll(List<Medicine> medicines)
        {
            var json = JsonSerializer.Serialize(medicines);
            File.WriteAllText(filePath, json);
        }
    }
}
